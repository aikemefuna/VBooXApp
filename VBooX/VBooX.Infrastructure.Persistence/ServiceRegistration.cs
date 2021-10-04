using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VBooX.Application.Interfaces;
using VBooX.Application.Interfaces.Repositories;
using VBooX.Infrastructure.Persistence.Contexts;
using VBooX.Infrastructure.Persistence.Repositories;
using VBooX.Infrastructure.Persistence.Repository;

namespace VBooX.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient(typeof(IGenericServiceAsync<>), typeof(GenericServiceAsync<>));
            services.AddTransient<IVisitorBookRepositoryAsync, VisitorBookRepositoryAsync>();
            #endregion
        }
    }
}
