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

        public static async Task<ShowUsuarioDTO?> GetByUsernameAsync(string username) //para buscar usuario una vez iniciado sesion
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
                    throw new Exception($"OOPS! Failed to retrieve user by username. Status: {response.StatusCode}. Error:{errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving user by username. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving user by username. Error: {ex.Message}");
            }
        }
        public static async Task<List<ShowProfesor_CursoDTO>> GetProfesorCursosAsync(int idProfesor)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"usuarios/{idProfesor}/profesor_cursos");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ShowProfesor_CursoDTO>>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Failed to retrieve profesor cursos. Status: {response.StatusCode}. Error:{errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving profesor cursos. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving profesor cursos. Error: {ex.Message}");
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
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Failed to retrieve alumno cursos. Status: {response.StatusCode}. Error:{errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving alumno cursos. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving alumno cursos. Error: {ex.Message}");
            }
        }

        public static async Task<List<ShowUsuarioDTO>> GetProfesoresAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("usuarios/profesores/");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ShowUsuarioDTO>>();
                }
                else
                {
                    string errorMensage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong getting profesores. Eror: ${errorMensage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving profesores. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving profesores. Error: ${ex.Message}");
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
                else
                {
                    string errorMensage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong getting alumnos. Eror: ${errorMensage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving alumnos. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving alumnos. Error: ${ex.Message}");
            }
        }

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
                        throw new Exception("OOPS! Login response was null despite successful status code.");
                    }
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return false; // Credenciales inválidas
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Failed to login. Status: {response.StatusCode}. Error:{errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while trying to login. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout trying to login. Error: {ex.Message}");
            }
        }
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
                    throw new Exception($"OOPS! Failed to add alumno curso. Status: {response.StatusCode}. Error:{errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while adding alumno curso. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout adding alumno curso. Error: {ex.Message}");
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
                else
                {
                    string errorMensage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong getting users. Eror: ${errorMensage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving users. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving users. Error: ${ex.Message}");
            }
        }
        public static async Task DeleteAsync(int id) //no tiene que devolver nada
        {
            try
            {
                HttpResponseMessage resp = await client.DeleteAsync("usuarios/" + id);
                if (!resp.IsSuccessStatusCode)
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong deleting user with ID:{id}. Error: {errmen}");
                }
                
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error ocurred while retrieving user with ID:{id}. Eror:{err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout retrieving user with ID:{id}. Eror:{err}");
            }
        }
        
        public static async Task<FullUsuarioDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("usuarios/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FullUsuarioDTO>(); //mandamos en JSON poque el "ReadAsAsync" es de un paquete viejo
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Failed to retrieve user with ID:{id}. Status: {response.StatusCode}. Error:{errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving user with ID:{id}. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving user with ID: {id}. Error: {ex.Message}");
            }
        }
        
        public static async void UpdateAsync(PutUsuarioDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await client.PutAsJsonAsync("usuarios/", dto); //client realiza una peticion PUT
                if (resp.IsSuccessStatusCode)
                {
                    return;// await resp.Content.ReadFromJsonAsync();
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong updating user with ID:{dto.Id}. Error:{errmen}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error ocurred while updating user with ID:{dto.Id}. Error:{err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout updating user with ID:{dto.Id}. Error:{err}");
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
                    throw new Exception($"OOPS! Something went wrong posting user. Error:{errmen} ");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error ocurred while posting user. Error:{err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout posting user. Eror:{err}");
            }
        }

        
    }
}
