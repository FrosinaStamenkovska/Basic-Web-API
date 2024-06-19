using AspektAssignment.Dtos.ContactDtos;
using FluentValidation;

namespace AspektAssignment.Dtos.FluentValidation.ContactValidator
{
    public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactDtoValidator() 
        {
            RuleFor(createContact => createContact.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(contact => contact.CompanyId)
                .NotNull().WithMessage("Company is required.")
                .GreaterThan(0).WithMessage("CompanyId must be greater than zero.");

            RuleFor(contact => contact.CountryId)
                .NotNull().WithMessage("Country is required.")
                .GreaterThan(0).WithMessage("CountryId must be greater than zero.");
        }
    }
}
