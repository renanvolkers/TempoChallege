using Microsoft.EntityFrameworkCore;
using Tempo.Knight.Domain.Model;


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
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<KnightAttribute> KnightAttributes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<KnightAttribute>()
                .HasKey(ka => new { ka.KnightId, ka.AttributeId });

            modelBuilder.Entity<Domain.Model.Knight>()
            .HasKey(ka => ka.Id);


            modelBuilder.Entity<Domain.Model.Knight>()
                .HasMany(k => k.Weapons)
                .WithOne(w => w.Knight)
                .HasForeignKey(w => w.KnightId);

            modelBuilder.Entity<Domain.Model.Knight>()
            .HasMany(k => k.KnightAttributes)
            .WithOne(w => w.Knight)
            .HasPrincipalKey(w => w.Id);

            modelBuilder.Entity<KnightAttribute>()
                .HasOne(ka => ka.Attribute)
                .WithOne(x=>x.KnightAttribute)
                .HasPrincipalKey<KnightAttribute>(w => w.AttributeId);


            modelBuilder.Entity<Domain.Model.Attribute>()
               .HasIndex(k => k.Name)
               .IsUnique();
        }
    }
}
