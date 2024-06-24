namespace Tempo.Common.Setup.Repository
{
    public  interface IEntity<T> :IAuditInfo
    {
        public  T Id { get; set; }

    }
}
