using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AspektAssignment.DataAccess.Implementation
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly AspektDbContext _dbContext;
        public ContactRepository(AspektDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Contact>> GetContactsWithCompanyAndCountry()
        {
            return await _dbContext.Contacts.Include(x => x.Company).Include(x => x.Country).ToListAsync();
        }

        public async Task<List<Contact>> FilterContacts(int? countryId, int? companyId)
        {
            var filteredContacts = await _dbContext.Contacts.Include(x => x.Company).Include(x => x.Country).ToListAsync();


            if (countryId != null)
            {
                filteredContacts = filteredContacts.Where(x => x.CountryId == countryId).ToList();
            }

            if (companyId != null)
            {
                filteredContacts = filteredContacts.Where(x => x.CompanyId == companyId).ToList();
            }

            if (!filteredContacts.Any()) throw new KeyNotFoundException();
            
                return filteredContacts;
            
        }

    }
}
