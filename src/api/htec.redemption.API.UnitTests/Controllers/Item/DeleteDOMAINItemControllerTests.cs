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
    public class DeleteDOMAINItemControllerTests
    {
        [Theory, AutoData]
        public async Task DeleteDOMAINItem_Returns204(Guid id, Guid categoryId, Guid itemId)
        {
            var controller = new DeleteDOMAINItemController();
            var response = await controller.DeleteDOMAINItem(id, categoryId, itemId);

            int? statusCode = ((StatusCodeResult)response).StatusCode;

            Assert.Equal(StatusCodes.Status204NoContent, statusCode);
        }
    }
}
