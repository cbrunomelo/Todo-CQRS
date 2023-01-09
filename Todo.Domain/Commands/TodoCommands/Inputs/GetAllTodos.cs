using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands.TodoCommands.Inputs;

public class GetAllTodos : ICommand
{
    public string Email { get; set; }

    public void Validate()
    {
        
    }
}