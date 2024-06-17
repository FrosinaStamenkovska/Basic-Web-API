using AspektAssignment.Dtos.CompanyDtos;

namespace AspektAssignment.Services.Interface
{
    public interface ICompanyService
    {
        Task <List<CompanyDto>> Get();
        Task <CompanyDto> GetById(int id);
        Task <int> Create(CreateCompanyDto createCompanyDto);
        Task<CompanyDto> Update(CompanyDto companyDto);
        Task Delete(int id);

    }
}
