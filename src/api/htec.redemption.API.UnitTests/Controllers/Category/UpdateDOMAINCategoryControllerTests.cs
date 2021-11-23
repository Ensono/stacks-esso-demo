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
    public class UpdateDOMAINCategoryControllerTests
    {
        [Theory, AutoData]
        public async Task UpdateDOMAINCategory_Returns204(Guid id, Guid categoryId, UpdateCategoryRequest body)
        {
            var controller = new UpdateDOMAINCategoryController();
            var response = await controller.UpdateDOMAINCategory(id, categoryId, body);

            int? statusCode = ((StatusCodeResult)response).StatusCode;

            Assert.Equal(StatusCodes.Status204NoContent, statusCode);
        }
    }
}
