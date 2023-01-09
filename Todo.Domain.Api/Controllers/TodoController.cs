using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.TodoCommands.Inputs;
using Todo.Domain.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Authorize(Roles = "default")]
[Route("v1/todos")]

public class TodoController : ControllerBase
{

    private TodoHandler _handler;
    public TodoController(TodoHandler handler)
    {
        _handler = handler;
    }


    [Route("new-todo")]
    [HttpPost]
    public ActionResult<GenericCommandResult> Create(
      [FromBody] string title,
      [FromServices] TodoHandler handler
  )
    {
        CreateTodoCommand command = new CreateTodoCommand();
        command.Title = title;
        command.Email = User.Identity.Name;
        var result = (GenericCommandResult)handler.Handle(command);
        if (result.Success == false)
            return BadRequest(result);
        return Created("http/", result);
    }


    [Route("Change-Title")]
    [HttpPut]
    public ActionResult<GenericCommandResult> ChangeTitle(
             [FromBody] ChangeTitleTodoCommand command,
             [FromServices] TodoHandler handler
)
    {

        command.Email = User.Identity.Name;
        var result = (GenericCommandResult)handler.Handle(command);
        if (result.Success == false)
            return BadRequest(result);
        return Created("http/", result);
    }

    [Route("Mark-Done")]
    [HttpPut]
    public ActionResult<GenericCommandResult> MarkAsDone(
        [FromBody] MarkTodoAsDoneCommand command
        )
    {
        command.Email = User.Identity.Name;
        var result = (GenericCommandResult)_handler.Handle(command);
        if (result.Success == false)
            return BadRequest(result);
        return Ok(result);
    }

    [Route("Mark-Undone")]
    [HttpPut]
    public ActionResult<GenericCommandResult> MarkUndone(
    [FromBody] MarkTodoAsUndoneCommand command
    )
    {
        command.Email = User.Identity.Name;
        var result = (GenericCommandResult)_handler.Handle(command);
        if (result.Success == false)
            return BadRequest(result);
        return Ok(result);
    }


    [Route("All-Todos")]
    [HttpGet]
    public ActionResult<GenericCommandResult> AllTodos()
    {
        GetAllTodos command = new GetAllTodos();
        command.Email = User.Identity.Name;
        var result = (GenericCommandResult)_handler.Handle(command);
        if (result.Success == false)
            return BadRequest(result);
        return Ok(result);
    }



}