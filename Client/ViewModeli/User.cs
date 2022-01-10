using ChatApp2.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatApp2.Client.ViewModeli
{
    public interface IUser
    {
        Task Registracija();

        Task Login();

        Modeli.IUser UserModel { get; }
        Status StatusOperacije { get; }
        Action WorkComplete { get; set; }
    }

    public class User : IUser
    {
        private readonly Modeli.IUser _userModel;
        public Modeli.IUser UserModel { get => _userModel; }

        public Status StatusOperacije { get; private set; }
        private readonly SignalRService _signalRService;
        private readonly Blazored.LocalStorage.ILocalStorageService _localStore;
        private readonly NavigationManager _navMan;

        public Action WorkComplete { get; set; }

        public User(Modeli.IUser user, SignalRService signalRService,
            Blazored.LocalStorage.ILocalStorageService localStore,
            NavigationManager nm)
        {
            _userModel = user;
            _signalRService = signalRService;
            _localStore = localStore;
            _navMan = nm;
            _signalRService.UserHub.On<bool>("login", b => { if (b) Sacuvaj(); });
            _signalRService.UserHub.On<Status>("status", s =>
            {
                StatusOperacije = s;
                WorkComplete?.Invoke();
            });
        }

        public async void Sacuvaj()
        {
            await _localStore.SetItemAsync<string>("ulogovan", UserModel.UserName);
            _navMan.NavigateTo("/", true);
        }

        public async Task Registracija()
        {
            await _signalRService.UserHub.SendAsync("Registracija", _userModel.UserDTO);
        }

        public async Task Login()
        {
            await _signalRService.UserHub.SendAsync("Login", _userModel.UserDTO);
        }
    }
}