using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatiNerde.Application.Features.Commands.CMain.CUser;

namespace PatiNerde.WebApi.Controllers.Main;

[ApiVersion("1")]
[ApiController]
[Route("v1/[controller]")]
public class User : ControllerBase
{
    private readonly IMediator _mediator;
    public User(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] AppUserRegisterRequest request)
    {
        return Ok (await _mediator.Send(request));
    }
}
