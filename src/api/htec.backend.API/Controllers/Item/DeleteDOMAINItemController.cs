using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace htec.backend.API.Controllers
{
    /// <summary>
    /// Item related operations
    /// </summary>
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Item")]
    public class DeleteDOMAINItemController : ApiControllerBase
    {
        public DeleteDOMAINItemController()
        {
        }

        /// <summary>
        /// Removes an item from domain
        /// </summary>
        /// <remarks>Removes an item from domain</remarks>
        /// <param name="id">DOMAIN Id</param>
        /// <param name="categoryId">Category Id</param>
        /// <param name="itemId">Id for Item being removed</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Resource not found</response>
        [HttpDelete("/v1/domain/{id}/category/{categoryId}/items/{itemId}")]
        [Authorize]
        public async Task<IActionResult> DeleteDOMAINItem([FromRoute][Required] Guid id, [FromRoute][Required] Guid categoryId, [FromRoute][Required] Guid itemId)
        {
            // NOTE: Please ensure the API returns the response codes annotated above

            await Task.CompletedTask; // Your async code will be here

            return StatusCode(204);
        }
    }
}
