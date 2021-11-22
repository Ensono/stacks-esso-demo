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
    public class GetDOMAINByIdController : ApiControllerBase
    {
        public GetDOMAINByIdController()
        {
        }

        /// <summary>
        /// Get a domain
        /// </summary>
        /// <remarks>By passing the domain id, you can get access to available categories and items in the domain </remarks>
        /// <param name="id">domain id</param>
        /// <response code="200">DOMAIN</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Resource not found</response>
        [HttpGet("/v1/domain/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(DOMAIN), 200)]
        public async Task<IActionResult> GetDOMAIN([FromRoute][Required] Guid id)
        {
            // NOTE: Please ensure the API returns the response codes annotated above

            var result = new DOMAIN()
            {
                Id = id,
                Description = "DOMAIN description",
                Categories = new List<Category>()
                {
                    new Category() {
                        Id = Guid.NewGuid(),
                        Description = "Category Description",
                         Name = "Category name",
                         Items = new List<Item>()
                         {
                             new Item()
                             {
                                 Id = Guid.NewGuid(),
                                 Name = "Item name 1",
                                 Description = "Item description 1",
                                 Available = true,
                                 Price = 10
                             },
                             new Item()
                             {
                                 Id = Guid.NewGuid(),
                                 Name = "Item name 2",
                                 Description = "Item description 2",
                                 Available = true,
                                 Price = 10
                             }
                         }
                    }
                },
                Enabled = true,
                Name = "DOMAIN name"
            };

            await Task.CompletedTask; // Your async code will be here

            return new ObjectResult(result);
        }
    }
}
