using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data
{
    public class UsuarioRepository
    {
        private readonly AcademiaContext _context;

        public UsuarioRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByUsername(string username) => await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == username);

        public async Task<Usuario?> Get(int id) => await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<List<Usuario>> GetAll() => await _context.Usuarios.ToListAsync();

        public async Task<List<Usuario>> GetAllProfesores() => await _context.Usuarios.Where(u => u.Tipo == "profesor").ToListAsync();

        public async Task<List<Usuario>> GetAllAlumnos() => await _context.Usuarios.Where(u => u.Tipo == "alumno").ToListAsync();

        public async Task Add(Usuario usuario)
        {
            try
            {
                if(usuario.Tipo == "profesor")
                {
                    List<Usuario> profesores = await _context.Usuarios.Where(u => u.Tipo == "profesor").ToListAsync();
                    int proxLegajo = profesores.Max(u => u.Legajo) + 1;
                    usuario.Legajo = proxLegajo;
                    await _context.Usuarios.AddAsync(usuario);
                    await _context.SaveChangesAsync();
                }
                if(usuario.Tipo == "alumno")
                {
                    List<Usuario> alumnos = await _context.Usuarios.Where(u => u.Tipo == "alumno").ToListAsync();
                    int proxLegajo = alumnos.Max(u => u.Legajo) + 1;
                    usuario.Legajo = proxLegajo;
                    await _context.Usuarios.AddAsync(usuario);
                    await _context.SaveChangesAsync();
                }
                if(usuario.Tipo == "admin")
                {
                    List<Usuario> admins = await _context.Usuarios.Where(u => u.Tipo == "admin").ToListAsync();
                    int proxLegajo = admins.Max(u => u.Legajo) + 1;
                    usuario.Legajo = proxLegajo;
                    await _context.Usuarios.AddAsync(usuario);
                    await _context.SaveChangesAsync();
                }
                
            }
            catch (DbUpdateException err)
            {
                // Check for SQL Server unique constraint / duplicate key errors
                if (err.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    string sqlMessage = sqlEx.Message ?? string.Empty;

                    // Prefer index name checks (defined in OnModelCreating)
                    if (sqlMessage.Contains("IX_Usuarios_Email", StringComparison.OrdinalIgnoreCase) ||
                        sqlMessage.Contains("IX_Usuarios_Email", StringComparison.CurrentCultureIgnoreCase) ||
                        sqlMessage.Contains("email", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ArgumentException("El email ya existe. Intente con otro email.");
                    }

                    if (sqlMessage.Contains("IX_Usuarios_NombreUsuario", StringComparison.OrdinalIgnoreCase) ||
                        sqlMessage.Contains("nombreusuario", StringComparison.OrdinalIgnoreCase) ||
                        sqlMessage.Contains("nombre de usuario", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ArgumentException("El nombre de usuario ya existe. Intente con otro nombre de usuario.");
                    }

                    // Fallback generic duplicate key message
                    throw new ArgumentException("Ya existe un registro con un valor único duplicado. Intente con valores diferentes.");
                }
                
                // Not a unique constraint violation -> rethrow original (preserve stack)
                throw;
            }
            catch (Exception err)
            {
                throw new ArgumentException(err.Message);
            }
         }

        public async Task<bool> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);  
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Usuario usuario)
        {
            var existingUsuario = await _context.Usuarios.FindAsync(usuario.Id);
            if (existingUsuario == null) return false;

            existingUsuario.Apellido = usuario.Apellido;
            existingUsuario.Email = usuario.Email;
            existingUsuario.Habilitado = usuario.Habilitado;
            existingUsuario.Nombre = usuario.Nombre;
            existingUsuario.NombreUsuario = usuario.NombreUsuario;

            existingUsuario.Direccion = usuario.Direccion;
            existingUsuario.Telefono = usuario.Telefono;
            existingUsuario.Tipo = usuario.Tipo;
            existingUsuario.Legajo = usuario.Legajo;
            existingUsuario.FechaNacimiento = usuario.FechaNacimiento;
            existingUsuario.IdPlan = usuario.IdPlan;

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
