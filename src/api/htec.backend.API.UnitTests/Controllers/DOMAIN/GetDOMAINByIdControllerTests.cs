using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using htec.backend.API.Controllers;
using htec.backend.API.Models.Responses;

namespace htec.backend.API.UnitTests.Controllers
{
    [Trait("TestType", "UnitTests")]
    public class GetDOMAINByIdControllerTests
    {
        [Theory, AutoData]
        public async Task GetDOMAIN_Returns200_AndDOMAIN(Guid id)
        {
            var controller = new GetDOMAINByIdController();
            var response = await controller.GetDOMAIN(id);

            var content = ((ObjectResult)response).Value;
            Assert.IsType<DOMAIN>(content);
        }
    }
}
