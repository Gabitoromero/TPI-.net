using DTOs;
using Data;
using Domain.Model;

namespace Application.Services
{
    public class UsuarioService
    {

        public UsuarioDTO Get(int id) { 
        
            Usuario usuario = UsuarioInMemory.Usuarios.Find(u => u.Id == id);

            if (usuario == null)
            {
                return null;
            }

            UsuarioDTO dto = new UsuarioDTO
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
        public List<UsuarioDTO> GetAll()
        {
            return UsuarioInMemory.Usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                Apellido = usuario.Apellido,
                Clave = usuario.Clave,
                Email = usuario.Email,
                Habilitado = usuario.Habilitado,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario
            }).ToList();

        }
        public UsuarioDTO Add(UsuarioDTO dto)
        {

            if (UsuarioInMemory.Usuarios.Any(u => u.Email.Equals(dto.Email, StringComparison.OrdinalIgnoreCase))){
                throw new ArgumentException("This Email alredy exists: " + dto.Email);
            }
            if (dto.Habilitado == null || dto.NombreUsuario == null || dto.Nombre == null || dto.Apellido == null || dto.Clave == null || dto.Email == null) {
                throw new ArgumentException("Properties non-nulleable are null");
            }

            int id = GetNextId();
            var fechaAlta = DateTime.Now;


            Usuario usuario = new Usuario(
                id,
                dto.Apellido,
                dto.Clave,
                dto.Email,
                dto.Habilitado.Value,
                dto.Nombre,
                dto.NombreUsuario,
                fechaAlta
            );

            UsuarioInMemory.Usuarios.Add(usuario);
            return dto;

        }
        public UsuarioDTO Remove(int id)
        {
            Usuario userToDelete = UsuarioInMemory.Usuarios.Find(u => u.Id == id);

            if (userToDelete == null){
                return null;
            }
            UsuarioDTO userDeletedDTO = new UsuarioDTO
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
