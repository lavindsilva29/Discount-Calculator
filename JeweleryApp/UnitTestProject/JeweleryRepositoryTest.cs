using JeweleryApp.Repositories;
using Xunit;

namespace UnitTestProject
{
    public class JeweleryRepositoryTest : IClassFixture<TestFixture>
    {
        readonly JeweleryRepository repository;
        readonly TestFixture fixture;

        public JeweleryRepositoryTest(TestFixture testFixture)
        {
            this.fixture = testFixture;
            repository = new JeweleryRepository(fixture.context);
        }

        [Fact]
        public void Check_Valid_User()
        {
            //Arrange
            var userId = "user";
            var password = "Password123";

            //Act
            var result = repository.IsUserValid(userId, password);

            //Assert
            Assert.NotNull(result);
            Assert.NotEqual("true", result.ToString());
        }

        [Fact]
        public void Check_Invalid_User()
        {
            //Arrange
            var userId = "user1";
            var password = "password";

            //Act
            var result = repository.IsUserValid(userId,password);

            //Assert
            Assert.Null(result);
        }

    }
}
