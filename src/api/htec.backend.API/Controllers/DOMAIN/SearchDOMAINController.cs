using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using htec.backend.API.Models.Responses;

namespace htec.backend.API.Controllers
{
    /// <summary>
    /// DOMAIN related operations
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiExplorerSettings(GroupName = "DOMAIN")]
    [ApiController]
    public class SearchDOMAINController : ApiControllerBase
    {
        public SearchDOMAINController()
        {
        }


        /// <summary>
        /// Get or search a list of domains
        /// </summary>
        /// <remarks>By passing in the appropriate options, you can search for available domains in the system </remarks>
        /// <param name="searchTerm">pass an optional search string for looking up domains</param>
        /// <param name="RestaurantId">id of restaurant to look up for domain's</param>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">maximum number of records to return per page</param>
        /// <response code="200">search results matching criteria</response>
        /// <response code="400">bad request</response>
        [HttpGet("/v1/domain/")]
        [Authorize]
        [ProducesResponseType(typeof(SearchDOMAINResponse), 200)]
        public async Task<IActionResult> SearchDOMAIN(
            [FromQuery] string searchTerm,
            [FromQuery] Guid? RestaurantId,
            [FromQuery][Range(0, 50)] int? pageSize = 20,
            [FromQuery] int? pageNumber = 1)
        {
            // NOTE: Please ensure the API returns the response codes annotated above

            var results = new SearchDOMAINResponse()
            {
                Offset = (pageNumber ?? 0) * (pageSize ?? 0),
                Size = (pageSize ?? 0),
                Results = new List<SearchDOMAINResponseItem>()
                {
                    new SearchDOMAINResponseItem()
                    {
                        Name = "DOMAIN",
                        Description = "DOMAIN Description",
                        Enabled = true,
                        Id = Guid.NewGuid()
                    },
                    new SearchDOMAINResponseItem()
                    {
                        Name = "DOMAIN 2",
                        Description = "DOMAIN Description 2",
                        Enabled = true,
                        Id = Guid.NewGuid()
                    }
                }
            };

            await Task.CompletedTask; // Your async code will be here

            return new ObjectResult(results);
        }
    }
}
