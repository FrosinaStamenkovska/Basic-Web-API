using AspektAssignment.Services.Implementation;
using AspektAssignment.Tests.FakeRepositories;

namespace AspektAssignment.Tests
{
    [TestClass]
    public class CompanyServiceTests
    {
        [TestMethod]
        public void GetById_ValidId_IsNotNull()
        {
            //Arrange
            int id = 1;
            CompanyService companyService = new(new FakeCompanyRepository());

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
            CompanyService companyService = new(new FakeCompanyRepository());

            //Act
            var companies = await companyService.Get();

            //Assert
            Assert.AreEqual(expectedCount, companies.Count);
        }
    }
}