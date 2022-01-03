using Microsoft.AspNetCore.SignalR.Client;

namespace ChatApp2.Client.ViewModeli
{
    public interface ISlanjePoruke
    {
        Modeli.IMessage Poruka { get; }
        Task Slanje();
    }
    public class SlanjePoruke : ISlanjePoruke
    {
        private readonly Modeli.IMessage _poruka;
        public Modeli.IMessage Poruka { get => _poruka; }

        private readonly SignalRService _signalRService;
        private readonly Blazored.LocalStorage.ILocalStorageService _localStore;

        public SlanjePoruke(Modeli.IMessage poruka, SignalRService signalRService
            , Blazored.LocalStorage.ILocalStorageService localStore)
        {
            _poruka = poruka;
            _signalRService = signalRService;
            _localStore = localStore;
        }

        public async Task Slanje()
        {
            _poruka.Sent = DateTime.Now;
            _poruka.MessageDTO.User = new();
            _poruka.MessageDTO.User.UserName =
                await _localStore.GetItemAsync<string>("ulogovan");
            await _signalRService.ChatHub.SendAsync("MsgRcv", _poruka.MessageDTO);
            _poruka.Content = String.Empty;
        }
    }
}
