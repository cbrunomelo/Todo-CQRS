using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;


namespace Todo.Domain.Commands.UserCommands.Inputs;

public class CreateUserCommand : Notifiable, ICommand
{

    public CreateUserCommand()
    {

    }
    public CreateUserCommand(string name, string email, string password)
    {
        Name = name;
        Email = email;
        PasswordHash = password;

    }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }




    public void Validate()
    {

        if (Name is null)
        {
            AddNotification("Name", "O campo nome deve ser preenchido");
            return;
        }


        AddNotifications(
            new Contract()
            .Requires()
            .IsEmail(Email, "Email", "E-mail inválido")
            .HasMinLen(Name, 3, "Name", "Nome deve conter mais de 3 caracteres")
            .HasMaxLen(Name, 20, "Name", "Nome deve conter no máximo 20 caracteres")


        );

        AddNotifications(
          new Contract()
              .Requires()
              .HasMinLen(PasswordHash, 3, "Senha", "Senha deve conter mais de 3 caracteres")
              .HasMaxLen(PasswordHash, 20, "Senha", "Senha deve conter no máximo 20 caracteres")


);

        if (!(Name.ToLower().All("abcdefghijklmnopqrstuvwxyz ".Contains)))
        {
            AddNotification("Name", "O nome deve conter apenas letras do alfabeto, sem caracteres especiais");
        }



    }
}



