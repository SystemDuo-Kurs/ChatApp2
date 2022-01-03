using ChatApp2.Server;
using ChatApp2.Server.Hubs;
using ChatApp2.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddDbContext<Db>
    (options=>options.UseSqlServer
    (builder.Configuration.GetConnectionString("Baza")));
builder.Services.AddTransient<IKorisnikServis, KorisnikServis>();
builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<Db>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.MapHub<UserHub>("uHub");
app.MapHub<ChatHub>("cHub");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
