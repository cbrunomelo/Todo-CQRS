using Todo.Domain.Commands.TodoCommands.Inputs;
using Todo.Domain.Entitys;


namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    void Creat(Entitys.Todo todo);

    bool todoExist(string title, string email);

    bool IsMoreThanThreeTodoUndone(string email);

    Todo.Domain.Entitys.Todo GetByTitle(string title, string email);
    void Update(Entitys.Todo todo, string newTitle);
    void Update(MarkTodoAsUndoneCommand command);
    void Update(MarkTodoAsDoneCommand command);

    List<Todo.Domain.Entitys.Todo> GetAll(string email);







}