using Application.Features.Tasks.Commands;
using Application.Features.Tasks.Queries;

namespace API.Controllers;

[Authorize(Roles = "Employee")]
public class EmployeeController : AbstractController
{
    public EmployeeController(IMediator mediator) : base(mediator) {}
    
    [HttpGet("MyTasks")]
    public async Task<IActionResult> MyTasks()
    {
        var result = await Mediator.Send(new EmployeeTasks());
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpPut("MarkTaskAsCompleted")]
    public async Task<IActionResult> MarkTaskAsCompleted(MarkTaskCompleted request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
}