namespace ChatApp2.Client.Modeli
{
    public interface IMessage
    {
        ChatApp2.Shared.Message MessageDTO { get; }

        string Content { get; set; }
        DateTime Sent { get; set; }

    }
    public class Message : IMessage
    {
        private ChatApp2.Shared.Message _message = new();
        public ChatApp2.Shared.Message MessageDTO { get => _message; }

        public string Content { get => _message.Content; set => _message.Content = value; }
        public DateTime Sent { get => _message.Sent; set => _message.Sent = value;}
        public string UserName { get => _message.User?.UserName; }

        public static implicit operator Message(ChatApp2.Shared.Message m)
            => new Message {  _message = m };

    }
}
