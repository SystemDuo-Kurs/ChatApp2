using ChatApp2.Shared;
using Microsoft.AspNetCore.Identity;

namespace ChatApp2.Server
{
    public interface IKorisnikServis 
    {
        Task Registruj(User user);
        Task<bool> Login(User user);
    }

    public class KorisnikServis:IKorisnikServis
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger _logger;   
        public KorisnikServis(ILogger<KorisnikServis> loger, UserManager<User> userManager) 
        {
            _userManager = userManager;
            _logger = loger;
        }

        public async Task<bool> Login(User user)
        {
            var korisnikZaista = await _userManager.FindByNameAsync(user.UserName);
            return await _userManager.CheckPasswordAsync(korisnikZaista, user.Password);
        }

        public async Task Registruj(User user)
        {
            _logger.LogInformation("Pokusaj registracije korisnika");
            var rezultat = await _userManager.CreateAsync(user, user.Password);



            /*if (_db.Users.Where(u => u.Name.ToLower() == user.Name.ToLower()
                || u.Mail.ToLower()==user.Mail.ToLower()).Any())
            {
                _logger.LogError("Korisnik vec postoji");
                
            }else
            {
                _db.Add(user);
                _db.SaveChanges();
                _logger.LogInformation("Korisnik registrovan");
            }*/



        }
            
    }
}