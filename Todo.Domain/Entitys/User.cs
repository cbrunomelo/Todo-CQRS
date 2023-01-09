using SecureIdentity.Password;

namespace Todo.Domain.Entitys;

public class User : IEquatable<User>
{
    private readonly IList<Todo> _Todos;
    public User(string email, string name, string passwordHash)
    {
        Email = email;
        Name = name;
        PasswordHash = passwordHash;

    }


    public string Email { get; private set; }

    public string Name { get; private set; }

    public string PasswordHash { get; private set; }

    public List<UserRole> UserRoles { get; set; }



    public IReadOnlyCollection<Todo> Todos => _Todos.ToArray();

    public bool Equals(User? other)
    {

        return Email == other.Email;
    }



    public void ChangeName(string name)
    {
        Name = name;
    }

    public void AddTodo(Todo todo)
    {
        _Todos.Add(todo);
    }

    public void Hasher()
    {
        PasswordHash = PasswordHasher.Hash(PasswordHash);
    }
}