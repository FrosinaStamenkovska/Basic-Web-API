using AspektAssignment.Dtos.CountryDtos;
using FluentValidation;

namespace AspektAssignment.Dtos.FluentValidation.CountryValidator
{
    public class CreateCountryDtoValidator : AbstractValidator<CreateCountryDto>
    {
        public CreateCountryDtoValidator()
        {
            RuleFor(createCountry => createCountry.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");
        }
    }
}
