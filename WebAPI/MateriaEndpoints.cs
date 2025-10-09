using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class MateriaEndpoints
    {
        public static void MapMateriaEndpoints(this WebApplication app)
        {
            app.MapGet("/materias", (MateriaService serv) =>
            {
                List<MateriaDTO> list = serv.GetAll();
                if (list == null || list.Count == 0) return Results.NotFound(new { message = "Materias no encontradas" });
                return Results.Ok(list);
            });

            app.MapGet("/materias/{id}", (int id, MateriaService serv) =>
            {
                MateriaDTO dto = serv.Get(id);
                if (dto == null) return Results.NotFound(new { message = "Materia no encontrada" });
                return Results.Ok(dto);
            });

            app.MapPost("/materias", (MateriaDTO dto, MateriaService serv) =>
            {
                try
                {
                    MateriaDTO created = serv.Add(dto);
                    return Results.Ok(created);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });

            app.MapPut("/materias", (MateriaDTO dto, MateriaService serv) =>
            {
                try
                {
                    bool ok = serv.Update(dto);
                    if (!ok) return Results.NotFound(new { message = "Materia no encontrada" });
                    return Results.Ok(dto);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });

            app.MapDelete("/materias/{id}", (int id, MateriaService serv) =>
            {
                bool ok = serv.Delete(id);
                if (!ok) return Results.NotFound(new { message = "Materia no encontrada" });
                return Results.NoContent();
            });
        }
    }
}
