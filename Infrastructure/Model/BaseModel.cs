namespace Infrastructure.Model
{
    public class BaseModel(Guid? id = null)
    {
        public Guid Id { get; private set; } = id ?? Guid.NewGuid();
    }
}
