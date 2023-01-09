using Todo.Domain.Entitys;

namespace Todo.Domain.Services;

public interface ITokenService
{
    public string GenerateToken(User user);
}