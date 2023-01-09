using Flunt.Notifications;
using SecureIdentity.Password;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.TodoCommands.Inputs;
using Todo.Domain.Commands.UserCommands.Inputs;
using Todo.Domain.Entitys;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;
using Todo.Domain.Services;

namespace Todo.Domain.Handlers;


public class UserHandler : Notifiable,
                            IHandler<CreateUserCommand>

{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;


    public UserHandler(
        IUserRepository userRepository,
        ITokenService tokenService
    )
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }
    public ICommandResult Handle(CreateUserCommand command)
    {
        // Verificar command
        command.Validate();

        if (command.Invalid)
            return new GenericCommandResult(false, "Command invalido", command.Notifications);


        //verificar se User ja existe
        if (_userRepository.EmailAldedyInUse(command.Email))
            return new GenericCommandResult(false, "Email ja em uso", command.Email);


        //gerar usuario
        var user = new User(command.Email, command.Name, command.PasswordHash);

        //salvar user e hasehar senha
        _userRepository.Creat(user);


        //novo usuario sempre com role default
        _userRepository.DefaultRole(user);

        //retonar msg ao usuario

        return new GenericCommandResult(true, "Usuario criado com sucesso", new { command.Name, command.Email });
    }

    public ICommandResult Handle(LoginUserCommand command)
    {


        //encontrar usuario por email
        User user = _userRepository.GetUser(command.Email);
        if (user is null)
            return new GenericCommandResult(false, "Usuário ou senha inválida", command);


        //verificar se a senha esta correta
        if (!PasswordHasher.Verify(user.PasswordHash, command.Password))
            return new GenericCommandResult(false, "Usuário ou senha inválida", command);


        //gerar token

        string token = _tokenService.GenerateToken(user);

        //retornar o token
        return new GenericCommandResult(true, "Usuario logado", token);

    }



}