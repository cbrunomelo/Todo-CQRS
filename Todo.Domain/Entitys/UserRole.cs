namespace Todo.Domain.Entitys;

public class UserRole
{
    public string RoleName { get; set; }

    public string UserEmail { get; set; }



    //navegação ef
    public User User { get; set; }

    public Role Role { get; set; }
}