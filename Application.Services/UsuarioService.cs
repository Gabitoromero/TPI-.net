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
        public FullUsuarioDTO Patch(int id, PatchUsuarioDTO dto)
        {
            Usuario userToUpdate = UsuarioInMemory.Usuarios.Find(u => u.Id == id);

            if (userToUpdate == null) { return null; }
            if (dto.Id != null) { userToUpdate.Id = dto.Id.Value; }
            if (dto.Nombre != null) userToUpdate.Nombre = dto.Nombre;
            if (dto.Apellido != null) userToUpdate.Apellido = dto.Apellido;
            if (dto.Clave != null) userToUpdate.Clave = dto.Clave;
            if (dto.Email != null) userToUpdate.Email = dto.Email;
            if (dto.NombreUsuario != null) userToUpdate.NombreUsuario = dto.NombreUsuario;
            if (dto.Habilitado.HasValue) userToUpdate.Habilitado = dto.Habilitado.Value;
            if (dto.FechaAlta.HasValue) userToUpdate.FechaAlta = dto.FechaAlta.Value;

            return new FullUsuarioDTO
            {
                Id = userToUpdate.Id,
                Nombre = userToUpdate.Nombre,
                Apellido = userToUpdate.Apellido,
                Email = userToUpdate.Email,
                Clave = userToUpdate.Clave,
                NombreUsuario = userToUpdate.NombreUsuario,
                Habilitado = userToUpdate.Habilitado,
                FechaAlta = userToUpdate.FechaAlta
            };
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
