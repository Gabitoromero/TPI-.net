using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Clients
{
    /// <summary>
    /// Clase de ayuda para extraer información de tokens JWT
    /// Reutilizable en Blazor y WinForms
    /// </summary>
    public static class JwtHelper
    {
        private static readonly JwtSecurityTokenHandler _handler = new();

        /// <summary>
        /// Obtiene el ID del usuario desde el token JWT
        /// </summary>
        public static int? GetUserId(string? token)
        {
            if (string.IsNullOrEmpty(token)) return null;
            
            try
            {
                var jwt = _handler.ReadJwtToken(token);
                var claim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                return claim != null && int.TryParse(claim.Value, out int id) ? id : null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el nombre de usuario desde el token JWT
        /// </summary>
        public static string? GetUsername(string? token)
        {
            if (string.IsNullOrEmpty(token)) return null;
            
            try
            {
                var jwt = _handler.ReadJwtToken(token);
                return jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el email desde el token JWT
        /// </summary>
        public static string? GetEmail(string? token)
        {
            if (string.IsNullOrEmpty(token)) return null;
            
            try
            {
                var jwt = _handler.ReadJwtToken(token);
                return jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el rol del usuario desde el token JWT
        /// </summary>
        public static string? GetRole(string? token)
        {
            if (string.IsNullOrEmpty(token)) return null;
            
            try
            {
                var jwt = _handler.ReadJwtToken(token);
                return jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene todos los claims del token JWT
        /// </summary>
        public static IEnumerable<Claim>? GetClaims(string? token)
        {
            if (string.IsNullOrEmpty(token)) return null;
            
            try
            {
                var jwt = _handler.ReadJwtToken(token);
                return jwt.Claims;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Verifica si un rol específico coincide con el token
        /// </summary>
        public static bool HasRole(string? token, string role)
        {
            var tokenRole = GetRole(token);
            return tokenRole?.Equals(role, StringComparison.OrdinalIgnoreCase) ?? false;
        }
    }
}
