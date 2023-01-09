using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.TodoCommands.Inputs;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTest;


[TestClass]

public class CreateTodoHandlerTest
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("title2", "email@mail.com");
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("title", "email@mail.com");
    private readonly CreateTodoCommand _validCommandButUserWithManyTasks = new CreateTodoCommand("title", "mail@mail.com");
    private readonly CreateTodoCommand _invalidCommandTodoAlderyExistForThisUser = new CreateTodoCommand("ir ao mercado", "bruno@mail.com");
    private readonly TodoHandler handler = new TodoHandler(new FakeTodoRepository());

    [TestMethod]
    public void Invalid_when_command_inavlid()
    {
        var result = (GenericCommandResult)handler.Handle(_invalidCommand);


        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void Invalid_when_Is_equal_or_more_than_three_taks_undone()
    {

        var result = (GenericCommandResult)handler.Handle(_validCommandButUserWithManyTasks);

        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void Invalid_Todo_Aldery_exist()
    {
        var result = (GenericCommandResult)handler.Handle(_invalidCommandTodoAlderyExistForThisUser);

        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void valid_when_command_valid()
    {
        var result = (GenericCommandResult)handler.Handle(_validCommand);

        Assert.AreEqual(result.Success, true);


    }

}

[TestClass]

public class MarkTodoAsDoneHandlerTest
{
    private readonly MarkTodoAsDoneCommand _invalidCommand = new MarkTodoAsDoneCommand("title2", "email@mail.com");
    private readonly MarkTodoAsDoneCommand _validCommand = new MarkTodoAsDoneCommand("ir ao mercado", "bruno@mail.com");
    private readonly MarkTodoAsDoneCommand _InvalidCommandTaskDoNotExist = new MarkTodoAsDoneCommand("ir a academia", "bruno@mail.com");
    private readonly TodoHandler handler = new TodoHandler(new FakeTodoRepository());

    [TestMethod]
    public void Invalid_when_command_inavlid()
    {
        var result = (GenericCommandResult)handler.Handle(_invalidCommand);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void valid_when_task_exist()
    {

        var result = (GenericCommandResult)handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }

    [TestMethod]
    public void Invalid_when_task_do_not_exist()
    {

        var result = (GenericCommandResult)handler.Handle(_InvalidCommandTaskDoNotExist);
        Assert.AreEqual(result.Success, false);
    }
}



[TestClass]
public class ChangeTodoTitleTest
{
    private readonly ChangeTitleTodoCommand _invalidCommandNewTitle = new ChangeTitleTodoCommand("ir ao mercado", "bruno@mail.com", "2p");
    private readonly ChangeTitleTodoCommand _validCommand = new ChangeTitleTodoCommand("ir ao mercado", "bruno@mail.com", "Ir a academia");
    private readonly ChangeTitleTodoCommand _InvalidCommandTaskDoNotExist = new ChangeTitleTodoCommand("ir a academia", "bruno@mail.com", "ir ao mercado");

    private readonly ChangeTitleTodoCommand _InvalidCommandNewTitleTaskInUse = new ChangeTitleTodoCommand("ir ao mercado", "bruno@mail.com", "ir ao mercado");



    private readonly TodoHandler handler = new TodoHandler(new FakeTodoRepository());

    [TestMethod]
    public void Invalid_when_command_inavlid()
    {
        var result = (GenericCommandResult)handler.Handle(_invalidCommandNewTitle);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void valid_when_task_exist_and_newTitle_correct()
    {

        var result = (GenericCommandResult)handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }

    [TestMethod]
    public void Invalid_when_task_do_not_exist()
    {

        var result = (GenericCommandResult)handler.Handle(_InvalidCommandTaskDoNotExist);
        Assert.AreEqual(result.Success, false);
    }



    [TestMethod]
    public void Invalid_when_New_title_in_Use()
    {

        var result = (GenericCommandResult)handler.Handle(_InvalidCommandNewTitleTaskInUse);
        Assert.AreEqual(result.Success, false);
    }




}
