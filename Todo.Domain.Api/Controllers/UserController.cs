using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.UserCommands.Inputs;
using Todo.Domain.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1/users")]
public class UserController : ControllerBase
{
    private readonly UserHandler _handler;

    public UserController(UserHandler handler)
    {
        _handler = handler;
    }


    [Authorize(Roles = "admin")]
    [Route("Get-All")]
    [HttpGet]
    public IActionResult GetAll(

        )
    {   
        

        return Ok("Hello World");
    }

    [Route("New-User")]
    [HttpPost]
    public ActionResult<GenericCommandResult> Create(
      [FromBody] CreateUserCommand command  )
    {

        var result = (GenericCommandResult)_handler.Handle(command);
        if (result.Success == false)
            return BadRequest(result);
        return Created("http/", result);
    }

    [Route("Login")]
    [HttpPost]
    public ActionResult<GenericCommandResult> Login(
  [FromBody] LoginUserCommand command)
    {

        var result = (GenericCommandResult)_handler.Handle(command);
        if (result.Success == false)
            return BadRequest(result);
        return Ok(result);
    }




}