using AspektAssignment.DataAccess.Interface;
using AspektAssignment.Domain.Models;
using AspektAssignment.Dtos.CountryDtos;
using AspektAssignment.Mappers.CountryMappers;
using AspektAssignment.Services.Interface;
using AspektAssignment.Shared.CustomExceptions;

namespace AspektAssignment.Services.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IContactRepository _contactRepository;

        public CountryService(IRepository<Country> countryRepository, IContactRepository contactRepository)
        {
            _countryRepository = countryRepository;
            _contactRepository = contactRepository;
        }

        public async Task<int> Create(CreateCountryDto createCountryDto)
        {
            var countries = await _countryRepository.Get();

            if (countries.Any(x => x.Name.Equals(createCountryDto.Name, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new InvalidNameException($"The country name {createCountryDto.Name} already exists");
            }
            return await _countryRepository.Create(createCountryDto.ToCountryDomain());
        }

        public async Task Delete(int id)
        {
            await _countryRepository.Delete(id);
        }

        public async Task<List<CountryDto>> Get()
        {
            var countries = await _countryRepository.Get();
            return countries.Select(x => x.ToCountryDto()).ToList();
        }

        public async Task<CountryDto> GetById(int id)
        {
            var country = await _countryRepository.GetById(id);
            return country.ToCountryDto() ?? throw new CountryNotFoundException($"Country with id {id} does not exist!"); ;
        }

        public async Task<Dictionary<string, int>> GetCompanyStatisticsByCountryId(int id)
        {
            var contacts = await _contactRepository.FilterContacts(id ,null);
            return contacts.GroupBy(x => x.Company.Name).ToDictionary(x => x.Key, x => x.Count());


        }

        public async Task<CountryDto> Update(CountryDto countryDto)
        {
            var foundCountry = await _countryRepository.GetById(countryDto.Id) ?? throw new CompanyNotFoundException($"Country with id {countryDto.Id} does not exist!");

            if(foundCountry.Name != countryDto.Name) 
            {
                    var countries = await _countryRepository.Get();

                    if (countries.Any(x => x.Name.Equals(countryDto.Name, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        throw new InvalidNameException($"The country name {countryDto.Name} already exists");
                    }
            }

            foundCountry.Name = countryDto.Name;

            var updatedCountry = await _countryRepository.Update(foundCountry);
            return updatedCountry.ToCountryDto();
        }
    }
}
