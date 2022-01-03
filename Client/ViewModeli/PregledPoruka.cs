using Microsoft.AspNetCore.SignalR.Client;
namespace ChatApp2.Client.ViewModeli
{
    public class PregledPoruka
    {
        public List<ChatApp2.Shared.Message> Messages { get; private set; } = new();

        private readonly SignalRService _signalRService;
        public PregledPoruka(SignalRService signalRService)
        { 
            _signalRService = signalRService;
            _signalRService.ChatHub.On<List<ChatApp2.Shared.Message>>
                ("PorukeKaKlijentu", poruke => Messages = poruke);
        }

        public async Task GetAll()
         => await _signalRService.ChatHub.SendAsync("SendMessages");
        
    }
}
