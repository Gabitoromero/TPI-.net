using DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace API.Clients
{
    public class APIPlan : APIClientBase
    {
        private static HttpClient client;
        static APIPlan()
        {
            client = CreateHttpClientAsync();
        }
        public static async Task<PlanDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("planes/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PlanDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Failed to retrieve plan with ID:{id}. Status: {response.StatusCode}. Error:{errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving plan with ID:{id}. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving plan with ID: {id}. Error: {ex.Message}");
            }
        }
        public static async Task<List<PlanDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("planes");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<PlanDTO>>();
                }
                else
                {
                    string errorMensage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong getting plans. Eror: ${errorMensage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while retrieving plans. Error: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout retrieving plans. Error: ${ex.Message}");
            }
        }
        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage resp = await client.DeleteAsync("planes/" + id);
                if (!resp.IsSuccessStatusCode)
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong deleting plan with ID:{id}. Error: {errmen}");
                }
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error ocurred while retrieving plan with ID:{id}. Eror:{err}");
            }
            catch (TaskCanceledException err)
            {
                throw new Exception($"Timeout retrieving plan with ID:{id}. Eror:{err}");
            }
        }
        public static async Task<PlanDTO> AddAsync(PlanDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await client.PostAsJsonAsync("planes/", dto);
                if (resp.IsSuccessStatusCode)
                {
                    return await resp.Content.ReadFromJsonAsync<PlanDTO>();
                }
                else
                {
                    string errmen = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong posting plan. Error:{errmen} ");
                }
            }
            catch (SystemException err)
            {
                throw new Exception(err.Message);
            }
            catch (HttpRequestException err)
            {
                throw new Exception($"OOPS! A connection error ocurred while posting plan. Error:{err}");
            }
        }
        public static async Task UpdateAsync(PlanDTO dto)
        {
            try
            {
                HttpResponseMessage resp = await client.PutAsJsonAsync("planes/", dto);

                if (resp.IsSuccessStatusCode)
                {
                    return ;
                }
                else
                {
                    string errorContent = await resp.Content.ReadAsStringAsync();
                    throw new Exception($"OOPS! Something went wrong updating plan. Error: {errorContent}");
                }
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout updating plan. Error: {ex.Message}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"OOPS! A connection error occurred while updating plan. Error: {ex.Message}");
            }

        }
    }
}
