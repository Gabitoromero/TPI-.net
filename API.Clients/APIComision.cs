using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace API.Clients
{
    public class APIComision : APIClientBase
    {
        private static HttpClient client;
        static APIComision()
        {
            client = CreateHttpClientAsync();
        }
        public static async Task<List<ComisionDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("comisiones");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ComisionDTO>>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return new List<ComisionDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener las comisiones");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener las comisiones. Timeout superado");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("OOPS! Error al obtener las comisiones");
            }
        }

        public static async Task<ComisionDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("comisiones/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ComisionDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener la comision {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener la comision {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener la comision {id}");
            }
        }

        public static async Task<ComisionDTO> AddAsync(ComisionDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("comisiones", dto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ComisionDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al añadir la comision {dto.Desc_comision}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir la comision {dto.Desc_comision}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir la comision {dto.Desc_comision}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir la comision {dto.Desc_comision}");
            }
        }

        public static async Task UpdateAsync(ComisionDTO comision)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("comisiones/", comision);
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al editar la comision {comision.Desc_comision}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar la comision {comision.Desc_comision}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar la comision {comision.Desc_comision}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al editar la comision {comision.Desc_comision}");
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("comisiones/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al eliminar la comision {id}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar la comision {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar la comision {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar la comision {id}");
            }
        }
    }
}
