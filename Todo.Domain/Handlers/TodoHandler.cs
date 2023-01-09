using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.TodoCommands.Inputs;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;


public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
                                     , IHandler<MarkTodoAsDoneCommand>
{
    private readonly ITodoRepository _todoRepository;

    public TodoHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        // verificar command
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Command invalido", command.Notifications);


        //verificar se tarefa ja existe
        if (_todoRepository.todoExist(command.Title, command.Email))
            return new GenericCommandResult(false, "Tarefa ja existe", command.Notifications);


        // verificar se o usuario nao tem mais de 3 tarefas nao concluidas
        if (_todoRepository.IsMoreThanThreeTodoUndone(command.Email))
            return new GenericCommandResult(false, "Existem muitas tarefas incompletas", command.Notifications);

        //criar uma tarefa nova para o usuario

        Entitys.Todo newTodo = new Entitys.Todo(command.Title, command.Email);
        _todoRepository.Creat(newTodo);

        return new GenericCommandResult(true, "Tarefa registrada com sucesso", command);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        //verificar command
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Command invalido", command.Notifications);

        //verificar se todo existe no banco
        Entitys.Todo todo = _todoRepository.GetByTitle(command.Title, command.Email);
        if (todo == null)
            return new GenericCommandResult(false, "Essa tarefa não existe para esse usuário", command.Notifications);

        //marcar todo como concluido
        todo.MarkAsDone();

        _todoRepository.Update(command);


        return new GenericCommandResult(true, $"Tarefa {command.Title} alterada para concluída", command);
    }

    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        //verificar command
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Command invalido", command.Notifications);

        //verificar se todo existe no banco
        Entitys.Todo todo = _todoRepository.GetByTitle(command.Title, command.Email);
        if (todo == null)
            return new GenericCommandResult(false, "Essa tarefa não existe para esse usuário", command.Notifications);

        //marcar todo como nao concluido
        todo.MarkAsUndone();

        _todoRepository.Update(command);


        return new GenericCommandResult(true, $"Tarefa {command.Title} alterada para não concluída", command);
    }


    public ICommandResult Handle(ChangeTitleTodoCommand command)
    {
        //verificar command
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Command invalido", command.Notifications);

        //verificar se todo existe no banco
        Entitys.Todo todo = _todoRepository.GetByTitle(command.Title, command.Email);
        if (todo == null)
            return new GenericCommandResult(false, "Essa tarefa não existe para esse usuário", command.Notifications);

        //verificar se o user ja possui uma tarefa com o title novo
        Entitys.Todo newtodo = _todoRepository.GetByTitle(command.NewTitle, command.Email);
        if (newtodo is not null)
            return new GenericCommandResult(false, "Usuário ja possui tarefa com esse novo Titulo", command.Notifications);


        //mudar titulo no banco
        _todoRepository.Update(todo, command.NewTitle);


        return new GenericCommandResult(true, $"Tarefa {command.Title} alterada para {command.NewTitle}", command);
    }


    public ICommandResult Handle(GetAllTodos command)
    {
        //buscar tarefas no banco

        var todos = _todoRepository.GetAll(command.Email);


        return new GenericCommandResult(true, "Usuario logado", todos);
    }
}