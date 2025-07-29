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
                throw new ArgumentException("Email ya en uso " + dto.Email);
            }

            int id = GetNextId();
            var fechaAlta = DateTime.Now;


            Usuario usuario = new Usuario(
                id,
                dto.Apellido,
                dto.Clave,
                dto.Email,
                dto.Habilitado,
                dto.Nombre,
                dto.NombreUsuario,
                fechaAlta
            );

            UsuarioInMemory.Usuarios.Add(usuario);
            return dto;

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
