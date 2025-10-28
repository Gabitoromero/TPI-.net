using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Clients
{
    public static class JwtHelper
    {
        private static readonly JwtSecurityTokenHandler _handler = new();

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


        public static bool HasRole(string? token, string role)
        {
            var tokenRole = GetRole(token);
            return tokenRole?.Equals(role, StringComparison.OrdinalIgnoreCase) ?? false;
        }
    }
}
