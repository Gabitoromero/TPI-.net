
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;


namespace Data
{
    public class AcademiaContext : DbContext
    {
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Plan> Planes { get; set; }

        public AcademiaContext()
        {
            //this.Database.EnsureCreated();
            // Descomentar para RESETEAR la base de datos en cada ejecucion (solo en desarrollo)    
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Descripcion).IsUnique();

                entity.HasData(
                    new { Id = 1, Descripcion = "Chef"}, 
                    new {Id = 2, Descripcion = "Matematico"},
                    new {Id = 3, Descripcion = "Programador" },
                    new {Id = 4, Descripcion = "Diseñador" }
                    );

            });
            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Descripcion).IsUnique();

                entity.HasData(
                    new { Id = 1, Descripcion = "modulo1"}, 
                    new {Id = 2, Descripcion = "modulo 2"},
                    new {Id = 3, Descripcion = "modulo 3" },
                    new {Id = 4, Descripcion = "modulo 4" }
                    );

            });
            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.IdPlan);
                entity.Property(e => e.IdPlan).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Descripcion).IsUnique();
                entity.HasOne<Especialidad>()
                      .WithMany()
                      .HasForeignKey(e => e.IdEspecialidad)
                      .OnDelete(DeleteBehavior.ClientNoAction)//validar con luta
                      .IsRequired(); 

                entity.HasData( new { IdPlan = 1, Descripcion = "Plan Basico", IdEspecialidad = 1 },
                                new { IdPlan = 2, Descripcion = "Plan Premium", IdEspecialidad = 2 },
                                new { IdPlan = 3, Descripcion = "Plan Familiar", IdEspecialidad = 3 }
                              );
            });
        }
    }
 
}
