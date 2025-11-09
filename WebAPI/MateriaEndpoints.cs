using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class MateriaEndpoints
    {
        public static void MapMateriaEndpoints(this WebApplication app)
        {
            app.MapGet("/materias", async (MateriaService serv) =>
            {
                List<MateriaDTO> list = await serv.GetAll();
                if (list == null || list.Count == 0) return Results.NotFound(new { message = "Materias no encontradas" });
                return Results.Ok(list);
            });

            app.MapGet("/materias/{id}", async (int id, MateriaService serv) =>
            {
                MateriaDTO dto = await serv.Get(id);
                if (dto == null) return Results.NotFound(new { message = "Materia no encontrada" });
                return Results.Ok(dto);
            });

            app.MapPost("/materias", async (MateriaDTO dto, MateriaService serv) =>
            {
                try
                {
                    MateriaDTO created = await serv.Add(dto);
                    return Results.Ok(created);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            }).RequireAuthorization("AdminOnly");

            app.MapPut("/materias", async (MateriaDTO dto, MateriaService serv) =>
            {
                try
                {
                    bool ok = await serv.Update(dto);
                    if (!ok) return Results.NotFound(new { message = "Materia no encontrada" });
                    return Results.Ok(dto);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            }).RequireAuthorization("AdminOnly");

            app.MapDelete("/materias/{id}", async (int id, MateriaService serv) =>
            {
                bool ok = await serv.Delete(id);
                if (!ok) return Results.NotFound(new { message = "Materia no encontrada" });
                return Results.NoContent();
            }).RequireAuthorization("AdminOnly");
        }
    }
}
