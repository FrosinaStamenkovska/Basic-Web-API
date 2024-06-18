using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AspektAssignment.Tests.FakeRepositories
{
    public class FakeContactRepository : IContactRepository
    {
        private List<Contact> _contacts;

        public FakeContactRepository()
        {
            _contacts = new List<Contact>()
            {
                new Contact(){Id = 1, Name = "Contact1", CompanyId = 1, CountryId = 1},
                new Contact(){Id = 2, Name = "Contact2", CompanyId = 2, CountryId = 2},
                new Contact(){Id = 3, Name = "Contact3", CompanyId = 3, CountryId = 3},
            };
        }

        public async Task<int> Create(Contact entity)
        {
            _contacts.Add(entity);
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = _contacts.FirstOrDefault(x => x.Id == id);
            _contacts.Remove(entity);
        }

        public async Task<List<Contact>> FilterContacts(int? countryId, int? companyId)
        {
            var filteredContacts = _contacts.ToList();


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

        public async Task<List<Contact>> Get()
        {
            return _contacts.ToList();
        }

        public async Task<Contact> GetById(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }

        public Task<List<Contact>> GetContactsWithCompanyAndCountry()
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> Update(Contact entity)
        {
            var foundContact = _contacts.FirstOrDefault(x => x.Id == entity.Id);
            foundContact = entity;
            return foundContact;
        }
    }
}
