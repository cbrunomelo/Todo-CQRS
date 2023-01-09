
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands.UserCommands.Inputs;

namespace Todo.Domain.Tests.CommandsTests;

[TestClass]
public class CreateUserCommandTest
{


    [TestMethod]
    public void Should_Invalid_When_Email_Not_In_Email_Format()
    {
        var command = new CreateUserCommand("Name", "email", "1234");
        command.Validate();

        Assert.AreEqual(command.Valid, false);
    }

    [TestMethod]
    public void Should_Invalid_When_Name_Contain_Special_Char()
    {
        var command = new CreateUserCommand("nome2", "emai@email.com", "1234");
        command.Validate();

        Assert.AreEqual(command.Valid, false);
    }

    [TestMethod]
    public void Should_valid_When_Name_Contain_Only_Alphabetic_Char_And_Email_in_email_format()
    {
        var command = new CreateUserCommand("nome", "emai@email.com", "11234");
        command.PasswordHash = "12345";
        command.Validate();

        Assert.AreEqual(command.Valid, true);
    }




}