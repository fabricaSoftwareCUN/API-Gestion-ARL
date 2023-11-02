using API_ARLRequest.Application.Queries.ArlRequest;
using API_ARLRequest.Application.Queries.Regional;
using API_ARLRequest.Infraestructure.AWS.AmazonS3.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

                return Ok(regionales);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            
        }
    }
}
