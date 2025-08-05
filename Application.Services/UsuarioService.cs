using Data;
using Domain.Model;
using DTOs;

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

            if (dto.NombreUsuario == null || dto.Nombre == null || dto.Apellido == null || dto.Clave == null || dto.Email == null) {
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
        public void Delete(int id)
        {
            Usuario userToDelete = UsuarioInMemory.Usuarios.Find(u => u.Id == id);

            if (userToDelete == null) {
                throw new ArgumentException("User with ID " + id + " does not exist.");
            }

            UsuarioInMemory.Usuarios.Remove(userToDelete);
            return;

        }
        public PutUsuarioDTO Update(PutUsuarioDTO dto)
        {
            Usuario userToUpdate = UsuarioInMemory.Usuarios.Find(u => u.Id == dto.Id);
            if (userToUpdate == null)
            {
                throw new ArgumentException($"User with ID {dto.Id} does not exist");
            }
            PutUsuarioDTO userUpdated = new PutUsuarioDTO();
            userUpdated.Id = userToUpdate.Id;


            if (string.IsNullOrWhiteSpace(dto.NombreUsuario) || string.IsNullOrWhiteSpace(dto.Email)) {

                    Usuario userDuplicated = UsuarioInMemory.Usuarios.Find(u => u.Id != userToUpdate.Id && (u.NombreUsuario == dto.NombreUsuario || u.Email == dto.Email));
                    if (userDuplicated != null)
                    {
                        if (userDuplicated.NombreUsuario == dto.NombreUsuario) { throw new ArgumentException("User with username " + dto.NombreUsuario + " already exists."); }
                        if (userDuplicated.Email == dto.Email) { throw new ArgumentException("User with email " + dto.Email + " already exists."); }
                    }
                    if (dto.NombreUsuario == null) { 
                        userUpdated.NombreUsuario = userToUpdate.NombreUsuario;
                    }
                    else
                    {
                        userUpdated.NombreUsuario = dto.NombreUsuario;
                    }
                    if (dto.Email == null) { userUpdated.Email = userToUpdate.Email;}
                    else{ userUpdated.Email = dto.Email;}

                    
            }
            else{

                    Usuario userDuplicated = UsuarioInMemory.Usuarios.Find(u => u.Id != userToUpdate.Id && (u.Email == dto.Email || u.NombreUsuario == dto.NombreUsuario));
                    if (userDuplicated != null)
                    {
                        if (userDuplicated.NombreUsuario == dto.NombreUsuario && userDuplicated.Email == dto.Email) { throw new ArgumentException("User with username " + dto.NombreUsuario + " and email " + dto.Email + " already exists."); }
                        if (userDuplicated.NombreUsuario == dto.NombreUsuario) { throw new ArgumentException("User with username " + dto.NombreUsuario + " already exists."); }
                        if (userDuplicated.Email == dto.Email) { throw new ArgumentException("User with email " + dto.Email + " already exists."); }
                    }
                    userUpdated.NombreUsuario = dto.NombreUsuario;
                    userUpdated.Email = dto.Email;
            }
  
            if (dto.Nombre == null) { userUpdated.Nombre = userToUpdate.Nombre; }
            else { userUpdated.Nombre = dto.Nombre; }

            if (dto.Apellido == null) { userUpdated.Apellido = userToUpdate.Apellido; }
            else { userUpdated.Apellido = dto.Apellido; }

            if (dto.Clave == null) { userUpdated.Clave = userToUpdate.Clave; }
            else { userUpdated.Clave = dto.Clave; }

            userUpdated.Habilitado = dto.Habilitado;

            return userUpdated;

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
