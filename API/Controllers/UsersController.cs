using Application.Features.Users.Commands;

namespace API.Controllers;

[AllowAnonymous]
public class UsersController : AbstractController
{
    public UsersController(IMediator mediator) : base(mediator) {}

    [HttpPost("login")]
    public async Task<IActionResult> Login(Login request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(TokenRefresher request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
}