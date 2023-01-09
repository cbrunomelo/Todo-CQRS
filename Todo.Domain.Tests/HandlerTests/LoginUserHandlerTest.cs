
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.UserCommands.Inputs;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;
using Todo.Domain.Tests.Services;

namespace Todo.Domain.Tests.HandlerTest;

[TestClass]
public class LoginUserHandlerTest
{

    private readonly LoginUserCommand _InvalidEmail = new LoginUserCommand("teste", "1234");
    private readonly LoginUserCommand _InvalidPassword = new LoginUserCommand("mail.com", "1234");

    private readonly LoginUserCommand _ValidCommand = new LoginUserCommand("mail.com", "hash-senha");
    // fake dependencias
    private readonly UserHandler handler = new UserHandler(new FakeUserRepository(), new TokenService());





    [TestMethod]
    public void Invalid_When_User_Null()
    {
        var result = (GenericCommandResult)handler.Handle(_InvalidEmail);
        Assert.AreEqual(result.Success, false);
    }


    [TestMethod]
    public void Invalid_When_Password_Incorrect()
    {
        var result = (GenericCommandResult)handler.Handle(_InvalidPassword);
        Assert.AreEqual(result.Success, false);
    }


    [TestMethod]
    public void Valid_when_both_correct()
    {
        var result = (GenericCommandResult)handler.Handle(_ValidCommand);
        Assert.AreEqual(result.Success, true);
    }





}