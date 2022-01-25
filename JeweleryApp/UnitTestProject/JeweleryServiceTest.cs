using JeweleryApp.Models;
using JeweleryApp.Repositories;
using JeweleryApp.Services;
using Moq;
using Xunit;

namespace UnitTestProject
{
    public class JeweleryServiceTest
    {
        JeweleryService service;

        [Fact]
        public void Calculate_Gold_Discount()
        {
            //Arrange
            var dummyUser = new GoldItem
            {
                Price = 1000,
                Weight = 10,
                Discount = 5
            };
            var price = 1000;
            var weight = 10;
            var discount = 5;
            var totalprice = 9500;
            var mockRepo = new Mock<IJeweleryRepository>();
            mockRepo.Setup(repo => repo.DiscountCalculator(price,weight,discount));

            service = new JeweleryService(mockRepo.Object);

            //Act

            var result = service.DiscountCalculator(price, weight, discount);

            //Assert

            Assert.NotNull(result);
            Assert.Equal(totalprice, result.Result);

        }    

    }
}
