using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using htec.backend.API.Controllers;
using htec.backend.API.Models.Responses;

namespace htec.backend.API.UnitTests.Controllers
{
    [Trait("TestType", "UnitTests")]
    public class SearchDOMAINControllerTests
    {
        [Theory, AutoData]
        public async Task SearchDOMAIN_Returns200_AndSearchDOMAINResponse(string searchTerm, Guid? restaurantId, int pageSize, int pageNumber)
        {
            var controller = new SearchDOMAINController();
            var response = await controller.SearchDOMAIN(searchTerm, restaurantId, pageSize, pageNumber);

            var content = ((ObjectResult)response).Value;

            Assert.IsType<SearchDOMAINResponse>(content);
            var offset = ((SearchDOMAINResponse)content).Offset;
            var size = ((SearchDOMAINResponse)content).Size;
            Assert.Equal(pageSize, size);
            Assert.Equal(pageNumber * pageSize, offset);
        }
    }
}
