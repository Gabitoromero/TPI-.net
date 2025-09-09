using Application.Services;
using DTOs;
using System.Runtime.CompilerServices;

namespace WebAPI
{
    public static class EspecialidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this WebApplication app){
            // CRUD - Especialidad ---------------------------------------------------------------------------------------------------------------------------
            EspecialidadService especialidadService = new EspecialidadService();

            app.MapGet("/especialidades/{id}", (int id) =>
            {
                EspecialidadDTO dto = especialidadService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message = "Especialidad not found" });
                }

                return Results.Ok(dto);
            });//checked

            app.MapGet("/especialidades/", () =>
            {
                List<EspecialidadDTO> espDTO = especialidadService.GetAll();

                if (espDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Especialidad not found" });
                }

                return Results.Ok(espDTO);
            });//checked

            app.MapPost("/especialidades/", (NewEspecialidadDTO dto) =>
            {
                try
                {
                    EspecialidadDTO espDTO = especialidadService.Add(dto);

                    return Results.Ok(espDTO);

                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }

            });

            app.MapDelete("/especialidades/{id}", (int id) =>
            {
                EspecialidadDTO espDeleted = especialidadService.Remove(id);
                if (espDeleted == null)
                {
                    return Results.NotFound(new { data = "User not found" });
                }
                return Results.Ok(espDeleted);


            });
        }
    }
}
