using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace API.Clients
{
    public class APIEspecialidad
    {
        private static HttpClient esp = new HttpClient();
        static APIEspecialidad()
        {
            esp.BaseAddress = new Uri("https://localhost:7265/");
            esp.DefaultRequestHeaders.Accept.Clear();
            esp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<EspecialidadDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await esp.GetAsync("especialidades/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<EspecialidadDTO>(); 
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Failed to retrieve speciality with ID:{id}. Status: {response.StatusCode}. Error:{errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving speciality with ID:{id}. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving speciality with ID: {id}. Error: {ex.Message}");
            }
        }
        public static async Task<List<EspecialidadDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await esp.GetAsync("especialidades");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<EspecialidadDTO>>();
                }
                else
                {
                    string errorMensage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong getting specialities. Error: ${errorMensage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving specialities. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving specialities. Error: ${ex.Message}");
            }
        }
        public static async void DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage resp = await esp.DeleteAsync("especialidades/" + id);
                if (resp.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong deleting speciality with ID:{id}. Error: {errmen}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error ocurred while retrieving speciality with ID:{id}. Error:{err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout retrieving speciality with ID:{id}. Error:{err}");
            }
        }
        public static async Task<EspecialidadDTO> AddAsync(NewEspecialidadDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await esp.PostAsJsonAsync("especialidades", dto);
                if (resp.IsSuccessStatusCode)
                {
                    return await resp.Content.ReadFromJsonAsync<EspecialidadDTO>();
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong posting speciality. Error:{errmen} ");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error ocurred while posting speciality. Error:{err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout posting speciality. Error:{err}");
            }
        }
        public static async Task<EspecialidadDTO> PutAsync(EspecialidadDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await esp.PutAsJsonAsync("especialidades", dto);
                if (resp.IsSuccessStatusCode)
                {
                    return await resp.Content.ReadFromJsonAsync<EspecialidadDTO>();
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"Error: {errmen}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"Error:{err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Error:{err}");
            }
        }
    }
}
