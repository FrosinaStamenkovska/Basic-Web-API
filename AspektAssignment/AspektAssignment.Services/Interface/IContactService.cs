using AspektAssignment.Dtos.ContactDtos;

namespace AspektAssignment.Services.Interface
{
    public interface IContactService
    {
        Task<List<ContactDto>> Get();
        Task<ContactDto> GetById(int id);
        Task<int> Create(CreateContactDto createContactDto);
        Task<ContactDto> Update(ContactDto contactDto);
        Task Delete(int id);
        Task<List<ContactDetailsDto>> GetContactsWithCompanyAndCountry();
        Task<List<ContactDto>> FilterContacts(int? countryId, int? companyId);
    }
}
