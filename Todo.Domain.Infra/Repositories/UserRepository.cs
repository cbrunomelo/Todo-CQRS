using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entitys;
using Todo.Domain.Infra.Data;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TodoDataContext _context;
    public UserRepository(TodoDataContext context)
    {
        _context = context;
    }
    public void Creat(User user)
    {
        user.Hasher(); // hashear senha antes de salvar
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void DefaultRole(User user)
    {
        UserRole userRole = new UserRole();
        userRole.UserEmail = user.Email;
        userRole.RoleName = "default";
        _context.UsersRoles.Add(userRole);
        _context.SaveChanges();
    }

    public bool EmailAldedyInUse(string email)
    {
        var userWhithThisEmail = _context.Users.FirstOrDefault(x => x.Email == email);
        if (userWhithThisEmail is null)
            return false;
        return true;
    }

    public User GetUser(string email)
    {
        return _context.Users
                .AsNoTracking()
                .Include(x => x.UserRoles)
                .FirstOrDefault(x => x.Email == email);
    }
}
