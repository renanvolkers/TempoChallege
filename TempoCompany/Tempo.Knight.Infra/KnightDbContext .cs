using Microsoft.EntityFrameworkCore;


namespace Tempo.Knight.Infra
{
    /// <summary>
    /// model configurations, and ensure that the service registration and connection strings are correctly configuredg
    /// </summary>
    public class KnightDbContext : DbContext
    {
        public KnightDbContext(DbContextOptions<KnightDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Model.Knight> Knights { get; set; }
        public DbSet<Domain.Model.Attribute> Attributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Model.Knight>().ToTable("Knights");
            modelBuilder.Entity<Domain.Model.Attribute>().ToTable("Attributes");
        }
    }
}
