using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ComisionEndpoints
    {
        public static void MapComisionEndpoints(this WebApplication app)
        {
            app.MapGet("/comisiones", (ComisionService serv) =>
            {
                List<ComisionDTO> list = serv.GetAll();
                if (list == null || list.Count == 0) return Results.NotFound(new { message = "Comisiones no encontradas" });
                return Results.Ok(list);
            });

            app.MapGet("/comisiones/{id}", (int id, ComisionService serv) =>
            {
                ComisionDTO dto = serv.Get(id);
                if (dto == null) return Results.NotFound(new { message = "Comision no encontrada" });
                return Results.Ok(dto);
            });

            app.MapPost("/comisiones", (ComisionDTO dto, ComisionService serv) =>
            {
                try
                {
                    ComisionDTO created = serv.Add(dto);
                    return Results.Ok(created);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });

            app.MapPut("/comisiones", (ComisionDTO dto, ComisionService serv) =>
            {
                try
                {
                    bool ok = serv.Update(dto);
                    if (!ok) return Results.NotFound(new { message = "Comision no encontrada" });
                    return Results.Ok(dto);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });

            app.MapDelete("/comisiones/{id}", (int id, ComisionService serv) =>
            {
                bool ok = serv.Delete(id);
                if (!ok) return Results.NotFound(new { message = "Comision no encontrada" });
                return Results.NoContent();
            });
        }
    }
}
