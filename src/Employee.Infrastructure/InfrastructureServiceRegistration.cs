using Employee.Application.Common.Interface;
using Employee.Application.Interface;
using Employee.Infrastructure.Persistence;
using Employee.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
