using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatiNerde.Application.Features.Commands.CMain.CMapMarker;
using PatiNerde.Application.Features.Queries.QMain.QMapMarker;

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
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] AppMapMarkerGetAllRequest request )
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>Create([FromBody] AppMapMarkerAddRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] AppMapMarkerRemoveRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult>Update([FromBody] AppMapMarkerUpdateRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
