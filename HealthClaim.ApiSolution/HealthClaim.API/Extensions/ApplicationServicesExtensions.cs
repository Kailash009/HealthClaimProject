using HealthClaim.BAL.Repository;
using HealthClaim.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HealthClaim.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddAppliationServices(this IServiceCollection services, IConfiguration config)
        {
            throw new NotImplementedException();
            /*//DbContext by vip
            services.AddDbContext<HealthClaimDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;*/
        }
    }
}
