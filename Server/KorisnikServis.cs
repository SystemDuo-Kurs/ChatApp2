using ChatApp2.Shared;

namespace ChatApp2.Server
{
    public interface IKorisnikServis 
    {
        void Registruj(User user);
    }

    public class KorisnikServis:IKorisnikServis
    {
        private readonly Db _db;
        private readonly ILogger _logger;   
        public KorisnikServis(Db db,ILogger<KorisnikServis> loger) 
        {
            _db = db;
            _logger = loger;
        }

        public void Registruj(User user)
        {
            _logger.LogInformation("Pokusaj registracije korisnika");
            if (_db.Users.Where(u => u.Name.ToLower() == user.Name.ToLower()
                || u.Mail.ToLower()==user.Mail.ToLower()).Any())
            {
                _logger.LogError("Korisnik vec postoji");
                
            }else
            {
                _db.Add(user);
                _db.SaveChanges();
                _logger.LogInformation("Korisnik registrovan");
            }

         

        }
            
    }
}