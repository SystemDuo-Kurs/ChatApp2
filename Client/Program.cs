using Blazored.LocalStorage;
using ChatApp2.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<SignalRService>();
builder.Services.AddTransient<ChatApp2.Client.Modeli.IUser, ChatApp2.Client.Modeli.User>();
builder.Services.AddTransient<ChatApp2.Client.ViewModeli.IUser, ChatApp2.Client.ViewModeli.User>();
builder.Services.AddTransient<ChatApp2.Client.Modeli.IMessage, ChatApp2.Client.Modeli.Message>();
builder.Services.AddTransient<ChatApp2.Client.ViewModeli.ISlanjePoruke, ChatApp2.Client.ViewModeli.SlanjePoruke>();
builder.Services.AddTransient<ChatApp2.Client.ViewModeli.IPregledPoruka, ChatApp2.Client.ViewModeli.PregledPoruka>();

builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();
app.Services.GetService<SignalRService>();
await app.RunAsync();
