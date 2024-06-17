using AspektAssignment.Domain.Models;
using AspektAssignment.Dtos.CompanyDtos;

namespace AspektAssignment.Mappers.CompanyMappers
{
    public static class CompanyMapper
    {
        public static Company ToCompanyDomain(this CreateCompanyDto dto)
        {
            return new Company
            {
                Name = dto.Name,
            };
        }

        public static CompanyDto ToCompanyDto(this Company company)
        {
            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
            };
        }

    }
}
