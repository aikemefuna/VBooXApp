using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VBooX.Application.Interfaces;
using VBooX.Application.Interfaces.Repositories;
using VBooX.Domain.Settings;
using VBooX.Infrastructure.Shared.Services;

namespace VBooX.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IAccountNumberGeneratorService, AccountNumberGeneratorService>();
        }
    }
}
