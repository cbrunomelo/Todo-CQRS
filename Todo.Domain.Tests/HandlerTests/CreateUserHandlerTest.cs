
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.UserCommands.Inputs;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;
using Todo.Domain.Tests.Services;

namespace Todo.Domain.Tests.HandlerTest;

[TestClass]
public class CreateUserHandlerTest
{
    private readonly CreateUserCommand _invalidCommandName = new CreateUserCommand("bruno2", "email@mail.com", "1234");
    private readonly CreateUserCommand _invalidCommandEmail = new CreateUserCommand("bruno", "email", "1234");
    private readonly CreateUserCommand _validCommand = new CreateUserCommand("bruno", "email@mail.com", "1234");
    private readonly CreateUserCommand _InvalidCommandEmainInUse = new CreateUserCommand("bruno", "bat@mail.com", "1234");

    // fake dependencias
    private readonly UserHandler handler = new UserHandler(new FakeUserRepository(), new TokenService());





    [TestMethod]
    public void Invalid_Name_Command_Should_Return_Invalid()
    {
        var result = (GenericCommandResult)handler.Handle(_invalidCommandName);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void Invalid_Email_Command_Should_Return_Invalid()
    {
        var result = (GenericCommandResult)handler.Handle(_invalidCommandEmail);
        Assert.AreEqual(result.Success, false);
    }



    [TestMethod]
    public void valid_Command_Should_Return_valid()
    {
        var result = (GenericCommandResult)handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }


    [TestMethod]
    public void Email_in_Use_Return_Invalid()
    {
        var result = (GenericCommandResult)handler.Handle(_InvalidCommandEmainInUse);
        Assert.AreEqual(result.Success, false);
    }







}