using DTOs;

namespace BlazorApp.Services
{
    public class AuthStateService
    {
        private LoginResponse? _currentUser;

        public event Action? OnAuthStateChanged;

        public LoginResponse? CurrentUser => _currentUser;

        public bool IsAuthenticated => _currentUser != null && DateTime.UtcNow < _currentUser.ExpiresAt;

        public bool IsAlumno => IsAuthenticated && _currentUser?.Tipo?.ToLower() == "alumno";

        public bool IsProfesor => IsAuthenticated && _currentUser?.Tipo?.ToLower() == "profesor";

        public bool IsAdmin => IsAuthenticated && _currentUser?.Tipo?.ToLower() == "admin";

        public void SetUser(LoginResponse user)
        {
            _currentUser = user;
            NotifyAuthStateChanged();
        }

        public void Logout()
        {
            _currentUser = null;
            NotifyAuthStateChanged();
        }

        private void NotifyAuthStateChanged()
        {
            OnAuthStateChanged?.Invoke();
        }
    }
}
