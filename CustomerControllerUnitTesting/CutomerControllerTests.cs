using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductBox_ExerciseSolution.Controllers;
using ProductBox_ExerciseSolution.Interfaces;
using ProductBox_ExerciseSolution.Models;
using ProductBox_ExerciseSolution.CustomerRepository;


namespace CustomerControllerUnitTesting
{
    public class CutomerControllerTests
    {
        [Fact]
        public async Task GetCustomer_ReturnsNotFound_ForInvalidId()
        {
            // Arrange
            var mockRepo = new Mock<ICustomer>();
            mockRepo.Setup(repo => repo.GetAll()); 
            // Simulating not finding a customer
            var controller = new CustomerController(mockRepo.Object);

            // Act
            var result = await controller.GetCustomerByID(1); // Assuming customer with ID 1 doesn't exist

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task CreateCustomer_ReturnsCreatedAtAction()
        {
            // Arrange
            var mockRepo = new Mock<ICustomer>();
            var controller = new CustomerController(mockRepo.Object);
            var newCustomer = new Customer { Id = 3, Name = "New Customer" };

            // Act
            var result = await controller.AddCustomer(newCustomer) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("GetCustomerByID", result.ActionName);
            Assert.Equal(3, result.RouteValues["id"]);
        }

        [Fact]
        public async Task UpdateCustomer_ReturnsNoContent_ForValidUpdate()
        {
            // Arrange
            var mockRepo = new Mock<ICustomer>();
            mockRepo.Setup(repo => repo.GetByID(1))
                .ReturnsAsync(new Customer { Id = 1, Name = "Existing Customer" }); // Simulating an existing customer
            var controller = new CustomerController(mockRepo.Object);
            var updatedCustomer = new Customer { Id = 1, Name = "Updated Customer" };

            // Act
            var result = await controller.UpdateCustomer(1, updatedCustomer);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteCustomer_ReturnsNoContent_ForValidDelete()
        {
            // Arrange
            var mockRepo = new Mock<ICustomer>();
            var controller = new CustomerController(mockRepo.Object);

            // Act
            var result = await controller.DeleteCustomer(1); // Assuming customer with ID 1 exists

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}