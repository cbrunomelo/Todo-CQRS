using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands.TodoCommands.Inputs;

public class MarkTodoAsUndoneCommand : Notifiable, ICommand
{
    public MarkTodoAsUndoneCommand()
    {

    }
    public MarkTodoAsUndoneCommand(string title, string email)
    {
        Title = title;
        Email = email;
    }

    public string Title { get; set; }

    public string Email { get; set; }
    public void Validate()
    {
        AddNotifications(
    new Contract()
    .Requires()
    .IsEmail(Email, "Email", "E-mail inválido")
    .HasMinLen(Title, 2, "Title", "Por favor, descreva melhor esta tarefa!")
    .HasMaxLen(Title, 30, "Title", "Titulo muito grande")


);

    }
}