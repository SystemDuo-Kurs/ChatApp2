using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;


namespace ChatApp2.Client
{
    public class SignalRService
    {
        public HubConnection ChatHub { get; set; }
        public HubConnection UserHub { get; set; }
        public SignalRService(NavigationManager nm)
        {
            var builder = new HubConnectionBuilder();
            
            builder.WithUrl(nm.BaseUri + "cHub");
            
            ChatHub = builder.Build();

            UserHub = new HubConnectionBuilder()
                .WithUrl(nm.BaseUri + "uHub")
                .Build();
            Start();
        }
        private async void Start()
        {
            await UserHub.StartAsync();
            await ChatHub.StartAsync();

        }
    }
}
