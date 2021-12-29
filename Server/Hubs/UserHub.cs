using ChatApp2.Shared;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp2.Server.Hubs
{
    public class UserHub : Hub
    {
        private readonly IKorisnikServis _korisnikServis;   
        private readonly ILogger _logger;
        public UserHub(IKorisnikServis korisnikServis, ILogger<UserHub> logger)
        {
            _korisnikServis = korisnikServis;
            _logger = logger;
        }
        public async Task Registracija(User user)
        {
            _logger.LogInformation("Registracija je u toku");
            await _korisnikServis.Registruj(user);

        }
        public async Task Login(User user)
        {
            _logger.LogInformation("Login je u toku");
            var rez = await _korisnikServis.Login(user);
            if (rez)
                _logger.LogInformation("Login OK");
            else
                _logger.LogError("Login JOK");
            await Clients.Caller.SendAsync("login", rez);

        }
    }
}
