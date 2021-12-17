using Microsoft.AspNetCore.SignalR;

namespace ChatApp2.Server.Hubs
{
    public class ChatHub : Hub
    {
        public void Test()
        {
            Console.WriteLine("SSSSD");
        }
    }
}
