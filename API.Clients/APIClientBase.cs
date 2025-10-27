using DTOs;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;

namespace API.Clients
{
    public abstract class APIClientBase
    {
        public static LoginResponse? LoginResponse { get; set; }
        
        protected static HttpClient CreateHttpClientAsync()
        {
            var client = new HttpClient();
            ConfigureHttpClientAsync(client);
            return client;
        }

        protected static void ConfigureHttpClientAsync(HttpClient client)
        {
            // Leer URL base de configuración, si no existe usar localhost por defecto
            string baseUrl = "https://localhost:7265/";
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // Agregar Bearer token automáticamente si está autenticado
            AddAuthorizationHeaderAsync(client);
        }

        protected static void AddAuthorizationHeaderAsync(HttpClient client)
        {
            if (IsTokenValid())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginResponse.Token);
            } else {
                LoginResponse = null; // Quizas podamos añadir refresh en un futuro
            }
        }

        // Cambiar a public para que Blazor pueda acceder
        public static bool IsTokenValid()
        {
            return !string.IsNullOrEmpty(LoginResponse?.Token) && DateTime.UtcNow < LoginResponse.ExpiresAt;
        }
    }
}