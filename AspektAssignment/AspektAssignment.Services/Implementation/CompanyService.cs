using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Domain.Models;
using AspektAssignment.Dtos.CompanyDtos;
using AspektAssignment.Mappers.CompanyMappers;
using AspektAssignment.Services.Interface;

namespace AspektAssignment.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<int> Create(CreateCompanyDto createCompanyDto)
        {
            return await _companyRepository.Create(createCompanyDto.ToCompanyDomain());
        }

        public async Task Delete(int id)
        {
            await _companyRepository.Delete(id);
        }

        public async Task<List<CompanyDto>> Get()
        {
            var companies = await _companyRepository.Get();
            return companies.Select(x => x.ToCompanyDto()).ToList();
        }

        public async Task<CompanyDto> GetById(int id)
        {
            var company = await _companyRepository.GetById(id);
            return company.ToCompanyDto();
        }

        public async Task<CompanyDto> Update(CompanyDto companyDto)
        {
            var foundCompany = await _companyRepository.GetById(companyDto.Id);
            foundCompany.Name = companyDto.Name;

            var updatedCompany = await _companyRepository.Update(foundCompany);
            return updatedCompany.ToCompanyDto();

        }
    }
}
