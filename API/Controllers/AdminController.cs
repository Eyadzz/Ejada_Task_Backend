using Application.Features.Departments.Commands;
using Application.Features.Departments.Queries;
using Application.Features.Users.Commands;

namespace API.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : AbstractController
{
    public AdminController(IMediator mediator) : base(mediator) {}
    
    [HttpPost("AddManager")]
    public async Task<IActionResult> AddManager(AddManager request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpPost("AddDepartment")]
    public async Task<IActionResult> AddDepartment(CreateDepartment request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpGet("ListDepartments")]
    public async Task<IActionResult> ListDepartments()
    {
        var result = await Mediator.Send(new Departments());
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpGet("ListManagers")]
    public async Task<IActionResult> ListManagers()
    {
        var result = await Mediator.Send(new Managers());
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpPut("UpdateDepartment")]
    public async Task<IActionResult> UpdateDepartment(UpdateDepartment request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
}