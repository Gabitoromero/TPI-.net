using Data;
using Domain.Model;
using DTOs.UsuarioDTOs;

namespace Application.Services
{
    public class UsuarioService
    {

        public FullUsuarioDTO Get(int id) { 
        
            Usuario usuario = UsuarioInMemory.Usuarios.Find(u => u.Id == id);

            if (usuario == null)
            {
                return null;
            }

            FullUsuarioDTO dto = new FullUsuarioDTO
            {
                Id = usuario.Id,
                Apellido = usuario.Apellido,
                Clave = usuario.Clave,
                Email = usuario.Email,
                Habilitado = usuario.Habilitado,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario,
                FechaAlta = usuario.FechaAlta
            };  

            return dto;
        }
        public List<ShowUsuarioDTO> GetAll()
        {
            return UsuarioInMemory.Usuarios.Select(usuario => new ShowUsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.NombreUsuario
            }).ToList();

        }
        public PostUsuarioDTO Add(PostUsuarioDTO dto)
        {
            
            if ( dto.NombreUsuario == null || dto.Nombre == null || dto.Apellido == null || dto.Clave == null || dto.Email == null) {
                throw new ArgumentException("Properties non-nulleable are null");
            }
            if (UsuarioInMemory.Usuarios.Any(u => u.Email.Equals(dto.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("This Email alredy exists: " + dto.Email);
            }
            if (UsuarioInMemory.Usuarios.Any(u => u.NombreUsuario.Equals(dto.NombreUsuario, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("This user name alredy exists: " + dto.NombreUsuario);
            }

            int id = GetNextId();
            var fechaAlta = DateTime.Now;

            Usuario usuario = new Usuario(
                id,
                dto.Apellido,
                dto.Clave,
                dto.Email,
                true, //por default definimos que esta habilitado
                dto.Nombre,
                dto.NombreUsuario,
                fechaAlta
            );

            UsuarioInMemory.Usuarios.Add(usuario);
            return dto;

        }
        public ShowUsuarioDTO Remove(int id)
        {
            Usuario userToDelete = UsuarioInMemory.Usuarios.Find(u => u.Id == id);

            if (userToDelete == null){
                return null;
            }
            ShowUsuarioDTO userDeletedDTO = new ShowUsuarioDTO
            {
                Id = userToDelete.Id,
                NombreUsuario = userToDelete.NombreUsuario,
                Email = userToDelete.Email
            };

            UsuarioInMemory.Usuarios.Remove(userToDelete);
            return userDeletedDTO;

        }
        private int GetNextId()
        {

            if(UsuarioInMemory.Usuarios.Count > 0) { 

                return UsuarioInMemory.Usuarios.Max(u => u.Id) + 1;

            }

            return 1;
        }

    }
}
