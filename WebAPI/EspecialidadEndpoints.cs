using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebAPI
{
    public static class EspecialidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this WebApplication app){
            // CRUD - Especialidad ---------------------------------------------------------------------------------------------------------------------------

            app.MapGet("/especialidades/{id}", ([FromServices] EspecialidadService service, int id) =>
            {
                EspecialidadDTO? dto = service.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message = "Especialidad no encontrada" });
                }

                return Results.Ok(dto);
            });

            app.MapGet("/especialidades/", ([FromServices] EspecialidadService service) =>
            {
                List<EspecialidadDTO> espDTO = service.GetAll();

                if (espDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Especialidad no encontrada" });
                }

                return Results.Ok(espDTO);
            });

           app.MapPost("/especialidades/", ([FromServices] EspecialidadService service, [FromBody]EspecialidadDTO dto) =>
            {
                try
                {
                    EspecialidadDTO espDTO = service.Add(dto);

                    return Results.Ok(espDTO);

                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }

            });

            app.MapDelete("/especialidades/{id}", ([FromServices] EspecialidadService service, int id) =>
            {
                bool espDeleted = service.Delete(id);
                if (!espDeleted)
                {
                    return Results.NotFound(new { data = "Especialidad no encontrada" });
                }
                return Results.NoContent();
            });

            app.MapPut("/especialidades", ([FromServices] EspecialidadService service, [FromBody] EspecialidadDTO dto) =>
            {
                try
                {
                    bool espUpdated = service.Update(dto);
                    if (!espUpdated)
                    {
                        return Results.NotFound(new { data = "Especialidad no encontrada" });
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
