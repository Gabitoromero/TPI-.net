using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class InscripcionRepository
    {
        private readonly AcademiaContext _context;

        public InscripcionRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task<Profesor_Curso?> GetProfesorInsc(int idDictado) => await _context.Profesor_Cursos.FindAsync(idDictado);
        public async Task<List<Profesor_Curso>> GetAllProfesorInsc(int idProfesor) => await _context.Profesor_Cursos.Where(i => i.IdProfesor == idProfesor).ToListAsync();

        public async Task AddProfesorInsc(Profesor_Curso profesor_Curso)
        {

            await _context.Profesor_Cursos.AddAsync(profesor_Curso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesorInsc(int idDictado)
        {
            var existing = await _context.Profesor_Cursos.FirstOrDefaultAsync(pc => pc.IdDictado == idDictado);

            if (existing != null)
            {
                _context.Profesor_Cursos.Remove(existing);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("La inscripción no existe");
            }
        }

        public async Task UpdateProfesorInsc(Profesor_Curso profesor_Curso)
        {
            var existing = await _context.Profesor_Cursos.FirstOrDefaultAsync(pc => pc.IdDictado == profesor_Curso.IdDictado);
            if (existing != null)
            {
                existing.IdProfesor = profesor_Curso.IdProfesor;
                existing.IdCurso = profesor_Curso.IdCurso;
                existing.Cargo = profesor_Curso.Cargo;
                await _context.SaveChangesAsync();
            }
        }

        // Inscripciones de alumnos a cursos

        public async Task<List<Alumno_Curso>> GetAllAlumnoInsc(int idAlumno) => await _context.Alumno_Cursos.Where(i => i.IdAlumno == idAlumno).ToListAsync();

        public async Task AddAlumnoInsc(Alumno_Curso alumno_Curso)
        {
            await _context.Alumno_Cursos.AddAsync(alumno_Curso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlumnoInsc(int idInscripcion)
        {
            var existing = await _context.Alumno_Cursos.FirstOrDefaultAsync(ac => ac.IdInscripcion == idInscripcion);
            if (existing != null)
            {
                _context.Alumno_Cursos.Remove(existing);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("La inscripción no existe");
            }
        }

        public async Task UpdateAlumnoInsc(Alumno_Curso alumno_Curso)
        {
            var existing = await _context.Alumno_Cursos.FirstOrDefaultAsync(ac => ac.IdInscripcion == alumno_Curso.IdInscripcion);
            if (existing != null)
            {
                existing.IdAlumno = alumno_Curso.IdAlumno;
                existing.IdCurso = alumno_Curso.IdCurso;
                existing.Condicion = alumno_Curso.Condicion;
                existing.Nota = alumno_Curso.Nota;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetAlumnoCountInCurso(int idCurso)
        {
            return await _context.Alumno_Cursos.CountAsync(ac => ac.IdCurso == idCurso);
        }

        public async Task<List<(Alumno_Curso inscripcion, Usuario alumno)>> GetAlumnosByCursoAsync(int idCurso)
        {
            const string sql = @"
                SELECT ac.IdInscripcion, ac.IdAlumno, ac.IdCurso, ac.Condicion, ac.Nota,
                       u.Id, u.Apellido, u.ClaveHash, u.Email, u.Habilitado, u.Nombre, 
                       u.NombreUsuario, u.Salt, u.FechaAlta, u.Direccion, u.Telefono, 
                       u.Tipo, u.Legajo, u.FechaNacimiento, u.IdPlan
                FROM Alumno_Cursos ac
                INNER JOIN Usuarios u ON ac.IdAlumno = u.Id
                WHERE ac.IdCurso = @IdCurso";

            var resultado = new List<(Alumno_Curso inscripcion, Usuario alumno)>();
            string connectionString = _context.Database.GetConnectionString();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);
            
            command.Parameters.AddWithValue("@IdCurso", idCurso);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var inscripcion = new Alumno_Curso
                {
                    IdInscripcion = reader.GetInt32(0),
                    IdAlumno = reader.GetInt32(1),
                    IdCurso = reader.GetInt32(2),
                    Condicion = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Nota = reader.IsDBNull(4) ? null : reader.GetInt32(4)
                };

                var alumno = new Usuario(
                    reader.GetInt32(5),
                    reader.GetString(6),
                    reader.GetString(7),
                    reader.GetString(8),
                    reader.GetBoolean(9),
                    reader.GetString(10),
                    reader.GetString(11),
                    reader.GetDateTime(13),
                    reader.GetString(14),
                    reader.GetString(15),
                    reader.GetString(16),
                    reader.GetInt32(17),
                    reader.GetDateTime(18),
                    reader.GetInt32(19)
                );
                
                resultado.Add((inscripcion, alumno));
            }

            return resultado;
        }

        public async Task<List<(Profesor_Curso dictado, Usuario profesor)>> GetProfesoresByCursoAsync(int idCurso)
        {
            const string sql = @"
                SELECT pc.IdDictado, pc.IdCurso, pc.IdProfesor, pc.Cargo,
                       u.Id, u.Apellido, u.ClaveHash, u.Email, u.Habilitado, u.Nombre, 
                       u.NombreUsuario, u.Salt, u.FechaAlta, u.Direccion, u.Telefono, 
                       u.Tipo, u.Legajo, u.FechaNacimiento, u.IdPlan
                FROM Profesor_Cursos pc
                INNER JOIN Usuarios u ON pc.IdProfesor = u.Id
                WHERE pc.IdCurso = @IdCurso";

            var resultado = new List<(Profesor_Curso dictado, Usuario profesor)>();
            string connectionString = _context.Database.GetConnectionString();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);
            
            command.Parameters.AddWithValue("@IdCurso", idCurso);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var dictado = new Profesor_Curso
                {
                    IdDictado = reader.GetInt32(0),
                    IdCurso = reader.GetInt32(1),
                    IdProfesor = reader.GetInt32(2),
                    Cargo = reader.GetString(3)
                };

                var profesor = new Usuario(
                    reader.GetInt32(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetString(7),
                    reader.GetBoolean(8),
                    reader.GetString(9),
                    reader.GetString(10),
                    reader.GetDateTime(12),
                    reader.GetString(13),
                    reader.GetString(14),
                    reader.GetString(15),
                    reader.GetInt32(16),
                    reader.GetDateTime(17),
                    reader.GetInt32(18)
                );
                
                resultado.Add((dictado, profesor));
            }

            return resultado;
        }
    }
}
