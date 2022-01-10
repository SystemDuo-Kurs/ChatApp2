using ChatApp2.Shared;
using Microsoft.AspNetCore.Identity;

namespace ChatApp2.Server
{
    public interface IKorisnikServis
    {
        Task<List<string>> Registruj(User user);

        Task<bool> Login(User user);

        Task<User> GetUserByName(string name);
    }

    public class KorisnikServis : IKorisnikServis
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger _logger;

        public KorisnikServis(ILogger<KorisnikServis> loger, UserManager<User> userManager)
        {
            _userManager = userManager;
            _logger = loger;
        }

        public async Task<User> GetUserByName(string name)
            => await _userManager.FindByNameAsync(name);

        public async Task<bool> Login(User user)
        {
            var korisnikZaista = await _userManager.FindByNameAsync(user.UserName);
            return await _userManager.CheckPasswordAsync(korisnikZaista, user.Password);
        }

        public async Task<List<string>> Registruj(User user)
        {
            _logger.LogInformation("Pokusaj registracije korisnika");
            var rezultat = await _userManager.CreateAsync(user, user.Password);
            List<string> greske = new();

            if (!rezultat.Succeeded)
                rezultat.Errors.ToList().ForEach(g => greske.Add(g.Description));

            return greske;
        }
    }
}