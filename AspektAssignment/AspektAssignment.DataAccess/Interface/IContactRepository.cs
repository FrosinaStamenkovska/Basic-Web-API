using AspektAssignment.Domain.Models;

namespace AspektAssignment.DataAccess.Interface
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<List<Contact>> GetContactsWithCompanyAndCountry();
        Task<List<Contact>> FilterContacts(int? countryId, int? companyId);
    }
}
