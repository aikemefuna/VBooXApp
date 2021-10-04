using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VBooX.Application.Interfaces.Repositories;
using VBooX.Domain.Entities;
using VBooX.Infrastructure.Persistence.Contexts;
using VBooX.Infrastructure.Persistence.Repository;

namespace VBooX.Infrastructure.Shared.Services
{
    public class ClientRepository : GenericRepositoryAsync<Client>, IClientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsExists(string email, string phone) => await _dbContext.Client.AnyAsync(c => c.Email == email || c.PhoneNo == phone);
    }
}
