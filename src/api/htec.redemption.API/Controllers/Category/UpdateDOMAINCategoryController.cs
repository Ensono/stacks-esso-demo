using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using htec.redemption.API.Models.Requests;

namespace htec.redemption.API.Controllers
{
    /// <summary>
    /// Category related operations
    /// </summary>
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Category")]
    public class UpdateDOMAINCategoryController : ApiControllerBase
    {
        public UpdateDOMAINCategoryController()
        {
        }

        /// <summary>
        /// Update a category in the domain
        /// </summary>
        /// <remarks>Update a category to domain</remarks>
        /// <param name="id">domain id</param>
        /// <param name="categoryId">Id for Category being removed</param>
        /// <param name="body">Category being added</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Resource not found</response>
        /// <response code="409">Conflict, an item already exists</response>
        [HttpPut("/v1/domain/{id}/category/{categoryId}")]
        [Authorize]
        public async Task<IActionResult> UpdateDOMAINCategory([FromRoute][Required] Guid id, [FromRoute][Required] Guid categoryId, [FromBody] UpdateCategoryRequest body)
        {
            // NOTE: Please ensure the API returns the response codes annotated above
            await Task.CompletedTask; // Your async code will be here

            return StatusCode(204);
        }
    }
}
