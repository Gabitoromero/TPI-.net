using DTOs;
using API.Clients;

namespace BlazorApp.Services
{
    /// Contenedor de estado ligero para notificar cambios en la autenticación.
    public class AuthStateContainer
    {

        public event Action? OnAuthStateChanged;
        public LoginResponse? CurrentUser => APIClientBase.LoginResponse;
        public bool IsAuthenticated => APIClientBase.IsTokenValid();
        public void NotifyStateChanged()
        {
            OnAuthStateChanged?.Invoke();
        }
    }
}
