using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using htec.redemption.API.Controllers;
using htec.redemption.API.Models.Requests;
using htec.redemption.API.Models.Responses;

namespace htec.redemption.API.UnitTests.Controllers
{
    [Trait("TestType", "UnitTests")]
    public class AddDOMAINItemControllerTests
    {
        [Theory, AutoData]
        public async Task AddDOMAINItem_Returns201(Guid id, Guid categoryId, CreateItemRequest body)
        {
            var controller = new AddDOMAINItemController();
            var response = await controller.AddDOMAINItem(id, categoryId, body);

            int? statusCode = ((ObjectResult)response).StatusCode;
            var content = ((ObjectResult)response).Value;

            Assert.Equal(StatusCodes.Status201Created, statusCode);
            Assert.IsType<ResourceCreatedResponse>(content);
        }
    }
}
