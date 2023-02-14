using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using FoodAppWebApi.Controllers;
using FoodAppWebApi.DataAccessLayer;
using FoodAppWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Moq;
//using NUnit.Framework;
using Xunit;

namespace FoodWebApi.Tests.Controllers
{
    public class FoodControllerTests
    {
        [Fact]
        public void GetRestaurants_ValidRestId_listOfMenu()
        {
            //Arrange
            var mock = new Mock<DataAccess>();
            mock.Setup(x => x.GetMenuById(1)).Returns(new List<Menu>() { new Menu() });
            FoodController foodController = new FoodController(mock.Object);
            var result = foodController.GetRestaurantMenuById(1);

            Console.WriteLine("result skdjnasdkjnaskjdn");
            Assert.NotNull(result);

        }



        [Fact]
        public void GetRestaurants_InValidRestId_NotFound()
        {
            //Arrange
            var mock = new Mock<DataAccess>();
            mock.Setup(x => x.GetMenuById(1)).Returns(new List<Menu>());
            FoodController foodController = new FoodController(mock.Object);
            var result = foodController.GetRestaurantMenuById(1);
            Console.WriteLine("eeeeeeeeeeee");
            Console.WriteLine("result skdjnasdkjnaskjdn");
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public void GetRestaurants_IsValidCuisine_Restaurants()
        {
            var mock = new Mock<DataAccess>();
            mock.Setup(x => x.GetRestaurantByCuisine("Chinese")).Returns(new List<Restaurants>() { new Restaurants()});
            FoodController foodController = new FoodController(mock.Object);
            var result = foodController.GetRestaurantByCuisine("Chinese");
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void GetRestaurants_IsInValidCuisine_NotFound()
        {
            var mock = new Mock<DataAccess>();
            mock.Setup(x => x.GetRestaurantByCuisine("XXX")).Returns(new List<Restaurants>());
            FoodController foodController = new FoodController(mock.Object);
            var result = foodController.GetRestaurantByCuisine("XXX");
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteItemById_IsValid_Deletes()
        {
            var mock = new Mock<DataAccess>();
            mock.Setup(x => x.DeleteItemByIdFromCart(1)).Returns(1);
            FoodController foodController = new FoodController(mock.Object);
            var result = foodController.DeleteCartItemById(1);
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void DeleteItemById_IsNotValid_NotFound()
        {
            var mock = new Mock<DataAccess>();
            mock.Setup(x => x.DeleteItemByIdFromCart(1)).Returns(0);
            FoodController foodController = new FoodController(mock.Object);
            var result = foodController.DeleteCartItemById(1);
            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetCart_IsValid_Cart()
        {
            var mock = new Mock<DataAccess>();
            mock.Setup(x => x.GetCartByUserName("Raksha")).Returns(new List<Cart>() { new Cart() });
            FoodController foodController = new FoodController(mock.Object);
            var result = foodController.GetCartByUserName("Raksha");
            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);
        }


    }
}
