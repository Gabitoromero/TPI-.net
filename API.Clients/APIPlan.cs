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
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return new List<PlanDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener los planes");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener los planes. Timeout superado");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("OOPS! Error al obtener los planes");
            }
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
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener el plan {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener el plan {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener el plan {id}");
            }
        }

        public static async Task<PlanDTO> AddAsync(PlanDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("planes/", dto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PlanDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al añadir el plan {dto.Descripcion}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir el plan {dto.Descripcion}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir el plan {dto.Descripcion}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir el plan {dto.Descripcion}");
            }
        }

        public static async Task UpdateAsync(PlanDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("planes/", dto);
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al editar el plan {dto.Descripcion}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar el plan {dto.Descripcion}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar el plan {dto.Descripcion}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al editar el plan {dto.Descripcion}");
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("planes/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al eliminar el plan {id}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar el plan {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar el plan {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar el plan {id}");
            }
        }
    }
}
