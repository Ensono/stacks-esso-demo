using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using htec.redemption.API.Models.Responses;

namespace htec.redemption.API.Controllers
{
    /// <summary>
    /// DOMAIN related operations
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiExplorerSettings(GroupName = "DOMAIN")]
    [ApiController]
    public class GetDOMAINByIdV2Controller : ApiControllerBase
    {
        /// <summary>
        /// Get a domain
        /// </summary>
        /// <remarks>By passing the domain id, you can get access to available categories and items in the domain </remarks>
        /// <param name="id">domain id</param>
        /// <response code="200">DOMAIN</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Resource not found</response>
        [HttpGet("/v2/domain/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(DOMAIN), 200)]
        public virtual IActionResult GetDOMAINV2([FromRoute][Required]Guid id)
        {
            // NOTE: Please ensure the API returns the response codes annotated above

            return BadRequest();
        }
    }
}
