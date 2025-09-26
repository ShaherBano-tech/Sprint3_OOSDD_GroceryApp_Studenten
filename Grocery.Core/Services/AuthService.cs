using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientService _clientService;
        public AuthService(IClientService clientService)
        {
            _clientService = clientService;
        }
        public Client? Login(string email, string password)
        {
            Client? client = _clientService.Get(email);
            if (client == null) return null;
            if (PasswordHelper.VerifyPassword(password, client.Password)) return client;
            return null;
        }

        public bool Register(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return false;

            if (_clientService.ExistsByEmail(email))
                return false;

            var namePart = email.Split('@')[0];
            var DisplayName = string.IsNullOrWhiteSpace(namePart) ? "Nieuwe gebruiker" : namePart;
            var hash = PasswordHelper.HashPassword(password);
            var newClient = new Client(0, DisplayName, email, hash);

            _clientService.Add(newClient);
            return true;
        }
    }
}
