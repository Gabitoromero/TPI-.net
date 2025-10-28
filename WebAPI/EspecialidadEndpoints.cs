using Application.Services;
using DTOs;


namespace WebAPI
{
    public static class EspecialidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this WebApplication app){
            // CRUD - Especialidad ---------------------------------------------------------------------------------------------------------------------------

            app.MapGet("/especialidades/{id}", async (EspecialidadService service, int id, HttpContext context) =>
            {

                EspecialidadDTO? dto = await service.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message = "Especialidad no encontrada" });
                }

                return Results.Ok(dto);
            });

            app.MapGet("/especialidades/", async (EspecialidadService service, HttpContext context) =>
            {
                // 🔍 PRUEBA: Ver si llega el header Authorization
                var authHeader = context.Request.Headers["Authorization"].ToString();

                
                if (context.User.Identity?.IsAuthenticated == true)
                {
                    foreach (var claim in context.User.Claims)
                    {
                        Console.WriteLine($"  - {claim.Type}: {claim.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Usuario NO autenticado");
                }
            

                List<EspecialidadDTO> espDTO = await service.GetAll();

                if (espDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Especialidad no encontrada" });
                }

                return Results.Ok(espDTO);
            });

           app.MapPost("/especialidades/", async (EspecialidadService service, EspecialidadDTO dto) =>
            {
                try
                {
                    EspecialidadDTO espDTO = await service.Add(dto);

                    return Results.Ok(espDTO);

                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }

            });

            app.MapDelete("/especialidades/{id}", async (EspecialidadService service, int id) =>
            {
                try
                {
                    bool espDeleted = await service.Delete(id);
                    if (!espDeleted)
                    {
                        return Results.NotFound(new { data = "Especialidad no encontrada" });
                    }
                    return Results.NoContent();
                }
                catch(ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });

            app.MapPut("/especialidades", async (EspecialidadService service, EspecialidadDTO dto) =>
            {
                try
                {
                    bool espUpdated = await service.Update(dto);
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
