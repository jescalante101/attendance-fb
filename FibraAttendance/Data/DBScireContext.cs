using Entities.Entity;
using Entities.Entity.Scire;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Data
{
    public class DBScireContext: DbContext
    {
        public DBScireContext(DbContextOptions<DBScireContext> options) : base(options)
        {
        }

        public DbSet<PersonalEntity> Personales { get; set; }
        public DbSet<PersonalActivo> PersonalActivos { get; set; }
        public DbSet<CategoriaAuxiliar> CategoriaAuxiliar { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any additional model configurations here
            modelBuilder.Entity<PersonalActivo>()
            .HasKey(pa => new { pa.PersonalId, pa.CategoriaAuxiliarId });

            // (y las relaciones, como antes)
            modelBuilder.Entity<PersonalEntity>()
                .HasMany(p => p.PersonalActivos)
                .WithOne(pa => pa.Personal)
                .HasForeignKey(pa => pa.PersonalId);

            modelBuilder.Entity<CategoriaAuxiliar>()
                .HasMany(ca => ca.PersonalActivos)
                .WithOne(pa => pa.CategoriaAuxiliar)
                .HasForeignKey(pa => pa.CategoriaAuxiliarId);

            modelBuilder.Entity<PersonalEntity>().ToTable("Personal");

            base.OnModelCreating(modelBuilder);

        }

    }
    
}
