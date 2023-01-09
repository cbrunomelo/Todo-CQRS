using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entitys;
using Todo.Domain.Infra.Data.Mappings;

namespace Todo.Domain.Infra.Data;


public class TodoDataContext : DbContext
{
    public DbSet<Todo.Domain.Entitys.Todo> Todos { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserRole> UsersRoles { get; set; }


    public DbSet<Role> Roles { get; set; }


    public TodoDataContext(DbContextOptions<TodoDataContext> options)
      : base(options)
    {
    }



    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlite("DataSource=app.db;Cache=Shared;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new UserRoleMap());
        modelBuilder.ApplyConfiguration(new RoleMap());






    }
}