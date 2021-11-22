using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using htec.backend.API.Models.Requests;

namespace htec.backend.API.Controllers
{
    /// <summary>
    /// Item related operations
    /// </summary>
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Item")]
    public class UpdateDOMAINItemController : ApiControllerBase
    {
        public UpdateDOMAINItemController()
        {
        }

        /// <summary>
        /// Update an item in the domain
        /// </summary>
        /// <remarks>Update an item in the domain</remarks>
        /// <param name="id">Id for domain</param>
        /// <param name="categoryId">Id for Category where the item resides</param>
        /// <param name="itemId">Id for item being updated</param>
        /// <param name="body">Item being changed</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Resource not found</response>
        [HttpPut("/v1/domain/{id}/category/{categoryId}/items/{itemId}")]
        [Authorize]
        public async Task<IActionResult> UpdateDOMAINItem([FromRoute][Required] Guid id, [FromRoute][Required] Guid categoryId, [FromRoute][Required] Guid itemId, [FromBody] UpdateItemRequest body)
        {
            // NOTE: Please ensure the API returns the response codes annotated above
            await Task.CompletedTask; // Your async code will be here

            return StatusCode(204);
        }
    }
}
