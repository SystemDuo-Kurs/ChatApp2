using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;

namespace ChatApp2.Client.ViewModeli
{
    public interface IPregledPoruka
    {
        ObservableCollection<Modeli.Message> Messages { get; }

        Task GetAll();
    }

    public class PregledPoruka : IPregledPoruka
    {
        public ObservableCollection<Modeli.Message> Messages { get; private set; } = new();

        private readonly SignalRService _signalRService;

        public PregledPoruka(SignalRService signalRService)
        {
            _signalRService = signalRService;
            _signalRService.ChatHub.On<List<ChatApp2.Shared.Message>>
                ("PorukeKaKlijentu", poruke =>
                poruke.ForEach(p => Messages.Add(p)));
            _signalRService.ChatHub.On<ChatApp2.Shared.Message>
                ("StiglaPoruka", poruka => Messages.Add(poruka));
            GetAll();
        }

        public async Task GetAll()
         => await _signalRService.ChatHub.SendAsync("SendMessages");
    }
}