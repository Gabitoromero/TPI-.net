using DTOs;
using API.Clients;

namespace BlazorApp.Services
{
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
