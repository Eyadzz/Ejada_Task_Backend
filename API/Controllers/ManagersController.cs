using Application.Features.Departments.Commands;
using Application.Features.Departments.Queries;
using Application.Features.Tasks.Commands;
using Application.Features.Tasks.Queries;
using Application.Features.Users.Commands;

namespace API.Controllers;

[Authorize(Roles = "Manager")]
public class ManagersController : AbstractController
{
    public ManagersController(IMediator mediator) : base(mediator) {}
    
    [HttpPost("AddEmployee")]
    public async Task<IActionResult> AddEmployee(AddEmployee request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpPut("UpdateEmployee")]
    public async Task<IActionResult> UpdateEmployee(UpdateEmployee request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpDelete("DeleteEmployee")]
    public async Task<IActionResult> DeleteEmployee([FromQuery] DeleteEmployee request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpGet("DepartmentEmployees")]
    public async Task<IActionResult> DepartmentEmployees()
    {
        var result = await Mediator.Send(new DepartmentEmployees());
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpPost("AddTask")]
    public async Task<IActionResult> AddTask(CreateTask request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpPut("UpdateTask")]
    public async Task<IActionResult> UpdateTask(UpdateTask request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpDelete("DeleteTask")]
    public async Task<IActionResult> DeleteEmployee([FromQuery] DeleteTask request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpGet("EmployeeTasks")]
    public async Task<IActionResult> EmployeeTasks([FromQuery] EmployeeTasksForManager request)
    {
        var result = await Mediator.Send(request);
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpGet("ListAllTasks")]
    public async Task<IActionResult> ListAllTasks()
    {
        var result = await Mediator.Send(new ManagerCreatedTasks());
        return StatusCode(result.StatusCode, result);
    }
}