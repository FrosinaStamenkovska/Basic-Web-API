using AspektAssignment.Domain.Models;
using AspektAssignment.Dtos.CountryDtos;

namespace AspektAssignment.Mappers.CountryMappers
{
    public static class CountryMapper
    {
        public static Country ToCountryDomain(this CreateCountryDto dto)
        {
            return new Country
            {
                Name = dto.Name,
            };
        }

        public static CountryDto ToCountryDto(this Country country)
        {
            return new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
            };
        }

    }
}
