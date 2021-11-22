using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using htec.backend.API.Models.Requests;
using htec.backend.API.Models.Responses;

namespace htec.backend.API.Controllers
{
    /// <summary>
    /// DOMAIN related operations
    /// </summary>
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "DOMAIN")]
    [ApiController]
    public class CreateDOMAINController : ApiControllerBase
    {
        public CreateDOMAINController()
        {
        }

        /// <summary>
        /// Create a domain
        /// </summary>
        /// <remarks>Adds a domain</remarks>
        /// <param name="body">DOMAIN being created</param>
        /// <response code="201">Resource created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="409">Conflict, an item already exists</response>
        [HttpPost("/v1/domain/")]
        [Authorize]
        [ProducesResponseType(typeof(ResourceCreatedResponse), 201)]
        public async Task<IActionResult> CreateDOMAIN([Required][FromBody] CreateDOMAINRequest body)
        {
            // NOTE: Please ensure the API returns the response codes annotated above

            var id = Guid.NewGuid();

            await Task.CompletedTask; // Your async code will be here

            return new CreatedAtActionResult(
                "GetDOMAIN", "GetDOMAINById", new
                {
                    id = id
                }, new ResourceCreatedResponse(id)
            );
        }
    }
}
