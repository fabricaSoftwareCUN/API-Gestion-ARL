using API_ARLRequest.Application.Queries.ArlRequest;
using API_ARLRequest.Application.Queries.Regional;
using API_ARLRequest.Infraestructure.AWS.AmazonS3.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_ARLRequest.Controllers
{
    [Route("api")]
    [ApiController]
    public class RegionalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegionalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("municipios")]
        public async Task<IActionResult> GetAllRegionales([FromQuery] string filtro)
        {
            try
            {
                var regionales = await _mediator.Send(new ListRegionalesQuery(filtro));

                if (regionales == null || regionales.Count() <= 0)
                {
                    return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "No existen coincidencias." });  
                }
                return Ok(regionales);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
