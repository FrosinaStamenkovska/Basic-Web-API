using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Dtos.ContactDtos;
using AspektAssignment.Mappers.ContactMappers;
using AspektAssignment.Services.Interface;

namespace AspektAssignment.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository) 
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> Create(CreateContactDto createContactDto)
        {
            return await _contactRepository.Create(createContactDto.ToContactDomain());
        }

        public async Task Delete(int id)
        {
            await _contactRepository.Delete(id);
        }

        public async Task<List<ContactDto>> FilterContacts(int? countryId, int? companyId)
        {
            var contacts = await _contactRepository.FilterContacts(countryId, companyId);
            return contacts.Select(x => x.ToContactDto()).ToList();
        }

        public async Task<List<ContactDto>> Get()
        {
            var contacts = await _contactRepository.Get();
            return contacts.Select(x => x.ToContactDto()).ToList();
        }

        public async Task<ContactDto> GetById(int id)
        {
            var contact = await _contactRepository.GetById(id);
            return contact.ToContactDto();
        }

        public async Task<List<ContactDetailsDto>> GetContactsWithCompanyAndCountry()
        {
            var contacts = await _contactRepository.GetContactsWithCompanyAndCountry();
            return contacts.Select(x => x.ToContactDetailsDto()).ToList();
        }

        public async Task<ContactDto> Update(ContactDto contactDto)
        {
            var foundContact = await _contactRepository.GetById(contactDto.Id);
            foundContact.Name = contactDto.Name;
            foundContact.CountryId = contactDto.CountryId;
            foundContact.CompanyId = contactDto.CompanyId;

            var updatedContact = await _contactRepository.Update(foundContact);
            return updatedContact.ToContactDto() ;
        }
    }
}
