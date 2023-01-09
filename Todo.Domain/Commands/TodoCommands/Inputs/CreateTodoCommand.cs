using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;


namespace Todo.Domain.Commands.TodoCommands.Inputs;

public class CreateTodoCommand : Notifiable, ICommand
{
    public CreateTodoCommand()
    {

    }
    public CreateTodoCommand(string title, string email)
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
            .HasMinLen(Title, 2, "Title", "Por favor, descreva melhor esta tarefa!")
            .HasMaxLen(Title, 30, "Title", "Titulo muito grande")

                );

        if (!Title.ToLower().All("abcdefghijklmnopqrstuvwxyz ".Contains))
        {
            AddNotification("Title", "O titulo deve conter apenas letras do alfabeto, sem caracteres especiais");
        }

    }
}



