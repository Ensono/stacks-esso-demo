using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using htec.redemption.API.Controllers;
using htec.redemption.API.Models.Requests;

namespace htec.redemption.API.UnitTests.Controllers
{
    [Trait("TestType", "UnitTests")]
    public class UpdateDOMAINControllerTests
    {
        [Theory, AutoData]
        public async Task UpdateDOMAIN_Returns204(Guid id, UpdateDOMAINRequest body)
        {
            var controller = new UpdateDOMAINController();
            var response = await controller.UpdateDOMAIN(id, body);

            int? statusCode = ((StatusCodeResult)response).StatusCode;

            Assert.Equal(StatusCodes.Status204NoContent, statusCode);
        }
    }
}
