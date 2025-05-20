using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatiNerde.Application.Features.Commands.CMain.CMapMarker;

namespace PatiNerde.WebApi.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapMaker : ControllerBase
    {
        private readonly IMediator _mediator;
        

        public MapMaker(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>Create([FromBody] AppMapMarkerRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
