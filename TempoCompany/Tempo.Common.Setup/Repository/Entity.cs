namespace Tempo.Common.Setup.Repository
{
    public class Entity<T> : IEntity<T>
    {
        public required T Id { get; set; }
    }
}
