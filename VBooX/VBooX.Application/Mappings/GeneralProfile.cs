using AutoMapper;
using VBooX.Application.DTOs.Client;
using VBooX.Domain.Entities;

namespace VBooX.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<CreateClientDTO, Client>();
        }
    }
}
