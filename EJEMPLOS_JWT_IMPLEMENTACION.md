# ?? Ejemplos de Implementación JWT en Páginas Existentes

## ?? Tabla de Contenidos
1. [Mejora para CursosProfesorLista](#mejora-cursosprofesorlista)
2. [Proteger Endpoints del Backend](#proteger-endpoints-backend)
3. [Obtener UserId Automáticamente](#obtener-userid-automaticamente)
4. [Ejemplos de Autorización por Rol](#autorizacion-por-rol)

---

## 1. ?? Mejora para CursosProfesorLista

### ? Código Actual (Problema)
```csharp
// Problema: Necesita hacer una petición extra para obtener el usuario
ShowUsuarioDTO profesor = await APIUsuario.GetByUsernameAsync(AuthState.CurrentUser.Username);
var cursosProfesor = await APIUsuario.GetProfesorCursosAsync(profesor.Id);
```

### ? Código Mejorado (Con JWT)
```csharp
protected override async Task OnInitializedAsync()
{
    try
    {
        // ?? Obtener el ID directamente del token JWT
        var profesorId = AuthState.GetUserId();
        
        if (profesorId == null)
        {
            errorMessage = "No se pudo obtener el ID del usuario";
            return;
        }

        // ? Una sola petición en lugar de dos
        var cursosProfesor = await APIUsuario.GetProfesorCursosAsync(profesorId.Value);

        if (cursosProfesor == null || !cursosProfesor.Any())
        {
            data = new List<CursoDTO>();
            return;
        }

        // ... resto del código igual
    }
    catch (ArgumentException ex)
    {
        errorMessage = ex.Message;
    }
}
```

**Beneficios**:
- ? Una petición menos al servidor
- ? Más rápido
- ? Usa el JWT correctamente
- ? No necesita buscar el usuario por username

---

## 2. ?? Proteger Endpoints del Backend

### ?? Ejemplo: Endpoint de Cursos del Profesor

#### ? Antes (Sin Protección)
```csharp
// WebAPI\UsuarioEndpoints.cs
app.MapGet("/usuarios/{id}/profesor_cursos", async (UsuarioService service, int id) =>
{
    // ?? PROBLEMA: Cualquiera puede ver los cursos de cualquier profesor
    var cursos = await service.GetProfesorCursosAsync(id);
    return Results.Ok(cursos);
});
```

#### ? Después (Con JWT y Validación)
```csharp
app.MapGet("/usuarios/{id}/profesor_cursos", async (
    UsuarioService service, 
    int id, 
    HttpContext context) =>
{
    // ?? Obtener el ID del usuario autenticado
    var currentUserId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUserRole = context.User.FindFirst(ClaimTypes.Role)?.Value;
    
    // ? Verificar que el usuario solo pueda ver sus propios cursos
    // (excepto si es admin)
    if (currentUserRole != "admin" && currentUserId != id.ToString())
    {
        return Results.Forbid();
    }
    
    var cursos = await service.GetProfesorCursosAsync(id);
    
    if (cursos == null || !cursos.Any())
    {
        return Results.NotFound();
    }
    
    return Results.Ok(cursos);
}).RequireAuthorization(); // ?? Requiere estar autenticado
```

**Seguridad agregada**:
- ? Solo usuarios autenticados
- ? Solo pueden ver sus propios datos
- ? Admin puede ver todo

---

## 3. ?? Obtener UserId Automáticamente

### ?? Ejemplo: Endpoint "Mis Cursos"

En lugar de pedir el ID en la URL, usar el token:

```csharp
// WebAPI\UsuarioEndpoints.cs

app.MapGet("/mi-perfil/cursos", async (
    UsuarioService usuarioService,
    HttpContext context) =>
{
    // ?? Obtener el ID del token JWT
    var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    
    if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
    {
        return Results.Unauthorized();
    }
    
    var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value;
    
    List<object> cursos;
    
    if (userRole == "Profesor")
    {
        cursos = (await usuarioService.GetProfesorCursosAsync(userId))
            .Cast<object>().ToList();
    }
    else if (userRole == "Alumno")
    {
        cursos = (await usuarioService.GetAlumnoCursosAsync(userId))
            .Cast<object>().ToList();
    }
    else
    {
        return Results.Forbid();
    }
    
    return Results.Ok(cursos);
}).RequireAuthorization();
```

**Uso desde Blazor**:
```csharp
// En lugar de:
var profesor = await APIUsuario.GetByUsernameAsync(username);
var cursos = await APIUsuario.GetProfesorCursosAsync(profesor.Id);

// Ahora:
var cursos = await APIUsuario.GetMisCursosAsync();  // ?? Usa el JWT automáticamente
```

---

## 4. ?? Autorización por Rol

### ?? Ejemplo 1: Solo Profesores

```csharp
app.MapGet("/profesor/dashboard", async (HttpContext context) =>
{
    var userName = context.User.Identity?.Name;
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    
    return Results.Ok(new 
    { 
        mensaje = $"Bienvenido, Profesor {userName}",
        userId = userId
    });
}).RequireAuthorization(policy => policy.RequireRole("Profesor"));
```

### ?? Ejemplo 2: Solo Alumnos

```csharp
app.MapGet("/alumno/mis-inscripciones", async (
    UsuarioService service,
    HttpContext context) =>
{
    var userId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    var inscripciones = await service.GetAlumnoCursosAsync(userId);
    return Results.Ok(inscripciones);
}).RequireAuthorization(policy => policy.RequireRole("Alumno"));
```

### ?? Ejemplo 3: Múltiples Roles

```csharp
app.MapGet("/cursos/{id}", async (
    CursoService service,
    int id,
    HttpContext context) =>
{
    var curso = await service.GetAsync(id);
    
    if (curso == null)
    {
        return Results.NotFound();
    }
    
    return Results.Ok(curso);
}).RequireAuthorization(policy => 
    policy.RequireRole("Profesor", "Alumno", "Admin")
);
```

---

## 5. ??? Patrón de Seguridad Recomendado

### Para Páginas Blazor

```razor
@page "/mi-pagina"
@using BlazorApp.Components.Shared
@inject AuthStateService AuthState
@rendermode InteractiveServer

<AuthorizeView RequireProfesor="true">
    <div class="container">
        <h3>Página Protegida</h3>
        
        @if (loading)
        {
            <p>Cargando...</p>
        }
        else if (errorMessage != null)
        {
            <div class="alert alert-danger">@errorMessage</div>
        }
        else
        {
            <!-- Tu contenido -->
        }
    </div>
</AuthorizeView>

@code {
    private bool loading = true;
    private string? errorMessage;
    private object? data;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            // ?? Usar el UserId del token
            var userId = AuthState.GetUserId();
            
            if (userId == null)
            {
                errorMessage = "No se pudo obtener el usuario";
                return;
            }
            
            // Cargar datos usando el userId
            data = await CargarDatos(userId.Value);
        }
        catch (Exception ex)
        {
            errorMessage = $"Error: {ex.Message}";
        }
        finally
        {
            loading = false;
        }
    }
}
```

### Para Endpoints

```csharp
app.MapGet("/api/recurso", async (
    IServicio servicio,
    HttpContext context) =>
{
    // 1?? Obtener el usuario autenticado
    var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    
    if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
    {
        return Results.Unauthorized();
    }
    
    // 2?? Verificar permisos
    var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value;
    
    // 3?? Ejecutar lógica de negocio
    var resultado = await servicio.ObtenerRecurso(userId, userRole);
    
    // 4?? Retornar resultado
    return Results.Ok(resultado);
}).RequireAuthorization();
```

---

## 6. ?? Tabla de Conversión Rápida

| ? Antes (Sin JWT) | ? Después (Con JWT) |
|-------------------|---------------------|
| `GetByUsernameAsync(username)` | `AuthState.GetUserId()` |
| Pasar ID en URL | Obtener del token en el servidor |
| Confiar en datos del cliente | Validar con el token |
| Sin protección de endpoints | `.RequireAuthorization()` |
| Verificar role en el cliente | Verificar role en el servidor |

---

## 7. ?? Tareas Pendientes para tu App

### Páginas a Actualizar:
- [ ] `CursosProfesorLista.razor` - Usar `GetUserId()`
- [ ] `AlumnoInscripciones.razor` - Usar `GetUserId()`
- [ ] `UsuarioPerfil.razor` - Usar `GetUserId()`
- [ ] Otras páginas que obtengan el usuario

### Endpoints a Proteger:
- [ ] `/usuarios/{id}/profesor_cursos` - Solo el profesor o admin
- [ ] `/usuarios/{id}/alumno_cursos` - Solo el alumno o admin
- [ ] `/cursos/{id}/alumnos` - Solo el profesor del curso
- [ ] Todos los endpoints de modificación (POST, PUT, DELETE)

### Endpoints a Crear:
- [ ] `/mi-perfil` - Datos del usuario actual
- [ ] `/mi-perfil/cursos` - Cursos del usuario actual
- [ ] `/mi-perfil/actualizar` - Actualizar perfil del usuario actual

---

## 8. ?? Mejores Prácticas

1. **Nunca confíes en el cliente**: Siempre valida en el servidor
2. **Usa Claims**: Extrae información del token, no de parámetros
3. **Minimiza peticiones**: Usa el UserId del token en lugar de buscar el usuario
4. **Valida permisos**: Verifica que el usuario tenga acceso al recurso
5. **Logs para desarrollo**: Usa logs para debuggear, elimínalos en producción
6. **Maneja errores**: Siempre ten try-catch y mensajes de error claros
7. **Token en todas las peticiones**: Asegúrate de llamar `AddAuthorizationHeaderAsync`

---

## 9. ? Ejemplo Completo: Actualizar CursosProfesorLista

### Archivo: `BlazorApp\Components\Pages\CursosProfesorLista.razor`

```razor
@page "/profesor/cursos"
@using API.Clients
@using DTOs
@using BlazorApp.Services
@using BlazorApp.Components.Shared
@inject AuthStateService AuthState
@inject NavigationManager NavigationManager
@rendermode InteractiveServer

<PageTitle>Mis Cursos - Profesor</PageTitle>

<AuthorizeView RequireProfesor="true">
    <div class="container mt-4">
        <h3>?? Mis Cursos Asignados</h3>
        
        <!-- Información del profesor -->
        <div class="alert alert-info mb-4">
            <strong>?? Profesor:</strong> @AuthState.GetUsername()
            <br />
            <strong>?? Email:</strong> @AuthState.GetEmail()
        </div>

        @if (loading)
        {
            <div class="text-center">
                <div class="spinner-border" role="status">
                    <span class="visually-hidden">Cargando...</span>
                </div>
                <p>Cargando tus cursos...</p>
            </div>
        }
        else if (errorMessage != null)
        {
            <div class="alert alert-danger" role="alert">
                <strong>? Error:</strong> @errorMessage
            </div>
        }
        else if (data == null || !data.Any())
        {
            <div class="alert alert-warning" role="alert">
                ?? No tienes cursos asignados actualmente.
            </div>
        }
        else
        {
            <div class="table-responsive">
                <table class="table table-striped table-hover">
                    <thead class="table-dark">
                        <tr>
                            <th>Materia</th>
                            <th>Comisión</th>
                            <th>Año</th>
                            <th>Cargo</th>
                            <th class="text-center">Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach (var curso in data)
                        {
                            <tr>
                                <td><strong>@curso.Materia</strong></td>
                                <td>@curso.Comision</td>
                                <td>@curso.Año</td>
                                <td>
                                    <span class="badge bg-primary">@curso.Cargo</span>
                                </td>
                                <td class="text-center">
                                    <button class="btn btn-sm btn-primary" 
                                            @onclick="() => VerAlumnos(curso.IdCurso)">
                                        ?? Ver Alumnos
                                    </button>
                                </td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
            
            <p class="text-muted">
                <small>?? Total de cursos: @data.Count</small>
            </p>
        }
    </div>
</AuthorizeView>

@code {
    private List<CursoDTO>? data;
    private string? errorMessage;
    private bool loading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            // ?? Obtener el ID directamente del token JWT
            var profesorId = AuthState.GetUserId();
            
            if (profesorId == null)
            {
                errorMessage = "No se pudo obtener tu información de usuario. Por favor, vuelve a iniciar sesión.";
                return;
            }

            Console.WriteLine($"?? Cargando cursos para profesor ID: {profesorId}");

            // ? Una sola petición en lugar de dos
            var cursosProfesor = await APIUsuario.GetProfesorCursosAsync(profesorId.Value);

            if (cursosProfesor == null || !cursosProfesor.Any())
            {
                data = new List<CursoDTO>();
                return;
            }

            // Obtener información de materias y comisiones
            var materiaTasks = cursosProfesor.Select(c => APIMateria.GetAsync(c.Curso.Id_materia));
            var comisionTasks = cursosProfesor.Select(c => APIComision.GetAsync(c.Curso.Id_comision));
            
            var materias = await Task.WhenAll(materiaTasks);
            var comisiones = await Task.WhenAll(comisionTasks);

            data = cursosProfesor.Select((c, idx) => new CursoDTO
            {
                IdCurso = c.Curso.Id_curso,
                Materia = materias[idx].Desc_materia,
                Comision = comisiones[idx].Desc_comision,
                Año = c.Curso.Anio_calendario,
                Cargo = c.Cargo
            }).ToList();

            Console.WriteLine($"? Cursos cargados: {data.Count}");
        }
        catch (ArgumentException ex)
        {
            errorMessage = ex.Message;
            Console.WriteLine($"? ArgumentException: {ex.Message}");
        }
        catch (Exception ex)
        {
            errorMessage = $"Error al cargar los cursos: {ex.Message}";
            Console.WriteLine($"? Exception: {ex}");
        }
        finally
        {
            loading = false;
        }
    }

    private void VerAlumnos(int idCurso)
    {
        Console.WriteLine($"?? Navegando a alumnos del curso {idCurso}");
        NavigationManager.NavigateTo($"/profesor/cursos/{idCurso}/alumnos");
    }
}
```

---

**¿Siguiente paso?**
1. Aplica estos cambios a `CursosProfesorLista.razor`
2. Prueba que funcione correctamente
3. Aplica el mismo patrón a otras páginas
4. Protege los endpoints del backend

**¿Necesitas ayuda con alguna página específica?** ¡Avísame!
