namespace Todo.Domain.Entitys;
public class Role
{

    public string Name { get; set; }


    //navegação ef
    public List<UserRole> UserRoles { get; set; }
}