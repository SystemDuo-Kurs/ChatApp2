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
        public void Registracija(User user)
        {
            _logger.LogInformation("Registracija je u toku");
            _korisnikServis.Registruj(user);

        }
    }
}
