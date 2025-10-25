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
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return new List<EspecialidadDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener las especialidades");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener las especialidades. Timeout superado");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("OOPS! Error al obtener las especialidades");
            }
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
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener la especialidad {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener la especialidad {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener la especialidad {id}");
            }
        }

        public static async Task<EspecialidadDTO> AddAsync(NewEspecialidadDTO dto)
        {
            try
            {
                HttpResponseMessage response = await esp.PostAsJsonAsync("especialidades", dto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<EspecialidadDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al añadir la especialidad {dto.Descripcion}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir la especialidad {dto.Descripcion}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir la especialidad {dto.Descripcion}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir la especialidad {dto.Descripcion}");
            }
        }

        public static async Task UpdateAsync(EspecialidadDTO dto)
        {
            try
            {
                HttpResponseMessage response = await esp.PutAsJsonAsync("especialidades", dto);
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al editar la especialidad {dto.Descripcion}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar la especialidad {dto.Descripcion}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar la especialidad {dto.Descripcion}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al editar la especialidad {dto.Descripcion}");
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await esp.DeleteAsync("especialidades/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al eliminar la especialidad {id}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar la especialidad {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar la especialidad {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar la especialidad {id}");
            }
        }
    }
}
