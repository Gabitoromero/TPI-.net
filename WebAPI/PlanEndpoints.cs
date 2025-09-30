using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class PlanEndpoints
    {
        public static void MapPlanEndpoints(this WebApplication app)
        {
            // CRUD - Plan ---------------------------------------------------------------------------------------------------------------------------
            app.MapGet("/planes/{id}", (PlanService service, int id) =>
            {
                PlanDTO? dto = service.Get(id);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Plan no encontrado" });
                }
                return Results.Ok(dto);
            });
            app.MapGet("/planes/", (PlanService service) =>
            {
                List<PlanDTO> planDTO = service.GetAll();
                if (planDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Planes no encontrados" });
                }
                return Results.Ok(planDTO);
            });
            app.MapPost("/planes/", (PlanService service, PlanDTO dto) =>
            {
                try
                {
                    PlanDTO planDTO = service.Add(dto);
                    return Results.Ok(planDTO);
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            });
            app.MapDelete("/planes/{id}", (PlanService service, int id) =>
            {
                bool planDeleted = service.Delete(id);
                if (!planDeleted)
                {
                    return Results.NotFound(new { data = "Plan no encontrado" });
                }
                return Results.NoContent();
            });
            app.MapPut("/planes/", (PlanService service, PlanDTO dto) =>
            {
                try
                {
                    bool planUpdated = service.Update(dto);
                    if (!planUpdated)
                    {
                        return Results.NotFound(new { message = "Plan no encontrado" });
                    }
                    return Results.Ok(planUpdated);
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            });
        }
    }
}
