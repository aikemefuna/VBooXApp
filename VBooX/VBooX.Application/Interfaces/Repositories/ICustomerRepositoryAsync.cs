using System.Collections.Generic;
using System.Threading.Tasks;
using VBooX.Application.DTOs.Customer;

namespace VBooX.Application.Interfaces.Repositories
{
    public interface ICustomerRepositoryAsync
    {
        Task<CustomerDTO> GetByAccountNumberAsync(string accountNumber);

        Task<List<CustomerDTO>> GetCustomersbyClientIdAsync(int clientId);

        Task<bool> IsUniqueEmail(string email);
    }
}
