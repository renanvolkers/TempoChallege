namespace Tempo.Common.Setup.Repository
{
    public class AuditInfo : IAuditInfo
    {
        public required string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public AuditInfo() {
            ModifiedBy = string.Empty;
            ModifiedAt = DateTime.MinValue; 
        }

        public void SetCreationAudit(string userName)
        {
            CreatedBy = userName;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetModificationAudit(string userName)
        {
            ModifiedBy = userName;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}
