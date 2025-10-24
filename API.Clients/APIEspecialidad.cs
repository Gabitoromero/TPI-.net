using DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class APIEspecialidad : APIClientBase
    {
        private static HttpClient esp;
        static APIEspecialidad()
        {
            esp = CreateHttpClientAsync();
        }

        public static async Task<EspecialidadDTO> GetAsync(int id)
        {
            try
            {
                Debug.WriteLine($"🌐 Authorization Header: {esp.DefaultRequestHeaders.Authorization}");
                Debug.WriteLine($"🌐 Scheme: {esp.DefaultRequestHeaders.Authorization?.Scheme}");
                Debug.WriteLine($"🌐 Parameter: {esp.DefaultRequestHeaders.Authorization?.Parameter}");

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
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
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
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public static async Task DeleteAsync(int id)
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
                throw new Exception($"OOPS! A connection error ocurred while deleting speciality with ID:{id}. Error:{err.Message}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout deleting speciality with ID:{id}. Error:{err.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
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
                throw new Exception($"OOPS! A connection error ocurred while posting speciality. Error:{err.Message}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout posting speciality. Error:{err.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public static async Task<EspecialidadDTO> PutAsync(EspecialidadDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await esp.PutAsJsonAsync("especialidades", dto);
                if (resp.IsSuccessStatusCode)
                {
                    // If server responds 204 NoContent or body is empty, avoid parsing JSON empty content.
                    if (resp.StatusCode == HttpStatusCode.NoContent)
                    {
                        return dto; // update succeeded, return the sent object (or change to null if preferred)
                    }
                    // If Content-Length is zero or content is whitespace, return dto as well.
                    var contentString = await resp.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(contentString))
                    {
                        return dto;
                    }

                    // Otherwise parse the returned JSON into DTO.
                    return JsonSerializer.Deserialize<EspecialidadDTO>(contentString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Failed to update speciality. Error: {errmen}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error ocurred while updating speciality. Error:{err.Message}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout updating speciality. Error:{err.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
