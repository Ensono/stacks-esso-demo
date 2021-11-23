using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace htec.redemption.API.Controllers
{
    /// <summary>
    /// DOMAIN related operations
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiExplorerSettings(GroupName = "DOMAIN")]
    [ApiController]
    public class DeleteDOMAINController : ApiControllerBase
    {
        public DeleteDOMAINController()
        {
        }

        /// <summary>
        /// Removes a domain with all its categories and items
        /// </summary>
        /// <remarks>Remove a domain from a restaurant</remarks>
        /// <param name="id">domain id</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Resource not found</response>
        [HttpDelete("/v1/domain/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDOMAIN([FromRoute][Required] Guid id)
        {
            // NOTE: Please ensure the API returns the response codes annotated above

            await Task.CompletedTask; // Your async code will be here

            return StatusCode(204);
        }
    }
}
