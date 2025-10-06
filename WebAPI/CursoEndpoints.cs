using Application.Services;
using Domain.Model;
using DTOs;

namespace WebAPI
{
    public static class CursoEndpoints
    {
        public static void MapCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/api/cursos", (CursoService cursoService) =>
            {
                List<CursoDTO> cursosDTO = cursoService.GetAll();
                if (cursosDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Planes no encontrados" });
                }
                return Results.Ok(cursosDTO);
            });

            app.MapGet("/api/cursos/{id}", (int id, CursoService cursoService) =>
            {
                CursoDTO dto = cursoService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            });

            app.MapPost("/api/cursos", (CursoDTO dto, CursoService cursoService) =>
            {
                try
                {
                    CursoDTO newCurso = cursoService.Add(dto);
                    return Results.Ok(newCurso);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });
            app.MapPut("/api/cursos/{id}", (int id, CursoDTO updatedCurso, CursoService cursoService) =>
            {
                try
                {
                    bool success = cursoService.Update(updatedCurso);
                    if (!success)
                    {
                        return Results.NotFound(new { message = "Curso no encontrado" });
                    }
                    return Results.Ok(updatedCurso);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });
            app.MapDelete("/api/cursos/{id}", (int id, CursoService cursoService) =>
            {
                bool cursoDeleted = cursoService.Delete(id);
                if (!cursoDeleted)
                {
                    return Results.NotFound(new { data = "Curso no encontrado" });
                }
                return Results.NoContent();
            });
        }
    }
}
