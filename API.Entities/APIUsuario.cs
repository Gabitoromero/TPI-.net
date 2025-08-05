using System;
using System.Net;
using System.Net.Http;
using Domain.Model;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using DTOs;
using System.Net.Http.Json;

namespace API.Entities
{
    public class APIUsuario  //falta completar el CRUD de usuario
    {
        private static HttpClient client = new HttpClient();
        static APIUsuario()
        {
            client.BaseAddress = new Uri("https://localhost:7265/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
        public static async void DeleteAsync(int id) //no tiene que devolver nada
        {
            try
            {
                HttpResponseMessage resp = await client.DeleteAsync("usuarios/" + id);
                if (!resp.IsSuccessStatusCode)
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong deleting user with ID:{id}. Error: {errmen}");
                }
                return;
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
        public static async Task<PutUsuarioDTO> UpdateAsync(PutUsuarioDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await client.PutAsJsonAsync("usuarios", dto);
                if (resp.IsSuccessStatusCode)
                {
                    return await resp.Content.ReadFromJsonAsync<PutUsuarioDTO>();
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong updating user with ID:{dto.Id}. Eror:{errmen}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error ocurred while updating user with ID:{dto.Id}. Eror:{err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout updating user with ID:{dto.Id}. Eror:{err}");
            }
        }
        public static async Task<PostUsuarioDTO> AddAsync(PostUsuarioDTO dto)
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
