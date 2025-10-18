using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data
{
    public class AcademiaContext : DbContext
    {
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Plan> Planes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Materia> Materias { get; set; }

        public AcademiaContext()
        {
            //this.Database.EnsureCreated();
            // Descomentar para RESETEAR la base de datos en cada ejecucion (solo en desarrollo)    
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //configuracion de la base de datos
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

        protected override void OnModelCreating(ModelBuilder modelBuilder) //configuracion del modelo de datos
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Descripcion).IsUnique();

                entity.HasData(
                    new { Id = 1, Descripcion = "Chef" },
                    new { Id = 2, Descripcion = "Matematico" },
                    new { Id = 3, Descripcion = "Programador" },
                    new { Id = 4, Descripcion = "Diseñador" }
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
                      .OnDelete(DeleteBehavior.Restrict)//validar con luta
                      .IsRequired();

                entity.HasData(new { IdPlan = 1, Descripcion = "Plan Basico", IdEspecialidad = 1 },
                                new { IdPlan = 2, Descripcion = "Plan Premium", IdEspecialidad = 2 },
                                new { IdPlan = 3, Descripcion = "Plan Familiar", IdEspecialidad = 3 }
                              );
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(50);
                entity.Property(e => e.NombreUsuario).IsRequired().HasMaxLength(20);
                entity.Property(e => e.ClaveHash).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Habilitado).HasDefaultValue(true);
                entity.Property(e => e.FechaAlta).IsRequired();
                entity.Property(e => e.Salt).IsRequired().HasMaxLength(255);

                entity.Property(e => e.Direccion).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telefono).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Tipo).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Legajo).IsRequired();
                entity.Property(e => e.FechaNacimiento).IsRequired();

                entity.HasOne<Plan>()
                      .WithMany()
                      .HasForeignKey(e => e.IdPlan)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();

                entity.HasIndex(e => e.NombreUsuario).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();

                /* entity.HasData(
                     new Usuario(1, "Romero", "111111", "gt@email.com", true, "Gabriel Tobías", "gtr", DateTime.Now, "En algun lugar", "3413244309", "admin", 52699, DateTime.Today, 1),
             });*/
            });


            modelBuilder.Entity<Comision>(entity =>
                {
                    entity.HasKey(c => c.Id_comision);
                    entity.Property(c => c.Id_comision).ValueGeneratedOnAdd();
                    entity.Property(c => c.Desc_comision).IsRequired().HasMaxLength(50);
                    entity.HasIndex(c => c.Desc_comision).IsUnique();
                    entity.Property(c => c.Anio_especialidad).IsRequired();
                    entity.HasOne<Plan>()
                          .WithMany()
                          .HasForeignKey(c => c.Id_plan)
                          .OnDelete(DeleteBehavior.Restrict) //validar con luta
                          .IsRequired();

                    entity.HasData(
                        new { Id_comision = 1, Desc_comision = "Comision A", Anio_especialidad = 1, Id_plan = 1 },
                        new { Id_comision = 2, Desc_comision = "Comision B", Anio_especialidad = 2, Id_plan = 1 },
                        new { Id_comision = 3, Desc_comision = "Comision C", Anio_especialidad = 1, Id_plan = 2 },
                        new { Id_comision = 4, Desc_comision = "Comision D", Anio_especialidad = 3, Id_plan = 2 },
                        new { Id_comision = 5, Desc_comision = "Comision E", Anio_especialidad = 2, Id_plan = 3 }
                        );
                });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(m => m.Id_materia);
                entity.Property(m => m.Id_materia).ValueGeneratedOnAdd();
                entity.Property(m => m.Desc_materia).IsRequired().HasMaxLength(50);
                entity.HasIndex(m => m.Desc_materia).IsUnique();
                entity.Property(m => m.Hs_semanales).IsRequired();
                entity.Property(m => m.Hs_totales).IsRequired();
                entity.HasOne<Plan>()
                      .WithMany()
                      .HasForeignKey(m => m.Id_plan)
                      .OnDelete(DeleteBehavior.Restrict) //validar con luta
                      .IsRequired();

                entity.HasData(
                    new { Id_materia = 1, Desc_materia = "Matematica", Hs_semanales = 4, Hs_totales = 64, Id_plan = 1 },
                    new { Id_materia = 2, Desc_materia = "Programacion", Hs_semanales = 6, Hs_totales = 96, Id_plan = 1 },
                    new { Id_materia = 3, Desc_materia = "Diseño", Hs_semanales = 3, Hs_totales = 48, Id_plan = 2 },
                    new { Id_materia = 4, Desc_materia = "Quimica", Hs_semanales = 5, Hs_totales = 80, Id_plan = 2 },
                    new { Id_materia = 5, Desc_materia = "Historia", Hs_semanales = 2, Hs_totales = 32, Id_plan = 3 }
                    );
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Id_curso);
                entity.Property(e => e.Id_curso).ValueGeneratedOnAdd();
                entity.Property(e => e.Id_curso).IsRequired();
                entity.HasIndex(e => e.Id_curso).IsUnique();
                entity.Property(e => e.Anio_calendario).IsRequired();
                entity.Property(e => e.Cupo).IsRequired();
                entity.HasOne<Materia>()
                .WithMany()
                .HasForeignKey(c => c.Id_materia)
                .OnDelete(DeleteBehavior.Restrict) //validar con luta
                .IsRequired();
                entity.HasOne<Comision>()
                .WithMany()
                .HasForeignKey(c => c.Id_comision)
                .OnDelete(DeleteBehavior.Restrict) //validar con luta
                .IsRequired();
                entity.HasData(
                    new Curso { Id_curso = 1, Anio_calendario = 2023, Cupo = 30, Id_comision = 1, Id_materia = 1 },
                    new Curso { Id_curso = 2, Anio_calendario = 2023, Cupo = 25, Id_comision = 2, Id_materia = 2 },
                    new Curso { Id_curso = 3, Anio_calendario = 2023, Cupo = 20, Id_comision = 3, Id_materia = 3 }
                    );

            });
        }
    }
}
    
