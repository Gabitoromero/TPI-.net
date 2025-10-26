using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;

namespace API.Clients
{
    public class APICurso : APIClientBase
    {
        private static HttpClient client;
        static APICurso()
        {
            client = CreateHttpClientAsync();
        }
        public static async Task<List<NewCursoDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("cursos");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<NewCursoDTO>>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return new List<NewCursoDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener los cursos");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener los cursos. Timeout superado");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("OOPS! Error al obtener los cursos");
            }
        }
        public static async Task<List<NewCursoDTO>> GetAllDisponiblesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("cursos/disponibles");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<NewCursoDTO>>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return new List<NewCursoDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener los cursos");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException("OOPS! Error al obtener los cursos. Timeout superado");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("OOPS! Error al obtener los cursos");
            }
        }
        public static async Task<NewCursoDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("cursos/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<NewCursoDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener el curso {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener el curso {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al obtener el curso {id}");
            }
        }

        public static async Task<NewCursoDTO> AddAsync(NewCursoDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("cursos", dto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<NewCursoDTO>();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al añadir el curso {dto.Id_curso}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir el curso {dto.Id_curso}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir el curso {dto.Id_curso}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al añadir el curso {dto.Id_curso}");
            }
        }

        public static async Task UpdateAsync(NewCursoDTO dto)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("cursos/", dto);
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al editar el curso {dto.Id_curso}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar el curso {dto.Id_curso}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al editar el curso {dto.Id_curso}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al editar el curso {dto.Id_curso}");
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("cursos/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"OOPS! Error al eliminar el curso {id}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar el curso {id}");
            }
            catch (TaskCanceledException ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar el curso {id}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"OOPS! Error al eliminar el curso {id}");
            }
        }
    }
}
