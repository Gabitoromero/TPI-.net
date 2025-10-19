using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            // CRUD - Usuario ---------------------------------------------------------------------------------------------------------------------------
            app.MapGet("/usuarios/{id}", (UsuarioService service, int id) =>
            {
                FullUsuarioDTO? dto = service.Get(id);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Usuario no encontrado" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/username/{username}", (UsuarioService service, string username) =>
            {
                ShowUsuarioDTO? dto = service.GetByUsername(username); 
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Usuario no encontrado" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/profesores/", (UsuarioService service) =>
            {
                List<ShowUsuarioDTO> dto = service.GetAllProfesores();
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "No se encontraron profesores" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/alumnos/", (UsuarioService service) =>
            {
                List<ShowUsuarioDTO> dto = service.GetAllAlumnos();
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "No se encontraron alumnos" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/", (UsuarioService service) =>
            {
                List<ShowUsuarioDTO> dto = service.GetAll();
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "Usuario no encontrado" });
                }
                return Results.Ok(dto);
            });

            app.MapPost("/usuarios/", (UsuarioService service, FullUsuarioDTO dto) =>
             {
                 try
                 {
                     PostUsuarioDTO usuarioDto = service.Add(dto);
                     return Results.Ok(usuarioDto);
                 }
                 catch (Exception ex)
                 {
                     return Results.BadRequest(new { error = ex.Message });
                 }
             });
            app.MapDelete("/usuarios/{id}", (UsuarioService service, int id) =>
            {
                bool usuarioDeleted = service.Delete(id);
                if (!usuarioDeleted)
                {
                    return Results.NotFound(new { data = "Usuario no encontrado" });
                }
                return Results.NoContent();
            });

            app.MapPut("/usuarios/", (UsuarioService service, PutUsuarioDTO dto) =>
            {
                try
                {
                    bool usuarioUpdated = service.Update(dto);
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

            app.MapGet("/usuarios/{id}/profesor_cursos", (UsuarioService service, int id) =>
            {
                List<ShowProfesor_CursoDTO> dto = service.GetAllProfesorInsc(id);
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "El profesor no tiene cursos asignados o no existe" });
                }
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/profesor_cursos/{idDictado}", (UsuarioService service, int idDictado) =>
            {
                ShowProfesor_CursoDTO? dto = service.GetProfesorInsc(idDictado);
                if (dto == null)
                {
                    return Results.NotFound(new { message = "Inscripción no encontrada" });
                }
                return Results.Ok(dto);
            });

            app.MapPost("/usuarios/profesor_cursos/", (UsuarioService service, Profesor_CursoDTO dto) =>
            {
                try
                {
                    service.AddProfesorInsc(dto);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapPut("/usuarios/profesor_cursos/", (UsuarioService service, Profesor_CursoDTO dto) =>
            {
                try
                {
                    service.UpdateProfesorInsc(dto);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapDelete("/usuarios/profesor_cursos/{idDictado}", (UsuarioService service, int idDictado) =>
            {
                try
                {
                    service.DeleteProfesorInsc(idDictado);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            // Inscripciones de alumnos

            app.MapGet("/usuarios/{id}/alumno_cursos", (UsuarioService service, int id) =>
            {
                List<ShowAlumno_CursoDTO> dto = service.GetAllAlumnoInsc(id);
                if (dto.Count == 0)
                {
                    return Results.NotFound(new { message = "El alumno no tiene cursos asignados o no existe" });
                }
                return Results.Ok(dto);
            });


            app.MapPost("/usuarios/alumno_cursos/", (UsuarioService service, Alumno_CursoDTO dto) =>
            {
                try
                {
                    service.AddAlumnoInsc(dto);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapDelete("/usuarios/alumno_cursos/{idInscripcion}", (UsuarioService service, int idInscripcion) =>
            {
                try
                {
                    service.DeleteAlumnoInsc(idInscripcion);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapPut("/usuarios/alumno_cursos/", (UsuarioService service, Alumno_CursoDTO dto) =>
            {
                try
                {
                    service.UpdateAlumnoInsc(dto);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
        }
    }
}
