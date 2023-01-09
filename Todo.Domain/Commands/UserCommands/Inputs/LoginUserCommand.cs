using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands.UserCommands.Inputs;

public class LoginUserCommand : ICommand
{
    public LoginUserCommand()
    {

    }
    public string Password { get; set; }

    public string Email { get; set; }

    public LoginUserCommand(string email, string password)
    {
        Password = password;
        Email = email;
    }

    public void Validate()
    {

    }
}