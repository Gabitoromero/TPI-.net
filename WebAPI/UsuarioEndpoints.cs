using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            // CRUD - Usuario ---------------------------------------------------------------------------------------------------------------------------
            app.MapGet("/usuarios/{id}", (UsuarioService service, int id) =>
            {
                FullUsuarioDTO? dto = service.Get(id);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Usuario no encontrado" });
                }
                return Results.Ok(dto);
            });
            app.MapGet("/usuarios/", (UsuarioService service) =>
            {
                List<ShowUsuarioDTO> dto = service.GetAll();
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "Usuario no encontrado" });
                }
                return Results.Ok(dto);
            });

           app.MapPost("/usuarios/", (UsuarioService service, PostUsuarioDTO dto) =>
            {
                try
                {
                    PostUsuarioDTO usuarioDto = service.Add(dto);
                    return Results.Ok(usuarioDto);
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            });
            app.MapDelete("/usuarios/{id}", (UsuarioService service, int id) =>
            {
                bool usuarioDeleted = service.Delete(id);
                if (!usuarioDeleted)
                {
                    return Results.NotFound(new { data = "Usuario no encontrado" });
                }
                return Results.NoContent();
            });

            app.MapPut("/usuarios/", (UsuarioService service, PutUsuarioDTO dto) =>
            {
                try
                {
                    bool usuarioUpdated = service.Update(dto);
                    if (!usuarioUpdated)
                    {
                        return Results.NotFound(new { data = "Usuario no encontrado" });
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            }); 
        }
    }
}
