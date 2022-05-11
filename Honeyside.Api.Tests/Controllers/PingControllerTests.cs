using Honeyside.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Honeyside.Api.Tests.Controllers
{
    [TestClass]
    public class PingControllerTests
    {
        [TestMethod]
        public void Get_Returns_OkResult()
        {
            // Arrange
            var logger = new Mock<ILogger<PingController>>();
            var controller = new PingController(logger.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}