
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data
{
    public class AcademiaContext : DbContext
    {
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Modulo> Modulos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public AcademiaContext()
        {
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

                entity.HasData(
                    new { Id = 1, Descripcion = "Chef" },
                    new { Id = 2, Descripcion = "Matematico" },
                    new { Id = 3, Descripcion = "Programador" },
                    new { Id = 4, Descripcion = "Diseñador" }
                    );

            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(100);

                entity.HasData(
                    new { Id = 1, Descripcion = "modulo1" },
                    new { Id = 2, Descripcion = "modulo 2" },
                    new { Id = 3, Descripcion = "modulo 3" },
                    new { Id = 4, Descripcion = "modulo 4" }
                    );

            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(50);
                entity.Property(e => e.NombreUsuario).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Clave).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Habilitado).HasDefaultValue(true);
                entity.Property(e => e.FechaAlta).IsRequired();
                entity.Property(e => e.Salt).IsRequired().HasMaxLength(255);

                entity.HasIndex(e => e.NombreUsuario).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();

            });
        }

    }
}
