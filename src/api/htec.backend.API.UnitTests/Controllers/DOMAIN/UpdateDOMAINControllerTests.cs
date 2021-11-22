using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using htec.backend.API.Controllers;
using htec.backend.API.Models.Requests;

namespace htec.backend.API.UnitTests.Controllers
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
