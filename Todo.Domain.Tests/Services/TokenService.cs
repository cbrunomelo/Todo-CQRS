using Todo.Domain.Entitys;
using Todo.Domain.Services;

namespace Todo.Domain.Tests.Services;


public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        return "Token-Gerado";
    }
}
