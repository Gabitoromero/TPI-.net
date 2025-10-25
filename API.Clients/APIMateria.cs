using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace API.Clients
{
    public class APIMateria : APIClientBase
    {
        private static HttpClient client;
        static APIMateria()
        {
            client = CreateHttpClientAsync();
        }

        public static async Task<List<MateriaDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("materias");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<MateriaDTO>>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return new List<MateriaDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener las materias");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener las materias. Timeout superado");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("OOPS! Error al obtener las materias");
            }
        }

        public static async Task<MateriaDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("materias/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<MateriaDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener la materia {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener la materia {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener la materia {id}");
            }
        }

        public static async Task<MateriaDTO> AddAsync(MateriaDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("materias", dto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<MateriaDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al añadir la materia {dto.Desc_materia}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir la materia {dto.Desc_materia}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir la materia {dto.Desc_materia}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir la materia {dto.Desc_materia}");
            }
        }

        public static async Task UpdateAsync(MateriaDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("materias/", dto);
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al editar la materia {dto.Desc_materia}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar la materia {dto.Desc_materia}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar la materia {dto.Desc_materia}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al editar la materia {dto.Desc_materia}");
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("materias/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al eliminar la materia {id}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar la materia {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar la materia {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar la materia {id}");
            }
        }
    }
}
