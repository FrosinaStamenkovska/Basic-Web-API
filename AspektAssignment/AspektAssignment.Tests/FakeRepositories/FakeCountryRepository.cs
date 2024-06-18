using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Domain.Models;

namespace AspektAssignment.Tests.FakeRepositories
{
    public class FakeCountryRepository : IRepository<Country>
    {
        private List<Country> _countries;

        public FakeCountryRepository()
        {
            _countries = new List<Country>()
            {
                new (){Id = 1, Name = "Macedonia"},
                new (){Id = 2, Name = "Greece"},
                new (){Id = 3, Name = "Serbia"},
            };
        }

        public async Task<int> Create(Country entity)
        {
            _countries.Add(entity);
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = _countries.FirstOrDefault(x => x.Id == id);
            _countries.Remove(entity);
        }

        public async Task<List<Country>> Get()
        {
            return _countries.ToList();
        }

        public async Task<Country> GetById(int id)
        {
            return _countries.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Country> Update(Country entity)
        {
            var foundCountry = _countries.FirstOrDefault(x => x.Id == entity.Id);
            foundCountry = entity;
            return foundCountry;
        }
    }
}
