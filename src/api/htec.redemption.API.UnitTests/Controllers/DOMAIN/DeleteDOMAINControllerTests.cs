using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using htec.redemption.API.Controllers;

namespace htec.redemption.API.UnitTests.Controllers
{
    [Trait("TestType", "UnitTests")]
    public class DeleteDOMAINControllerTests
    {
        [Theory, AutoData]
        public async Task DeleteDOMAIN_Returns204(Guid id)
        {
            var controller = new DeleteDOMAINController();
            var response = await controller.DeleteDOMAIN(id);

            int? statusCode = ((StatusCodeResult)response).StatusCode;

            Assert.Equal(StatusCodes.Status204NoContent, statusCode);
        }
    }
}
