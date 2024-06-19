using AspektAssignment.Dtos.CountryDtos;
using AspektAssignment.Services.Implementation;
using AspektAssignment.Shared.CustomExceptions;
using AspektAssignment.Tests.FakeRepositories;

namespace AspektAssignment.Tests
{
    [TestClass]
    public class CountryServiceTests
    {
        private readonly FakeContactRepository _contactRepository = new();
        private readonly FakeCountryRepository _countryRepository = new ();
        
        [TestMethod]
        public void GetById_ValidId_IsNotNull()
        {
            //Arrange
            int id = 1;
            CountryService countryService = new(_countryRepository, _contactRepository);

            //Act
            var result = countryService.GetById(id);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Get_CountAllCountries_AreEqual()
        {
            //Arrange
            int expectedCount = 3;
            CountryService countryService = new(_countryRepository, _contactRepository);

            //Act
            var countries = await countryService.Get();

            //Assert
            Assert.AreEqual(expectedCount, countries.Count);
        }


        [ExpectedException(typeof(InvalidNameException))]
        [TestMethod]
        public async Task Create_CreateCountryWithExistingName_Exception()
        {
            //Arrange
            CountryService countryService = new(_countryRepository, _contactRepository);

            CreateCountryDto countryDto = new()
            {
                Name = "Macedonia",
            };

            //Act
            var result = await countryService.Create(countryDto);

            //Assert
            Assert.ThrowsException<InvalidNameException>(() => result);
        }
    }
}
