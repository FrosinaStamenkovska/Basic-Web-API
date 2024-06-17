using AspektAssignment.DataAccess;
using AspektAssignment.DataAccess.Implementation;
using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Domain.Models;
using AspektAssignment.Services.Implementation;
using AspektAssignment.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspektAssignment.Helpers.DependencyInjectionHelper
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AspektDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Country>, Repository<Country>>();
            services.AddTransient<IRepository<Company>, Repository<Company>>();
            services.AddTransient<IContactRepository, ContactRepository> ();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<ICountryService, CountryService> ();
            services.AddTransient<ICompanyService, CompanyService> ();
            services.AddTransient<IContactService, ContactService> ();
        }
    }
}
