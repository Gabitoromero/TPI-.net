using Application.Services;
using Domain.Model;
using DTOs;

namespace WebAPI
{
    public static class CursoEndpoints
    {
        public static void MapCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/cursos", async (CursoService cursoService) =>
            {
                List<NewCursoDTO> cursosDTO = await cursoService.GetAll();
                if (cursosDTO == null || cursosDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Cursos no encontrados" });
                }
                return Results.Ok(cursosDTO);
            });

            app.MapGet("/cursos/disponibles", async (CursoService cursoService) =>
            {
                List<NewCursoDTO> cursosDTO = await cursoService.GetAvailable();
                if (cursosDTO == null || cursosDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "No hay cursos disponibles" });
                }
                return Results.Ok(cursosDTO);
            });

            app.MapGet("/cursos/{id}", async (int id, CursoService cursoService) =>
            {
                NewCursoDTO dto = await cursoService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Curso no encontrado" });
                }
                return Results.Ok(dto);
            });

            app.MapPost("/cursos", async (NewCursoDTO dto, CursoService cursoService) =>
            {
                try
                {
                    NewCursoDTO newCurso = await cursoService.Add(dto);
                    return Results.Ok(newCurso);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });

            app.MapPut("/cursos/", async (NewCursoDTO updatedCurso, CursoService cursoService) =>
            {
                try
                {
                    bool success = await cursoService.Update(updatedCurso);
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

            app.MapDelete("/cursos/{id}", async (int id, CursoService cursoService) =>
            {
                bool cursoDeleted = await cursoService.Delete(id);
                if (!cursoDeleted)
                {
                    return Results.NotFound(new { data = "Curso no encontrado" });
                }
                return Results.NoContent();
            });
        }
    }
}
