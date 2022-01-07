using ChatApp2.Shared;

namespace ChatApp2.Server
{
    public interface IChatService
    {
        Task MsgRcv(Message m);
        List<Message> GetAllMessages();
    }
    public class ChatService : IChatService
    {
        private readonly ILogger _logger;
        private readonly Db _db;
        private readonly IKorisnikServis _korisnikServis;
        public ChatService(ILogger<ChatService> logger, Db db, IKorisnikServis korisnikServis)
        {
            _logger = logger;
            _db = db;
            _korisnikServis = korisnikServis;
        }


        public List<Message> GetAllMessages()
        {
            _db.AppUsers.ToList();
            var rez = _db.Messages.OrderBy(m => m.Sent).ToList();
            return rez ;
        }
        
        public async Task MsgRcv(Message m)
        {
            _logger.LogInformation("Msg rcvd :)");
            var user = await _korisnikServis.GetUserByName(m.User.UserName);
            m.User = user;
            _db.Add(m);
            _db.SaveChanges();
            _logger.LogInformation("Msg saved :)");
        }
    }
}
