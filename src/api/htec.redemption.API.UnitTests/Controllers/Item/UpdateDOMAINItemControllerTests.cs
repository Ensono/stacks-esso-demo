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
    public class UpdateDOMAINItemControllerTests
    {
        [Theory, AutoData]
        public async Task UpdateDOMAINItem_Returns204(Guid id, Guid categoryId, Guid itemId, UpdateItemRequest body)
        {
            var controller = new UpdateDOMAINItemController();
            var response = await controller.UpdateDOMAINItem(id, categoryId, itemId, body);

            int? statusCode = ((StatusCodeResult)response).StatusCode;

            Assert.Equal(StatusCodes.Status204NoContent, statusCode);
        }
    }
}
