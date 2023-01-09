using Microsoft.EntityFrameworkCore;
using Todo.Domain.Commands.TodoCommands.Inputs;
using Todo.Domain.Infra.Data;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private TodoDataContext _context;
    public TodoRepository(TodoDataContext context)
    {
        _context = context;
    }
    public void Creat(Entitys.Todo todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }


    public bool IsMoreThanThreeTodoUndone(string email)
    {
        var todos = _context.Todos.Where(x => x.Done == false);
        if (todos.Count() >= 3)
            return true;
        return false;
    }

    public bool todoExist(string title, string email)
    {
        var todo = _context.Todos.FirstOrDefault(x => x.Title == title && x.Email == email);
        if (todo is null)
            return false;
        return true;

    }


    public Entitys.Todo GetByTitle(string title, string email)
         => _context.Todos.FirstOrDefault(x => x.Email == email && x.Title == title);


    public void Update(Entitys.Todo todo, string newTitle)
    {
        _context.Todos.Remove(todo);
        _context.SaveChanges();


        todo.ChangeTitle(newTitle);
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public void Update(MarkTodoAsUndoneCommand command)
    {
        var todo = _context.Todos.FirstOrDefault(x => x.Title == command.Title && x.Email == command.Email);
        todo.ChangeTitle(command.Title);
        _context.Update(todo);
        _context.SaveChanges();
    }

    public void Update(MarkTodoAsDoneCommand command)
    {
        var todo = _context.Todos.FirstOrDefault(x => x.Title == command.Title && x.Email == command.Email);
        todo.ChangeTitle(command.Title);
        _context.Update(todo);
        _context.SaveChanges();
    }

    public List<Entitys.Todo> GetAll(string email)
    {
        var todos = _context.Todos
        .AsNoTracking()
        .Where(x => x.Email == email)
        .ToList();

        return todos;
    }
}
