using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Domain.Models;
using AspektAssignment.Dtos.ContactDtos;
using AspektAssignment.Mappers.ContactMappers;
using AspektAssignment.Services.Interface;
using AspektAssignment.Shared.CustomExceptions;

namespace AspektAssignment.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Country> _countryRepository;

        public ContactService(IContactRepository contactRepository, IRepository<Company> companyRepository, IRepository<Country> countryRepository) 
        {
            _contactRepository = contactRepository;
            _companyRepository = companyRepository;
            _countryRepository = countryRepository;
        }

        public async Task<int> Create(CreateContactDto createContactDto)
        {
            if (await _companyRepository.GetById(createContactDto.CompanyId) == null)
            {
                throw new CompanyNotFoundException($"Company with id {createContactDto.CompanyId} does not exist!");
            }

            if (await _countryRepository.GetById(createContactDto.CountryId) == null)
            {
                throw new CountryNotFoundException($"Country with id {createContactDto.CountryId} does not exist!");
            }
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
            return contact.ToContactDto() ?? throw new ContactNotFoundException($"Contact with id {id} does not exist!");
        }

        public async Task<List<ContactDetailsDto>> GetContactsWithCompanyAndCountry()
        {
            var contacts = await _contactRepository.GetContactsWithCompanyAndCountry();
            return contacts.Select(x => x.ToContactDetailsDto()).ToList();
        }

        public async Task<ContactDto> Update(ContactDto contactDto)
        {
            if (await _companyRepository.GetById(contactDto.CompanyId) == null)
            {
                throw new CompanyNotFoundException($"Company with id {contactDto.CompanyId} does not exist!");
            }

            if (await _countryRepository.GetById(contactDto.CountryId) == null)
            {
                throw new CountryNotFoundException($"Country with id {contactDto.CountryId} does not exist!");
            }

            var foundContact = await _contactRepository.GetById(contactDto.Id) ?? throw new ContactNotFoundException($"Contact with id {contactDto.Id} does not exist!");
            foundContact.Name = contactDto.Name;
            foundContact.CountryId = contactDto.CountryId;
            foundContact.CompanyId = contactDto.CompanyId;

            var updatedContact = await _contactRepository.Update(foundContact);
            return updatedContact.ToContactDto() ;
        }
    }
}
