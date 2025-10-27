using DTOs;
using API.Clients;

namespace BlazorApp.Services
{
    /// <summary>
    /// Contenedor de estado ligero para notificar cambios en la autenticación.
    /// NO duplica el LoginResponse, solo notifica cambios.
    /// </summary>
    public class AuthStateContainer
    {
        /// <summary>
        /// Evento que se dispara cuando cambia el estado de autenticación
        /// </summary>
        public event Action? OnAuthStateChanged;

        /// <summary>
        /// Propiedad que lee directamente de APIClientBase.LoginResponse
        /// </summary>
        public LoginResponse? CurrentUser => APIClientBase.LoginResponse;

        /// <summary>
        /// Verifica si está autenticado leyendo de APIClientBase
        /// </summary>
        public bool IsAuthenticated => APIClientBase.IsTokenValid();

        /// <summary>
        /// Notifica a todos los suscriptores que el estado cambió
        /// Debe llamarse después de login o logout
        /// </summary>
        public void NotifyStateChanged()
        {
            OnAuthStateChanged?.Invoke();
        }
    }
}
