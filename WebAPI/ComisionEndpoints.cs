using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ComisionEndpoints
    {
        public static void MapComisionEndpoints(this WebApplication app)
        {
            app.MapGet("/comisiones", async (ComisionService serv) =>
            {
                List<ComisionDTO> list = await serv.GetAll();
                if (list == null || list.Count == 0) return Results.NotFound(new { message = "Comisiones no encontradas" });
                return Results.Ok(list);
            });

            app.MapGet("/comisiones/{id}", async (int id, ComisionService serv) =>
            {
                ComisionDTO dto = await serv.Get(id);
                if (dto == null) return Results.NotFound(new { message = "Comision no encontrada" });
                return Results.Ok(dto);
            });

            app.MapPost("/comisiones", async (ComisionDTO dto, ComisionService serv) =>
            {
                try
                {
                    ComisionDTO created = await serv.Add(dto);
                    return Results.Ok(created);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            }).RequireAuthorization("AdminOnly");

            app.MapPut("/comisiones", async (ComisionDTO dto, ComisionService serv) =>
            {
                try
                {
                    bool ok = await serv.Update(dto);
                    if (!ok) return Results.NotFound(new { message = "Comision no encontrada" });
                    return Results.Ok(dto);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            }).RequireAuthorization("AdminOnly");

            app.MapDelete("/comisiones/{id}", async (int id, ComisionService serv) =>
            {
                bool ok = await serv.Delete(id);
                if (!ok) return Results.NotFound(new { message = "Comision no encontrada" });
                return Results.NoContent();
            }).RequireAuthorization("AdminOnly");
        }
    }
}
