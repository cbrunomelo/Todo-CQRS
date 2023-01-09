using System.Collections.Generic;
using Todo.Domain.Commands.TodoCommands.Inputs;
using Todo.Domain.Repositories;


namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{


    public void Creat(Entitys.Todo todo)
    {

    }

    public List<Entitys.Todo> GetAll(string email)
    {
        throw new System.NotImplementedException();
    }

    public Entitys.Todo GetByTitle(string title, string email)
    {
        string userMail = "bruno@mail.com";
        string todoAldedyExist = "ir ao mercado";
        if (title == todoAldedyExist && userMail == email)
            return new Entitys.Todo(title, email);
        return null;
    }

    public bool IsMoreThanThreeTodoUndone(string email)
    {
        if (email == "mail@mail.com")
            return true;
        return false;
    }


    public bool todoExist(string title, string email)
    {
        string userMail = "bruno@mail.com";
        string todoAldedyExist = "ir ao mercado";
        if (title == todoAldedyExist && userMail == email)
            return true;
        return false;
    }

    public void Update(Entitys.Todo todo)
    {

    }

    public void Update(ChangeTitleTodoCommand command)
    {

    }

    public void Update(MarkTodoAsUndoneCommand command)
    {

    }

    public void Update(MarkTodoAsDoneCommand command)
    {

    }

    public void Update(Entitys.Todo todo, string newTitle)
    {

    }
}