namespace Todo.Domain.Entitys;

public abstract class EntityBase : IEquatable<EntityBase>
{
    public Guid Id { get; private set; }
    public EntityBase()
    {
        Id = Guid.NewGuid();
    }

    public bool Equals(EntityBase? other)
    {
        return Id == other.Id;
    }
}