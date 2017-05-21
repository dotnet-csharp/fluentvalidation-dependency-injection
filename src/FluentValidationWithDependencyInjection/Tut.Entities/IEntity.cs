namespace Tut.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}