using Domain.Model;

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
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
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
