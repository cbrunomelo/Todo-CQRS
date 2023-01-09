using Todo.Domain.Entitys;

namespace Todo.Domain.Repositories;

public interface IUserRepository
{
    void Creat(User user);

    bool EmailAldedyInUse(string email);

    User GetUser(string email);

    void DefaultRole(User user);
}