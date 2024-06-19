using AspektAssignment.Dtos.CompanyDtos;
using FluentValidation;

namespace AspektAssignment.Dtos.FluentValidation.CompanyValidator
{
    public class CreateCompanyDtoValidator : AbstractValidator<CreateCompanyDto>
    {
        public CreateCompanyDtoValidator() 
        { 
            RuleFor(createCompany => createCompany.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");
        }
    }
}
