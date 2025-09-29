using DTOs;
using Application.Services;

namespace WebAPI
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/auth/login", async (LoginRequest request, AuthService _service, IConfiguration configuration) =>
            {
                try
                {
                    var response = await _service.LoginAsync(request);

                    if (response == null)
                    {
                        return Results.Unauthorized();
                    }

                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error durante el login: {ex.Message}");
                }
            }).AllowAnonymous(); // Quitamos la necesidad de estar autenticado para loguearse (por obvias razones)
        }
    }
}
