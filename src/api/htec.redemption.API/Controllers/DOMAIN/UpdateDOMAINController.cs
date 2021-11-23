using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using htec.redemption.API.Models.Requests;

namespace htec.redemption.API.Controllers
{
    /// <summary>
    /// DOMAIN related operations
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiExplorerSettings(GroupName = "DOMAIN")]
    [ApiController]
    public class UpdateDOMAINController : ApiControllerBase
    {
        public UpdateDOMAINController()
        {
        }


        /// <summary>
        /// Update a domain
        /// </summary>
        /// <remarks>Update a domain with new information</remarks>
        /// <param name="id">domain id</param>
        /// <param name="body">DOMAIN being updated</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Resource not found</response>
        [HttpPut("/v1/domain/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateDOMAIN([FromRoute][Required] Guid id, [FromBody] UpdateDOMAINRequest body)
        {
            // NOTE: Please ensure the API returns the response codes annotated above

            await Task.CompletedTask; // Your async code will be here

            return StatusCode(204);
        }
    }
}
