using DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WindowsForms
{
    public class PlanApiClient
    {
        private static HttpClient client = new HttpClient();

        static PlanApiClient() { 
            client.BaseAddress = new Uri("https://localhost:5183");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<PlanDTO> GetAsync(int id) { 
            PlanDTO planDTO = null;
            HttpResponseMessage response = await client.GetAsync($"/planes/{id}");

            if (response.IsSuccessStatusCode) {
                planDTO = await response.Content.ReadAsAsync<PlanDTO>();
            }

            return planDTO;
        }
        



    }
}
