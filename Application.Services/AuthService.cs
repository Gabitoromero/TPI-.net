using Data;
using DTOs;
using Microsoft.Extensions.Configuration;


namespace Application.Services
{
    public class AuthService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public AuthService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NombreUsuario) || string.IsNullOrWhiteSpace(request.Clave))
                return false;

            var usuario = _usuarioRepository.GetByUsername(request.NombreUsuario);

            if (usuario == null || !usuario.ValidatePassword(request.Clave))
                return false;


            return true; // cambiar por token
                         // og code
                         /*
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return null;

            var usuario = usuarioRepository.GetByUsername(request.Username);

            if (usuario == null || !usuario.ValidatePassword(request.Password))
                return null;

            var token = GenerateJwtToken(usuario);
            var expiresAt = DateTime.UtcNow.AddMinutes(GetExpirationMinutes());

            return new LoginResponse
            {
                Token = token,
                ExpiresAt = expiresAt,
                Username = usuario.Username
            };
*/
        }
    }
}
