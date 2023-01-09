namespace Todo.Domain.Entitys;

public class Todo
{

    public string Title { get; private set; }

    public bool Done { get; private set; }


    public DateTime CreatedAt { get; private set; }

    public DateTime LastUpdate { get; private set; }

    public string Email { get; private set; }

    public Todo(string title, string email)
    {
        Title = title;
        Email = email;
        CreatedAt = DateTime.Now.ToUniversalTime();
        LastUpdate = DateTime.Now.ToUniversalTime();
        Done = false;
    }

    public void MarkAsDone()
    {
        Done = true;
        LastUpdate = DateTime.Now.ToUniversalTime();
    }

    public void MarkAsUndone()
    {
        Done = false;
        LastUpdate = DateTime.Now.ToUniversalTime();
    }




    public void ChangeTitle(string title)
    {
        Title = title;
        LastUpdate = DateTime.Now.ToUniversalTime();
    }


    // navegação ef


    public User User { get; private set; }



}