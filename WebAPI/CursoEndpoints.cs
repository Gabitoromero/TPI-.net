using Application.Services;
using Domain.Model;
using DTOs;

namespace WebAPI
{
    public static class CursoEndpoints
    {
        public static void MapCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/cursos", (CursoService cursoService) =>
            {
                List<NewCursoDTO> cursosDTO = cursoService.GetAll();
                if (cursosDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Cursos no encontrados" });
                }
                return Results.Ok(cursosDTO);
            });

            app.MapGet("/cursos/disponibles", (CursoService cursoService) =>
            {
                List<NewCursoDTO> cursosDTO = cursoService.GetAvailable();
                if (cursosDTO == null || cursosDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "No hay cursos disponibles" });
                }
                return Results.Ok(cursosDTO);
            });

            app.MapGet("/cursos/{id}", (int id, CursoService cursoService) =>
            {
                NewCursoDTO dto = cursoService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Curso no encontrado" });
                }
                return Results.Ok(dto);
            });

            app.MapPost("/cursos", (NewCursoDTO dto, CursoService cursoService) =>
            {
                try
                {
                    NewCursoDTO newCurso = cursoService.Add(dto);
                    return Results.Ok(newCurso);
                }
                catch (ArgumentException err)
                {
                    return Results.BadRequest(new { error = err.Message });
                }
            });

            app.MapPut("/cursos/", (NewCursoDTO updatedCurso, CursoService cursoService) =>
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

            app.MapDelete("/cursos/{id}", (int id, CursoService cursoService) =>
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
