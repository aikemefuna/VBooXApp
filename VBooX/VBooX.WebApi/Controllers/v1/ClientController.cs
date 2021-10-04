using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using VBooX.Application.DTOs.Account;
using VBooX.Application.DTOs.Client;
using VBooX.Application.DTOs.Email;
using VBooX.Application.Enums;
using VBooX.Application.Interfaces;
using VBooX.Application.Interfaces.Repositories;
using VBooX.Application.Wrappers;
using VBooX.Domain.Entities;
using VBooX.WebApi.Helpers;

namespace VBooX.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IAccountNumberGeneratorService _accountNumberGeneratorService;
        private readonly IGenericRepositoryAsync<ClientSubscription> _clientSubscriptionRepository;
        private readonly IGenericRepositoryAsync<SubscriptionPlan> _subscriptionPlanRepository;
        private readonly IEmailService _emailService;
        private readonly IAccountService _accountService;

        public ClientController(IClientRepository clientRepository,
                                IMapper mapper,
                                IAccountNumberGeneratorService accountNumberGeneratorService,
                                IGenericRepositoryAsync<ClientSubscription> clientSubscriptionRepository,
                                IGenericRepositoryAsync<SubscriptionPlan> subscriptionPlanRepository,
                                IEmailService emailService,
                                IAccountService accountService)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _accountNumberGeneratorService = accountNumberGeneratorService;
            _clientSubscriptionRepository = clientSubscriptionRepository;
            _subscriptionPlanRepository = subscriptionPlanRepository;
            _emailService = emailService;
            _accountService = accountService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public async Task<IActionResult> Create([FromBody] CreateClientDTO request)
        {
            if (await _clientRepository.IsExists(request.Email, request.PhoneNo))
                return Ok(ResponseHelper<ClientDTO>.Exists(null, "You are already registered with us"));

            var client = _mapper.Map<Client>(request);
            client.AccountNumber = _accountNumberGeneratorService.GenerateAccountNumber();
            var response = await _clientRepository.AddAsync(client);
            if (response != null)
            {
                //add client subscription to free plan
                var clientSubscriptionRequest = ClientSubscriptionRequest(response);
                await _clientSubscriptionRepository.AddAsync(clientSubscriptionRequest);


                //Create the client user account
                var newuser = new RegisterRequest { Email = client.Email, PhoneNumber = client.PhoneNo, Role = Roles.Client.ToString() };
                var result = await _accountService.RegisterAsync(newuser, request.WebUrl, Roles.Client.ToString());

                if (result.Succeeded)
                {
                    //Send activation email to the client
                    try
                    {
                        string messageBody = EmailHelper.ConfirmEmailTemplate(client.Email, result.Data);
                        string subject = "Activate your VBooX account";
                        await _emailService.SendAsync(new EmailRequest { Body = messageBody, Subject = subject, To = client.Email });
                    }
                    catch (Exception ex)
                    {

                    }
                    var clientDTO = _mapper.Map<ClientDTO>(client);
                    return Ok(ResponseHelper<ClientDTO>.SuccessMessage(clientDTO, "Client created successful"));
                }
                else
                {
                    //if the user account profile is not created successfully, delete the client record created earlier.
                    await _clientRepository.DeleteAsync(client);
                }


            }
            return Ok(ResponseHelper<ClientDTO>.Failed(null, "Failed to create profile"));

        }

        private ClientSubscription ClientSubscriptionRequest(Client client)
        {
            var freePlan = _subscriptionPlanRepository.GetAll().Where(c => c.IsFree).FirstOrDefault();
            var response = new ClientSubscription
            {
                AmountPaid = 0,
                ClientId = client.ClientId,
                CreatedBy = client.Email,
                CreatedOn = DateTime.Now,
                DateDue = DateTime.Now.AddDays(freePlan.DurationInDaysForFreePlan),
                SubscriptionPlanId = freePlan.SubscriptionPlanId
            };
            return response;
        }
    }
}
