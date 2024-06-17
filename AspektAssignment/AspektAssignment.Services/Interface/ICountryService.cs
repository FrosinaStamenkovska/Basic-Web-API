using AspektAssignment.Dtos.CountryDtos;

namespace AspektAssignment.Services.Interface
{
    public interface ICountryService
    {
        Task<List<CountryDto>> Get();
        Task<CountryDto> GetById(int id);
        Task<int> Create(CreateCountryDto createCountryDto);
        Task<CountryDto> Update(CountryDto countryDto);
        Task Delete(int id);
        Task <Dictionary<string, int>>GetCompanyStatisticsByCountryId(int id);
    }
}
