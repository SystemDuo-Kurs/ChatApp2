using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatApp2.Client.ViewModeli
{
    public interface IUser
    {
        void Registracija();
        void Login();
        Modeli.IUser UserModel { get; }
    }
    public class User:IUser
    {
        private readonly Modeli.IUser _userModel;
        public Modeli.IUser UserModel { get=>_userModel; }
        private readonly SignalRService _signalRService;
        private readonly Blazored.LocalStorage.ILocalStorageService _localStore;
        private readonly NavigationManager _navMan;
        public User(Modeli.IUser user,SignalRService signalRService,
            Blazored.LocalStorage.ILocalStorageService localStore,
            NavigationManager nm)
        {
            _userModel = user;  
            _signalRService = signalRService;
            _localStore = localStore;
            _navMan = nm;
            _signalRService.UserHub.On<bool>("login", b => { if (b) Sacuvaj(); } );
        }

        public async void Sacuvaj()
        {
            await _localStore.SetItemAsync<string>("ulogovan", UserModel.UserName);
            _navMan.NavigateTo("/", true);
        }

        public async void Registracija()
        {
            await _signalRService.UserHub.SendAsync("Registracija",_userModel.UserDTO);
        }
        public async void Login()
        {
            await _signalRService.UserHub.SendAsync("Login", _userModel.UserDTO);
        }
    }
}
