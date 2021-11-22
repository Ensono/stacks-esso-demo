using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using htec.backend.API.Controllers;
using htec.backend.API.Models.Requests;
using htec.backend.API.Models.Responses;

namespace htec.backend.API.UnitTests.Controllers
{
    [Trait("TestType", "UnitTests")]
    public class CreateDOMAINControllerTests
    {
        [Theory, AutoData]
        public async Task CreateDOMAIN_ReturnsCreatedAtActionResult(CreateDOMAINRequest body)
        {
            var controller = new CreateDOMAINController();
            var response = await controller.CreateDOMAIN(body);

            Assert.IsType<CreatedAtActionResult>(response);
            var content = (CreatedAtActionResult)response;
            Assert.Equal("GetDOMAIN", content.ActionName);
            Assert.Equal("GetDOMAINById", content.ControllerName);
            Assert.Equal("GetDOMAINById", content.ControllerName);
            Assert.IsType<ResourceCreatedResponse>(content.Value);
        }
    }
}
