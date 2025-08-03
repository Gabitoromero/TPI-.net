using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Entities
{
    public class APIModulo
    {
        private static HttpClient client = new HttpClient();

        static APIModulo()
        {
            client.BaseAddress = new Uri("https://localhost:7265/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<ModuloDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("modulos/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ModuloDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Failed to retrieve module with ID:{id}. Status: {response.StatusCode}. Error:{errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving module with ID:{id}. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving module with ID: {id}. Error: {ex.Message}");
            }
        }

        public static async Task<List<ModuloDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("modulos");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ModuloDTO>>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong getting modules. Error: {errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving modules. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving modules. Error: {ex.Message}");
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage resp = await client.DeleteAsync("modulos/" + id);
                if (!resp.IsSuccessStatusCode)
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong deleting module with ID:{id}. Error: {errmen}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error occurred while deleting module with ID:{id}. Error: {err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout deleting module with ID:{id}. Error: {err}");
            }
        }

        public static async Task<ModuloDTO> AddAsync(ModuloDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await client.PostAsJsonAsync("modulos/", dto);
                if (resp.IsSuccessStatusCode)
                {
                    return await resp.Content.ReadFromJsonAsync<ModuloDTO>();
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong posting module. Error:{errmen}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error occurred while posting module. Error:{err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout posting module. Error:{err}");
            }
        }

        public static async Task<ModuloDTO> UpdateAsync(ModuloDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await client.PutAsJsonAsync("modulos/", dto);
                if (!resp.IsSuccessStatusCode)
                {
                    string errorContent = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong updating module. Error: {errorContent}");
                }

                return await resp.Content.ReadFromJsonAsync<ModuloDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while updating module. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout updating module. Error: {ex.Message}");
            }
        }
    }
}
