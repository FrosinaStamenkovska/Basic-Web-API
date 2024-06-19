using AspektAssignment.Dtos.ContactDtos;
using AspektAssignment.Services.Implementation;
using AspektAssignment.Shared.CustomExceptions;
using AspektAssignment.Tests.FakeRepositories;

namespace AspektAssignment.Tests
{
    [TestClass]
    public class ContactServiceTests
    {
        private readonly FakeContactRepository _contactRepository = new();
        private readonly FakeCountryRepository _countryRepository = new();
        private readonly FakeCompanyRepository _companyRepository = new();
        
        [TestMethod]
        public  void GetById_ValidId_IsNotNull()
        {
            //Arrange
            int id = 2;
            ContactService contactService = new(_contactRepository, _companyRepository, _countryRepository);

            //Act
            var result =  contactService.GetById(id);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Get_CountAllContacts_AreEqual()
        {
            //Arrange
            int expectedCount = 3;
            ContactService contactService = new(_contactRepository, _companyRepository, _countryRepository);

            //Act
            var contacts = await contactService.Get();

            //Assert
            Assert.AreEqual(expectedCount, contacts.Count);
        }

        [ExpectedException(typeof(CompanyNotFoundException))]
        [TestMethod]
        public async Task Create_CreateContactWithInvalidCompanyId_Exception()
        {
            //Arrange
            ContactService contactService = new(_contactRepository, _companyRepository, _countryRepository);

            CreateContactDto contactDto = new ()
            {
               Name = "Test",
               CompanyId = 10,
               CountryId = 2
            };

            //Act
            var result = await contactService.Create(contactDto);
            
            //Assert
            Assert.ThrowsException<CompanyNotFoundException>(() => result);
        }

        [ExpectedException(typeof(CountryNotFoundException))]
        [TestMethod]
        public async Task Create_CreateContactWithInvalidCountryId_Exception()
        {
            //Arrange
            ContactService contactService = new(_contactRepository, _companyRepository, _countryRepository);

            CreateContactDto contactDto = new()
            {
                Name = "Test",
                CompanyId = 1,
                CountryId = 20
            };

            //Act
            var result = await contactService.Create(contactDto);

            //Assert
            Assert.ThrowsException<CountryNotFoundException>(() => result);
        }
    }
}
