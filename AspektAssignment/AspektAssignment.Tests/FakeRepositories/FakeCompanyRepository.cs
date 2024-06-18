using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Domain.Models;

namespace AspektAssignment.Tests.FakeRepositories
{
    public class FakeCompanyRepository : IRepository<Company>
    {
        private List<Company> _companies;

        public FakeCompanyRepository()
        {
            _companies = new List<Company>()
            {
                new Company {Id = 1, Name = "Apple"},
                new Company {Id = 2, Name = "Amazon"},
                new Company {Id = 3, Name = "Meta"},
            };
        }

        public async Task<int> Create(Company entity)
        {
            _companies.Add(entity);
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = _companies.FirstOrDefault(x => x.Id == id);
            _companies.Remove(entity);
        }

        public async Task<List<Company>> Get()
        {
            return _companies.ToList();
        }

        public async Task<Company> GetById(int id)
        {
            return _companies.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Company> Update(Company entity)
        {
            var foundCompany = _companies.FirstOrDefault(x => x.Id == entity.Id);
            foundCompany = entity;
            return foundCompany;
        }
    }
}
