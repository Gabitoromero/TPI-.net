using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI
{
    public static class ModuloEndpoints
    {
        public static void MapModuloEndpoints(this WebApplication app)
        {
            // CRUD - Modulo ---------------------------------------------------------------------------------------------------------------------------
            app.MapGet("/modulos/{id}", ([FromServices] ModuloService service, int id) =>
            {
                ModuloDTO? dto = service.Get(id);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Módulo no encontrado" });
                }
                return Results.Ok(dto);
            });
            app.MapGet("/modulos/", ([FromServices] ModuloService service) =>
            {
                List<ModuloDTO> modDTO = service.GetAll();
                if (modDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Módulos no encontrados" });
                }
                return Results.Ok(modDTO);
            });
           app.MapPost("/modulos/", ([FromServices] ModuloService service, [FromBody] ModuloDTO dto) =>
            {
                try
                {
                    ModuloDTO modDTO = service.Add(dto);
                    return Results.Ok(modDTO);
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            });
            app.MapDelete("/modulos/{id}", ([FromServices] ModuloService service, int id) =>
            {
                bool modDeleted = service.Delete(id);
                if (!modDeleted)
                {
                    return Results.NotFound(new { data = "Módulo no encontrado" });
                }
                return Results.NoContent();
            });
            app.MapPut("/modulos/", ([FromServices] ModuloService service, [FromBody] ModuloDTO dto) =>
            {
                try
                {
                    ModuloDTO? modDTO = service.Update(dto);
                    if (modDTO == null)
                    {
                        return Results.NotFound(new { message = "Módulo no encontrado" });
                    }
                    return Results.Ok(modDTO);
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            });
        }
    }
}
