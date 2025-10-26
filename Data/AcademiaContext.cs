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
        public DbSet<Profesor_Curso> Profesor_Cursos { get; set; }
        public DbSet<Alumno_Curso> Alumno_Cursos { get; set; }

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
                    new { Id = 2, Descripcion = "Diseñador de interiores" },
                    new { Id = 3, Descripcion = "Ingeniería en Sistemas" }
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
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();

                entity.HasData(new { IdPlan = 1, Descripcion = "Plan Basico", IdEspecialidad = 1 },
                                new { IdPlan = 2, Descripcion = "Plan Familiar", IdEspecialidad = 2 },
                                new { IdPlan = 3, Descripcion = "Plan Premium", IdEspecialidad = 3 }
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
                entity.HasIndex(e => e.Legajo).IsUnique();

                entity.HasData(
                    //ADMINISTRADORES
                    new Usuario(1, "Romero", "123456", "gt@email.com", true, "Gabriel Tobías", "gtr", DateTime.Now, "Pasaje Lucia Miranda 3368", "3415605249", "admin", 00000, DateTime.Today, 3),
                    new Usuario(2, "Lurati", "123456", "i@email.com", true, "Ignacio", "luta", DateTime.Now, "Córdoba 5328", "3415581214", "admin", 00001, DateTime.Today, 3),
                    //ALUMNOS
                    new Usuario(3, "Romero", "123456", "jm@email.com", true, "Juan Manuel", "jmr", DateTime.Now, "Pasaje Lucia Miranda 3368", "3411234567", "alumno", 10001 , DateTime.Today, 2),
                    new Usuario(4, "Romero", "123456", "mf@email.com", true, "Maria Florencia", "mfr", DateTime.Now, "Pasaje Lucia Miranda 3368", "3411234557", "alumno", 10002, DateTime.Today, 3),
                    new Usuario(5, "Gómez", "123456", "ana.gomez@email.com", true, "Ana Lucía", "anag", DateTime.Now.AddMonths(-5), "Av. Libertad 4500", "3412233445", "alumno", 10003, new DateTime(1985, 3, 10), 1),
                    new Usuario(6, "Pérez", "123456", "carlos.p@email.com", true, "Carlos Javier", "carlosj", DateTime.Now.AddMonths(-1), "Las Heras 120", "3413344556", "alumno", 10004, new DateTime(2000, 7, 20), 2),
                    new Usuario(7, "López", "123456", "sofia.l@email.com", true, "Sofía Elena", "sofiel", DateTime.Now.AddMonths(-8), "Mendoza 2500", "3414455667", "alumno", 10005, new DateTime(2001, 1, 15), 3),
                    //PROFESORES
                    new Usuario(8, "Díaz", "123456", "martin.d@email.com", true, "Martín Alejandro", "martind", DateTime.Now.AddMonths(-12), "San Martín 150", "3415566778", "profesor", 20007, new DateTime(1978, 11, 1), 1),
                    new Usuario(9, "Sánchez", "123456", "luis.s@email.com", true, "Luis Alberto", "luisal", DateTime.Now.AddMonths(-3), "9 de Julio 800", "3416677889", "profesor", 20008, new DateTime(1999, 9, 25), 2),
                    new Usuario(10, "Rodríguez", "123456", "eva.r@email.com", true, "Eva María", "evar", DateTime.Now.AddMonths(-6), "Córdoba 900", "3417788990", "profesor", 20009, new DateTime(1982, 4, 30), 3)
                    );
            });


            modelBuilder.Entity<Comision>(entity =>
                {
                    entity.HasKey(c => c.Id_comision);
                    entity.Property(c => c.Id_comision).ValueGeneratedOnAdd();
                    entity.Property(c => c.Desc_comision).IsRequired().HasMaxLength(50);
                    entity.HasIndex(c => c.Desc_comision).IsUnique();
                    entity.Property(c => c.Anio_especialidad).IsRequired();  //no tengo ni idea a que se refiere
                    entity.Property(c => c.Habilitado).HasDefaultValue(true);
                    entity.HasOne<Plan>()
                          .WithMany()
                          .HasForeignKey(c => c.Id_plan)
                          .OnDelete(DeleteBehavior.Restrict)
                          .IsRequired();

                    entity.HasData(
                        new { Id_comision = 1, Desc_comision = "Comision A", Anio_especialidad = 1, Id_plan = 1, Habilitado = true },
                        new { Id_comision = 2, Desc_comision = "Comision B", Anio_especialidad = 2, Id_plan = 1, Habilitado = true },
                        new { Id_comision = 3, Desc_comision = "Comision C", Anio_especialidad = 1, Id_plan = 2, Habilitado = true },
                        new { Id_comision = 4, Desc_comision = "Comision D", Anio_especialidad = 3, Id_plan = 2, Habilitado = true },
                        new { Id_comision = 5, Desc_comision = "Comision E", Anio_especialidad = 2, Id_plan = 3, Habilitado = true },
                        new { Id_comision = 6, Desc_comision = "Comision F", Anio_especialidad = 1, Id_plan = 3, Habilitado = true }
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
                entity.Property(m => m.Habilitado).HasDefaultValue(true);
                entity.HasOne<Plan>()
                      .WithMany()
                      .HasForeignKey(m => m.Id_plan)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();

                entity.HasData(
                    new { Id_materia = 1, Desc_materia = "Análisis Matemático", Hs_semanales = 4, Hs_totales = 64, Id_plan = 3, Habilitado = true },
                    new { Id_materia = 2, Desc_materia = "Desarrollo Web", Hs_semanales = 6, Hs_totales = 96, Id_plan = 3, Habilitado = true },
                    new { Id_materia = 3, Desc_materia = "Diseño de Sistemas", Hs_semanales = 2, Hs_totales = 32, Id_plan = 3, Habilitado = true },
                    new { Id_materia = 4, Desc_materia = "Dibujo Técnico", Hs_semanales = 3, Hs_totales = 48, Id_plan = 2, Habilitado = true },
                    new { Id_materia = 5, Desc_materia = "Colores", Hs_semanales = 3, Hs_totales = 48, Id_plan = 2, Habilitado = true },
                    new { Id_materia = 6, Desc_materia = "Materiales", Hs_semanales = 3, Hs_totales = 48, Id_plan = 2, Habilitado = true },
                    new { Id_materia = 7, Desc_materia = "Mesa Dulce", Hs_semanales = 5, Hs_totales = 80, Id_plan = 1, Habilitado = true },
                    new { Id_materia = 8, Desc_materia = "Comida fría", Hs_semanales = 5, Hs_totales = 80, Id_plan = 1, Habilitado = true },
                    new { Id_materia = 9, Desc_materia = "Parrilla", Hs_semanales = 2, Hs_totales = 32, Id_plan = 1, Habilitado = true }
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
                entity.Property(e => e.Habilitado).HasDefaultValue(true);
                entity.HasOne<Materia>()
                .WithMany()
                .HasForeignKey(c => c.Id_materia)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
                entity.HasOne<Comision>()
                .WithMany()
                .HasForeignKey(c => c.Id_comision)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
                entity.HasData(
                    new Curso { Id_curso = 1, Anio_calendario = 2023, Cupo = 30, Id_comision = 1, Id_materia = 1 },
                    new Curso { Id_curso = 2, Anio_calendario = 2023, Cupo = 25, Id_comision = 2, Id_materia = 2 },
                    new Curso { Id_curso = 3, Anio_calendario = 2023, Cupo = 20, Id_comision = 3, Id_materia = 3 },
                    new Curso { Id_curso = 4, Anio_calendario = 2024, Cupo = 35, Id_comision = 4, Id_materia = 4 },
                    new Curso { Id_curso = 5, Anio_calendario = 2024, Cupo = 28, Id_comision = 5, Id_materia = 5 },
                    new Curso { Id_curso = 6, Anio_calendario = 2023, Cupo = 18, Id_comision = 6, Id_materia = 6 },
                    new Curso { Id_curso = 7, Anio_calendario = 2024, Cupo = 22, Id_comision = 1, Id_materia = 7 },
                    new Curso { Id_curso = 8, Anio_calendario = 2023, Cupo = 30, Id_comision = 2, Id_materia = 8 },
                    new Curso { Id_curso = 9, Anio_calendario = 2024, Cupo = 25, Id_comision = 3, Id_materia = 9 }
                    );

            });

            modelBuilder.Entity<Profesor_Curso>(entity =>
            {
                entity.HasKey(pc => pc.IdDictado );

                entity.Property(e => e.IdDictado).ValueGeneratedOnAdd();

                entity.HasOne<Usuario>()
                      .WithMany()
                      .HasForeignKey(pc => pc.IdProfesor)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();

                entity.HasOne<Curso>()
                      .WithMany()
                      .HasForeignKey(pc => pc.IdCurso)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();

                entity.HasIndex(pc => new { pc.IdProfesor, pc.IdCurso }).IsUnique();

                entity.Property(pc => pc.Cargo).IsRequired();

                entity.HasData(
                    new { IdDictado = 1, IdProfesor = 8, IdCurso = 1, Cargo = "Titular" },
                    new { IdDictado = 2, IdProfesor = 9, IdCurso = 2, Cargo = "Titular" },
                    new { IdDictado = 3, IdProfesor = 10, IdCurso = 3, Cargo = "Titular" },
                    new { IdDictado = 4, IdProfesor = 8, IdCurso = 4, Cargo = "Auxiliar" },
                    new { IdDictado = 5, IdProfesor = 9, IdCurso = 5, Cargo = "Auxiliar" },
                    new { IdDictado = 6, IdProfesor = 10, IdCurso = 6, Cargo = "Auxiliar" }
                    );
            });

            modelBuilder.Entity<Alumno_Curso>(entity =>
            {
                entity.HasKey(ac => ac.IdInscripcion);
                entity.Property(e => e.IdInscripcion).ValueGeneratedOnAdd();

                entity.HasOne<Usuario>()
                      .WithMany()
                      .HasForeignKey(ac => ac.IdAlumno)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();

                entity.HasOne<Curso>()
                      .WithMany()
                      .HasForeignKey(ac => ac.IdCurso)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();

                entity.HasIndex(ac => new { ac.IdAlumno, ac.IdCurso }).IsUnique();
                entity.Property(ac => ac.Condicion).IsRequired();
                entity.Property(ac => ac.Nota).IsRequired(false);

                entity.HasData(
                    new { IdInscripcion = 1, IdAlumno = 3, IdCurso = 1, Condicion = "Regular", Nota = 8 },
                    new { IdInscripcion = 2, IdAlumno = 4, IdCurso = 2, Condicion = "Aprobado", Nota = 9 },
                    new { IdInscripcion = 3, IdAlumno = 5, IdCurso = 3, Condicion = "Libre", Nota = (int?)null },
                    new { IdInscripcion = 4, IdAlumno = 6, IdCurso = 4, Condicion = "Regular", Nota = 7 },
                    new { IdInscripcion = 5, IdAlumno = 7, IdCurso = 5, Condicion = "Aprobado", Nota = 8 },
                    new { IdInscripcion = 6, IdAlumno = 3, IdCurso = 6, Condicion = "Libre", Nota = (int?)null },
                    new { IdInscripcion = 7, IdAlumno = 4, IdCurso = 7, Condicion = "Regular", Nota = 8 },
                    new { IdInscripcion = 8, IdAlumno = 5, IdCurso = 8, Condicion = "Aprobado", Nota = 9 }
                    );
            });
        }
    }
}
    
