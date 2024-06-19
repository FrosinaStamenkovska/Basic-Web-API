using AspektAssignment.Dtos.FluentValidation.CompanyValidator;
using AspektAssignment.Dtos.FluentValidation.ContactValidator;
using AspektAssignment.Dtos.FluentValidation.CountryValidator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspektAssignment.Helpers.FluentValidationHelper
{
    public static class FluentValidationHelper
    {
        public static void RegisterFluentValidation(IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CompanyDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCompanyDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<ContactDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateContactDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CountryDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCountryDtoValidator>();
        }

       
    }
}
