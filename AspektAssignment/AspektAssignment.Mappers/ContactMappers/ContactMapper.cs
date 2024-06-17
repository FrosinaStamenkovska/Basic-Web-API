using AspektAssignment.Domain.Models;
using AspektAssignment.Dtos.ContactDtos;

namespace AspektAssignment.Mappers.ContactMappers
{
    public static class ContactMapper
    {
        public static Contact ToContactDomain(this CreateContactDto contactDto)
        {
            return new Contact
            {
                Name = contactDto.Name,
                CompanyId = contactDto.CompanyId,
                CountryId = contactDto.CountryId
            };

        }

        public static ContactDto ToContactDto(this Contact contact)
        {
            return new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                CompanyId = contact.CompanyId,
                CountryId = contact.CountryId,
            };
        }

        public static ContactDetailsDto ToContactDetailsDto(this Contact contact)
        {
            return new ContactDetailsDto
            {
                Id = contact.Id,
                Name = contact.Name,
                Company = contact.Company.Name,
                Country = contact.Country.Name,
            };
        }
    }
}
