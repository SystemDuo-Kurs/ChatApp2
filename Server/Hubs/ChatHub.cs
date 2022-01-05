using ChatApp2.Shared;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp2.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatServis;
        private readonly ILogger _logger;
        public ChatHub(IChatService chatServis, ILogger<UserHub> logger)
        {
            _chatServis = chatServis;
            _logger = logger;
        }

        public async Task MsgRcv(Message m)
        {
            _logger.LogInformation("SignalR msg rcvd :)");
            await _chatServis.MsgRcv(m);
            _logger.LogInformation("SignalR done");
        }

        public async Task SendMessages()
        {
            _logger.LogInformation("Getting all messages");
            var tst = _chatServis.GetAllMessages();
            await Clients.Caller.SendAsync("PorukeKaKlijentu", tst);
        }
    }
}
