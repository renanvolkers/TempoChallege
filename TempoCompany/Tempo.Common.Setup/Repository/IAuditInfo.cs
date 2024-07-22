namespace Tempo.Common.Setup.Repository
{
    public interface IAuditInfo
    {
        public  string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
