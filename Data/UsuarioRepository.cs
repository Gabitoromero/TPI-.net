using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UsuarioRepository
    {
        private readonly AcademiaContext _context;

        public UsuarioRepository(AcademiaContext context)
        {
            _context = context;
        }

        public Usuario? GetByUsername(string username) => _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == username);

        public Usuario? Get(int id) => _context.Usuarios.FirstOrDefault(u => u.Id == id);

        public List<Usuario> GetAll() => _context.Usuarios.ToList();

        public void Add(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
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
            catch (ArgumentException err)
            {
                throw new Exception(err.Message);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
         }

        public bool Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Usuario usuario)
        {
            var existingUsuario = _context.Usuarios.Find(usuario.Id);
            if (existingUsuario == null) return false;

            existingUsuario.Apellido = usuario.Apellido;
            existingUsuario.Email = usuario.Email;
            existingUsuario.Habilitado = usuario.Habilitado;
            existingUsuario.Nombre = usuario.Nombre;
            existingUsuario.NombreUsuario = usuario.NombreUsuario;

            _context.SaveChanges();
            return true;
        }

    }
}
