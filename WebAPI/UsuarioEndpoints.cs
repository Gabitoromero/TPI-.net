using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            // CRUD - Usuario ---------------------------------------------------------------------------------------------------------------------------
            app.MapGet("/usuarios/{id}", async (UsuarioService service, int id) =>
            {
                FullUsuarioDTO? dto = await service.Get(id);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Usuario no encontrado" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/username/{username}", async (UsuarioService service, string username) =>
            {
                ShowUsuarioDTO? dto = await service.GetByUsername(username); 
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Usuario no encontrado" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/profesores/", async (UsuarioService service) =>
            {
                List<ShowUsuarioDTO> dto = await service.GetAllProfesores();
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "No se encontraron profesores" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/alumnos/", async (UsuarioService service) =>
            {
                List<ShowUsuarioDTO> dto = await service.GetAllAlumnos();
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "No se encontraron alumnos" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/", async (UsuarioService service) =>
            {
                List<ShowUsuarioDTO> dto = await service.GetAll();
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "Usuario no encontrado" });
                }
                return Results.Ok(dto);
            });

            app.MapPost("/usuarios/", async (UsuarioService service, FullUsuarioDTO dto) =>
             {
                 try
                 {
                     PostUsuarioDTO usuarioDto = await service.Add(dto);
                     return Results.Ok(usuarioDto);
                 }
                 catch (Exception ex)
                 {
                     return Results.BadRequest(new { error = ex.Message });
                 }
             });

            app.MapDelete("/usuarios/{id}", async (UsuarioService service, int id) =>
            {
                bool usuarioDeleted = await service.Delete(id);
                if (!usuarioDeleted)
                {
                    return Results.NotFound(new { data = "Usuario no encontrado" });
                }
                return Results.NoContent();
            });

            app.MapPut("/usuarios/", async (UsuarioService service, PutUsuarioDTO dto) =>
            {
                try
                {
                    bool usuarioUpdated = await service.Update(dto);
                    if (!usuarioUpdated)
                    {
                        return Results.NotFound(new { data = "Usuario no encontrado" });
                    }

                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            // Inscripciones de profesional

            app.MapGet("/usuarios/{id}/profesor_cursos", async (UsuarioService service, int id) =>
            {
                List<ShowProfesor_CursoDTO> dto = await service.GetAllProfesorInsc(id);
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "El profesor no tiene cursos asignados o no existe" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/profesor_cursos/{idDictado}", async (UsuarioService service, int idDictado) =>
            {
                ShowProfesor_CursoDTO? dto = await service.GetProfesorInsc(idDictado);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Inscripción no encontrada" });
                }
                return Results.Ok(dto);
            });

            app.MapPost("/usuarios/profesor_cursos/", async (UsuarioService service, Profesor_CursoDTO dto) =>
            {
                try
                {
                    await service.AddProfesorInsc(dto);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapPut("/usuarios/profesor_cursos/", async (UsuarioService service, Profesor_CursoDTO dto) =>
            {
                try
                {
                    await service.UpdateProfesorInsc(dto);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapDelete("/usuarios/profesor_cursos/{idDictado}", async (UsuarioService service, int idDictado) =>
            {
                try
                {
                    await service.DeleteProfesorInsc(idDictado);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            // Inscripciones de alumnos

            app.MapGet("/usuarios/{id}/alumno_cursos", async (UsuarioService service, int id) =>
            {
                List<ShowAlumno_CursoDTO> dto = await service.GetAllAlumnoInsc(id);
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "El alumno no tiene cursos asignados o no existe" });
                }
                return Results.Ok(dto);
            });

            app.MapPost("/usuarios/alumno_cursos/", async (UsuarioService service, Alumno_CursoDTO dto) =>
            {
                try
                {
                    await service.AddAlumnoInsc(dto);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapDelete("/usuarios/alumno_cursos/{idInscripcion}", async (UsuarioService service, int idInscripcion) =>
            {
                try
                {
                    await service.DeleteAlumnoInsc(idInscripcion);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapPut("/usuarios/alumno_cursos/", async (UsuarioService service, Alumno_CursoDTO dto) =>
            {
                try
                {
                    await service.UpdateAlumnoInsc(dto);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            // Obtener alumnos inscriptos en un curso específico
            app.MapGet("/usuarios/cursos/{idCurso}/alumnos", async (UsuarioService service, int idCurso) =>
            {
                try
                {
                    List<AlumnoCursoDetalleDTO> alumnos = await service.GetAlumnosByCursoAsync(idCurso);
                    if (alumnos.Count == 0)
                    {
                        return Results.Ok(new List<AlumnoCursoDetalleDTO>()); // Retornar lista vacía si no hay alumnos
                    }
                    return Results.Ok(alumnos);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
        }
    }
}
