using AspektAssignment.Dtos.CompanyDtos;
using AspektAssignment.Services.Implementation;
using AspektAssignment.Shared.CustomExceptions;
using AspektAssignment.Tests.FakeRepositories;

namespace AspektAssignment.Tests
{
    [TestClass]
    public class CompanyServiceTests
    {
        private readonly FakeCompanyRepository _companyRepository = new();
        [TestMethod]
        public void GetById_ValidId_IsNotNull()
        {
            //Arrange
            int id = 1;
            CompanyService companyService = new(_companyRepository);

            //Act
            var result = companyService.GetById(id);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Get_CountAllCompanies_AreEqual()
        {
            //Arrange
            int expectedCount = 3;
            CompanyService companyService = new(_companyRepository);

            //Act
            var companies = await companyService.Get();

            //Assert
            Assert.AreEqual(expectedCount, companies.Count);
        }

        [ExpectedException(typeof(InvalidNameException))]
        [TestMethod]
        public async Task Create_CreateCompanyWithExistingName_Exception()
        {
            //Arrange
            CompanyService companyService = new(_companyRepository);

            CreateCompanyDto companyDto = new()
            {
                Name = "Apple",
            };

            //Act
            var result = await companyService.Create(companyDto);

            //Assert
            Assert.ThrowsException<InvalidNameException>(() => result);
        }
    }
}