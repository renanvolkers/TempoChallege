namespace Tempo.Common.Setup.Repository
{
    public class Entity<T> : AuditInfo, IEntity<T>
    {
        public required T Id { get; set; }
    }
}
