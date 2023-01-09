
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands.TodoCommands.Inputs;


public class ChangeTitleTodoCommand : Notifiable, ICommand
{
    public ChangeTitleTodoCommand()
    {

    }
    public ChangeTitleTodoCommand(string Oldtitle, string email, string newTitle)
    {
        Title = Oldtitle;
        Email = email;
        NewTitle = newTitle;

    }

    public string Title { get; set; }
    public string Email { get; set; }

    public string NewTitle { get; set; }




    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(NewTitle, 2, "Title", "Por favor, descreva melhor esta tarefa!")
            .HasMaxLen(NewTitle, 30, "Title", "Titulo muito grande")

                );

        if (!NewTitle.ToLower().All("abcdefghijklmnopqrstuvwxyz ".Contains))
        {
            AddNotification("NewTitle", "O titulo deve conter apenas letras do alfabeto, sem caracteres especiais");
        }

    }
}