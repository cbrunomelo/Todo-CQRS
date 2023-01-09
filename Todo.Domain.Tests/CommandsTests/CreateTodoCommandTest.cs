
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.TodoCommands.Inputs;

namespace Todo.Domain.Tests.CommandsTests;

[TestClass]
public class CreateTodoCommandTest
{
    [TestMethod]
    public void Should_Invalid_When_title_contain_special_char()
    {
        var command = new CreateTodoCommand("ir ao supermercado2 ", "email@teste.com");
        command.Validate();

        Assert.AreEqual(command.Valid, false);
    }

    [TestMethod]
    public void Should_valid_When_title_contain_only_Alphabetic_char()
    {
        var teste = new CreateTodoCommand("ir ao supermercado", "email@teste.com");
        teste.Validate();
        Assert.AreEqual(teste.Valid, true);
    }
}