using System;
using System.Net;
using System.Net.Http;
using Domain.Model;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class APIUsuario : APIClientBase
    {
        private static HttpClient client;
        static APIUsuario()
        {
            client = CreateHttpClientAsync();
        }

        // CRUD Usuario
        public static async Task<bool> LoginAsync(LoginRequest dto)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("auth/login", dto);
                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    if (loginResponse != null)
                    {
                        LoginResponse = loginResponse;
                        return true;
                    }
                    else
                    {
                        throw new ArgumentException("No se pudo iniciar sesión");
                    }
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return false; // Credenciales inválidas
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException("No se pudo iniciar sesión");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error al intentar conectarse al servidor");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al intentar iniciar sesión");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al intentar iniciar sesión");
            }
        }

        public static async Task<FullUsuarioDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("usuarios/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FullUsuarioDTO>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"No se encontró el usuario con ID: {id}");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudo obtener el usuario con ID: {id}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener el usuario");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener el usuario");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener el usuario: {ex.Message}");
            }
        }

        public static async Task<ShowUsuarioDTO?> GetByUsernameAsync(string username)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"usuarios/username/{username}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ShowUsuarioDTO>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException("No se pudo obtener el usuario por nombre de usuario");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener el usuario");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener el usuario");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener el usuario: {ex.Message}");
            }
        }

        public static async Task<List<ShowUsuarioDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("usuarios");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ShowUsuarioDTO>>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException("No se encontraron usuarios");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException("No se pudieron obtener los usuarios");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener los usuarios");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener los usuarios");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener los usuarios: {ex.Message}");
            }
        }

        public static async Task<PostUsuarioDTO> AddAsync(FullUsuarioDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await client.PostAsJsonAsync("usuarios", dto);
                if (resp.IsSuccessStatusCode)
                {
                    return await resp.Content.ReadFromJsonAsync<PostUsuarioDTO>();
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new ArgumentException("No se pudo crear el usuario");
                }
            }
            catch (HttpRequestException err)
            {
                throw new ArgumentException("Error de conexión al intentar crear el usuario");
            }
            catch (TaskCanceledException err)
            {
                throw new ArgumentException("Tiempo de espera agotado al crear el usuario");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al crear el usuario: {ex.Message}");
            }
        }

        public static async Task UpdateAsync(PutUsuarioDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await client.PutAsJsonAsync("usuarios/", dto); 
                if (resp.IsSuccessStatusCode)
                {
                    return;
                }
                else if (resp.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"No se encontró el usuario con ID: {dto.Id}");
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudo actualizar el usuario con ID: {dto.Id}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new ArgumentException("Error de conexión al intentar actualizar el usuario");
            }
            catch (TaskCanceledException err)
            {
                throw new ArgumentException("Tiempo de espera agotado al actualizar el usuario");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al actualizar el usuario: {ex.Message}");
            }
        }

        public static async Task DeleteAsync(int id) 
        {
            try
            {
                HttpResponseMessage resp = await client.DeleteAsync("usuarios/" + id);
                if (resp.IsSuccessStatusCode)
                {
                    return;
                }
                else if (resp.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"No se encontró el usuario con ID: {id}");
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudo eliminar el usuario con ID: {id}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new ArgumentException("Error de conexión al intentar eliminar el usuario");
            }
            catch (TaskCanceledException err)
            {
                throw new ArgumentException("Tiempo de espera agotado al eliminar el usuario");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al eliminar el usuario: {ex.Message}");
            }
        }

        // Búsqueda USUARIOS por Tipo (Profesor/Alumno)
        public static async Task<List<ShowUsuarioDTO>> GetProfesoresAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("usuarios/profesores/");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ShowUsuarioDTO>>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException("No se encontraron profesores");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException("No se pudieron obtener los profesores");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener los profesores");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener los profesores");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener los profesores: {ex.Message}");
            }
        }

        public static async Task<List<ShowUsuarioDTO>> GetAlumnosAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("usuarios/alumnos/");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ShowUsuarioDTO>>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException("No se encontraron alumnos");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException("No se pudieron obtener los alumnos");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener los alumnos");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener los alumnos");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener los alumnos: {ex.Message}");
            }
        }

        // Búsqueda de USUARIOS por Curso
        public static async Task<List<AlumnoCursoDetalleDTO>> GetAlumnosByCursoAsync(int idCurso)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"usuarios/cursos/{idCurso}/alumnos");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<AlumnoCursoDetalleDTO>>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"No se encontraron alumnos para el curso con ID: {idCurso}");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudieron obtener los alumnos del curso con ID: {idCurso}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener los alumnos del curso");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener los alumnos del curso");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener los alumnos del curso: {ex.Message}");
            }
        }

        public static async Task<List<ShowAlumno_CursoDTO>> GetAlumnosCompletoByCursoAsync(int idCurso)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"usuarios/cursos/{idCurso}/alumnos/completo");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ShowAlumno_CursoDTO>>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"No se encontraron alumnos para el curso con ID: {idCurso}");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudieron obtener los alumnos del curso con ID: {idCurso}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener los alumnos del curso");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener los alumnos del curso");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener los alumnos del curso: {ex.Message}");
            }
        }

        public static async Task<List<ProfesorCursoDetalleDTO>> GetProfesoresByCursoAsync(int idCurso)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"usuarios/cursos/{idCurso}/profesores");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ProfesorCursoDetalleDTO>>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"No se encontraron profesores para el curso con ID: {idCurso}");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudieron obtener los profesores del curso con ID: {idCurso}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener los profesores del curso");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener los profesores del curso");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener los profesores del curso: {ex.Message}");
            }
        }

        // Búsqueda CURSOS por Usuario (Profesor/Alumno)
        public static async Task<List<ShowProfesor_CursoDTO>> GetProfesorCursosAsync(int idProfesor)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"usuarios/{idProfesor}/profesor_cursos");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ShowProfesor_CursoDTO>>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"El profesor con ID: {idProfesor} no tiene cursos asignados o no existe");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudieron obtener los cursos del profesor con ID: {idProfesor}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener los cursos del profesor");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener los cursos del profesor");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener los cursos del profesor: {ex.Message}");
            }
        }

        public static async Task<List<ShowAlumno_CursoDTO>> GetAlumnoCursosAsync(int idAlumno)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"usuarios/{idAlumno}/alumno_cursos");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ShowAlumno_CursoDTO>>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"El alumno con ID: {idAlumno} no tiene cursos asignados o no existe");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudieron obtener los cursos del alumno con ID: {idAlumno}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar obtener los cursos del alumno");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al obtener los cursos del alumno");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al obtener los cursos del alumno: {ex.Message}");
            }
        }

        // Gestión de Inscripciones
        public static async Task AddAlumnoCursoAsync(Alumno_CursoDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("usuarios/alumno_cursos/", dto);
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException("No se pudo agregar la inscripción del alumno al curso");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar agregar la inscripción");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al agregar la inscripción");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al agregar la inscripción: {ex.Message}");
            }
        }

        public static async Task PutAlumnoCursoAsync(Alumno_CursoDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"usuarios/alumno_cursos/{dto.IdInscripcion}", dto);
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"No se encontró la inscripción con ID: {dto.IdInscripcion}");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException("No se pudo actualizar la inscripción del alumno");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar actualizar la inscripción");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al actualizar la inscripción");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al actualizar la inscripción: {ex.Message}");
            }
        }

        public static async Task DeleteAlumnoCursoAsync(int idInscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"usuarios/alumno_cursos/{idInscripcion}");
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"No se encontró la inscripción con ID: {idInscripcion}");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudo eliminar la inscripción con ID: {idInscripcion}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new ArgumentException("Error de conexión al intentar eliminar la inscripción");
            }
            catch (TaskCanceledException err)
            {
                throw new ArgumentException("Tiempo de espera agotado al eliminar la inscripción");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al eliminar la inscripción: {ex.Message}");
            }
        }

        // Gestión de Dictados
        public static async Task AddProfesorCursoAsync(Profesor_CursoDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("usuarios/profesor_cursos/", dto);
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException("No se pudo agregar la asignación del profesor al curso");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al intentar agregar la asignación del profesor");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("Tiempo de espera agotado al agregar la asignación del profesor");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al agregar la asignación del profesor: {ex.Message}");
            }
        }

        public static async Task DeleteProfesorCursoAsync(int idDictado)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"usuarios/profesor_cursos/{idDictado}");
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"No se encontró la asignación del profesor con ID: {idDictado}");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"No se pudo eliminar la asignación del profesor con ID: {idDictado}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new ArgumentException("Error de conexión al intentar eliminar la asignación del profesor");
            }
            catch (TaskCanceledException err)
            {
                throw new ArgumentException("Tiempo de espera agotado al eliminar la asignación del profesor");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al eliminar la asignación del profesor: {ex.Message}");
            }
        }
    }
}
