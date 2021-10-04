using System.Threading.Tasks;
using VBooX.Domain.Entities;

namespace VBooX.Application.Interfaces.Repositories
{
    public interface IClientRepository : IGenericRepositoryAsync<Client>
    {
        Task<bool> IsExists(string email, string phone);
    }
}
