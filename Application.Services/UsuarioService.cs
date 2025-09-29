using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class UsuarioService
    { 
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        public FullUsuarioDTO? Get(int id) {

            Usuario? usuario = _repository.Get(id);

            if (usuario == null) return null;


            FullUsuarioDTO dto = new FullUsuarioDTO
            {
                Id = usuario.Id,
                Apellido = usuario.Apellido,
                Clave = usuario.ClaveHash,
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
            List<Usuario> usuarios = _repository.GetAll();

            return usuarios.Select(usuario => new ShowUsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.NombreUsuario
            }).ToList();
        }
        public PostUsuarioDTO Add(PostUsuarioDTO dto)
        {

            var fechaCreacion = DateTime.Now;
            Usuario usuario = new Usuario(0, dto.Apellido, dto.Clave, dto.Email, true, dto.Nombre, dto.NombreUsuario, fechaCreacion);

            _repository.Add(usuario);

            return new PostUsuarioDTO
            {
                NombreUsuario = dto.NombreUsuario,
                Email = dto.Email,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Clave = dto.Clave
            };

        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }


        public bool Update(PutUsuarioDTO dto)
        {
            Usuario? usuario = _repository.Get(dto.Id);

            if (usuario == null) return false;

            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Email = dto.Email;
            usuario.Habilitado = dto.Habilitado;

            if (!string.IsNullOrWhiteSpace(dto.Clave)) usuario.SetClave(dto.Clave);

            return _repository.Update(usuario);
        }

    }
}
