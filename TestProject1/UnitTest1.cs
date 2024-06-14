using CRUD_application_2.Controllers;
using Microsoft.Web.Mvc;
using NUnit.Framework;

namespace YourProjectName.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize UserController here
            // If UserController depends on services, you need to mock them
            _controller = new UserController();
        }

        [Test]
        public void GetUser_WithValidId_ReturnsUser()
        {
            // Arrange
            int testUserId = 1; // Assuming this ID exists

            // Act
            var result = _controller.Details(testUserId);

            // Assert
            Assert.IsNotNull(result, "Expected to get a user object, but got null");
            Assert.AreEqual(testUserId, result.Id, "The returned user ID does not match the requested ID");
        }

        [Test]
        public void GetUser_WithInvalidId_ReturnsNull()
        {
            // Arrange
            int testUserId = 999; // Assuming this ID does not exist

            // Act
            var result = _controller.GetUser(testUserId);

            // Assert
            Assert.IsNull(result, "Expected to get null, but got a user object");
        }
    }
}