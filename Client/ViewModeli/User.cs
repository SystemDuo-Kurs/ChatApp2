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
        public User(Modeli.IUser user,SignalRService signalRService)
        {
            _userModel = user;  
            _signalRService = signalRService;
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
