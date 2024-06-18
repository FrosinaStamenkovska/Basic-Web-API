using AspektAssignment.Dtos.ContactDtos;
using AspektAssignment.Services.Implementation;
using AspektAssignment.Shared.CustomExceptions;
using AspektAssignment.Tests.FakeRepositories;

namespace AspektAssignment.Tests
{
    [TestClass]
    public class ContactServiceTests
    {
        [TestMethod]
        public  void GetById_ValidId_IsNotNull()
        {
            //Arrange
            int id = 2;
            ContactService contactService = new(new FakeContactRepository(),new FakeCompanyRepository(), new FakeCountryRepository());

            //Act
            var result =  contactService.GetById(id);

            //Assert
            Assert.IsNotNull(result);
        }

        [ExpectedException(typeof(CompanyNotFoundException))]
        [TestMethod]
        public async Task Create_CreateContactWithInvalidCompanyId_Exception()
        {
            //Arrange
            ContactService contactService = new(new FakeContactRepository(), new FakeCompanyRepository(), new FakeCountryRepository());

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
    }
}
