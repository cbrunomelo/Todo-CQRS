using Todo.Domain.Entitys;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeUserRepository : IUserRepository
{
    public bool EmailAldedyInUse(string email)
    {
        string emailInUse = "bat@mail.com";
        if (email == emailInUse)
            return true;
        return false;
    }

    public void Creat(User user)
    {

    }

    public User GetUser(string email)
    {
        if (email == "mail.com")
            // hash para senha hash-senha
            return new User("mail.com", "teste", "10000.qI1YZyeYmNrlAzLepvx2IQ==.zpVIv8mY+ExmOFwRr36fhvX6OfaF6Jb7DPulFJDYXO8=");
        return null;
    }

    public void DefaultRole(User user)
    {
        
    }
}