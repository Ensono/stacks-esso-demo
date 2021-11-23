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
    public class AddDOMAINCategoryControllerTests
    {
        [Theory, AutoData]
        public async Task AddDOMAINCategory_Returns201(Guid id, CreateCategoryRequest body)
        {
            var controller = new AddDOMAINCategoryController();
            var response = await controller.AddDOMAINCategory(id, body);

            int? statusCode = ((ObjectResult)response).StatusCode;
            var content = ((ObjectResult)response).Value;

            Assert.Equal(StatusCodes.Status201Created, statusCode);
            Assert.IsType<ResourceCreatedResponse>(content);
        }
    }
}
