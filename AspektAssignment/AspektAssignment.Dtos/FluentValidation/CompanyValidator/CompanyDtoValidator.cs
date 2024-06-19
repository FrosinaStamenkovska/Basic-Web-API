using AspektAssignment.Dtos.CompanyDtos;
using FluentValidation;

namespace AspektAssignment.Dtos.FluentValidation.CompanyValidator
{
    public class CompanyDtoValidator : AbstractValidator<CompanyDto>
    {
        public CompanyDtoValidator() 
        {
            RuleFor(company => company.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2,100).WithMessage("Name must be between 2 and 100 characters.");
        }
    }
}
