using Microsoft.AspNetCore.SignalR.Client;
namespace ChatApp2.Client.ViewModeli
{
    public interface IPregledPoruka
    {
        List<ChatApp2.Shared.Message> Messages{get;}
        Task GetAll();
    }
    public class PregledPoruka : IPregledPoruka
    {
        public List<ChatApp2.Shared.Message> Messages { get; private set; } = new();

        private readonly SignalRService _signalRService;
        public PregledPoruka(SignalRService signalRService)
        { 
            _signalRService = signalRService;
            _signalRService.ChatHub.On<List<ChatApp2.Shared.Message>>
                ("PorukeKaKlijentu", poruke => Test(poruke));
            GetAll();
        }

        private void Test(List<ChatApp2.Shared.Message> poruke)
        {
            Messages = poruke;
        }
        public async Task GetAll()
         => await _signalRService.ChatHub.SendAsync("SendMessages");
        
    }
}
