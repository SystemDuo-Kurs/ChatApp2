namespace ChatApp2.Client.Modeli

{
    public interface IUser
    {
        string UserName { get; set; }
        string UserMail { get; set; }
        string UserPassword { get; set; }
        ChatApp2.Shared.User UserDTO { get; }

    }
    public class User: IUser
    {
        private ChatApp2.Shared.User _userDTO=new();
        public ChatApp2.Shared.User UserDTO { get => _userDTO; }
        public string UserName
        {
            get => _userDTO.UserName;
            set => _userDTO.UserName = value;
        }
        public string UserMail
        {
            get => _userDTO.Email;
            set => _userDTO.Email = value;
        }
        public string UserPassword
        {
            get => _userDTO.Password;
            set => _userDTO.Password = value;
        }
    }

}
