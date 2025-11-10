using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class PlanEndpoints
    {
        public static void MapPlanEndpoints(this WebApplication app)
        {
            // CRUD - Plan ---------------------------------------------------------------------------------------------------------------------------
            app.MapGet("/planes/{id}", async (PlanService service, int id) =>
            {
                PlanDTO? dto = await service.Get(id);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Plan no encontrado" });
                }
                return Results.Ok(dto);
            });
            app.MapGet("/planes/", async (PlanService service) =>
            {
                List<PlanDTO> planDTO = await service.GetAll();
                if (planDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Planes no encontrados" });
                }
                return Results.Ok(planDTO);
            });
            app.MapPost("/planes/", async (PlanService service, PlanDTO dto) =>
            {
                try
                {
                    PlanDTO planDTO = await service.Add(dto);
                    return Results.Ok(planDTO);
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            });
            app.MapDelete("/planes/{id}", async (PlanService service, int id) =>
            {
                try
                {
                    bool planDeleted = await service.Delete(id);
                    if (!planDeleted)
                    {
                        return Results.NotFound(new { data = "Plan no encontrado" });
                    }
                    return Results.NoContent();
                }catch(ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });
            app.MapPut("/planes/", async (PlanService service, PlanDTO dto) =>
            {
                try
                {
                    bool planUpdated = await service.Update(dto);
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
