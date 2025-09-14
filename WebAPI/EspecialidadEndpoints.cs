using Application.Services;
using DTOs;
using System.Runtime.CompilerServices;

namespace WebAPI
{
    public static class EspecialidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this WebApplication app){
            // CRUD - Especialidad ---------------------------------------------------------------------------------------------------------------------------

            app.MapGet("/especialidades/{id}", (int id, EspecialidadService service) =>
            {
                EspecialidadDTO? dto = service.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message = "Especialidad no encontrada" });
                }

                return Results.Ok(dto);
            });

            app.MapGet("/especialidades/", (EspecialidadService service) =>
            {
                List<EspecialidadDTO> espDTO = service.GetAll();

                if (espDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Especialidad no encontrada" });
                }

                return Results.Ok(espDTO);
            });

           app.MapPost("/especialidades/", (EspecialidadDTO dto, EspecialidadService service) =>
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

            app.MapDelete("/especialidades/{id}", (int id, EspecialidadService service) =>
            {
                bool espDeleted = service.Delete(id);
                if (!espDeleted)
                {
                    return Results.NotFound(new { data = "Especialidad no encontrada" });
                }
                return Results.NoContent();
            });

            app.MapPut("/especialidades", (EspecialidadDTO dto, EspecialidadService service) =>
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
