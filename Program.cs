using BlinkNet;
using BlinkNet.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Serviços necessários pra usar o Blazor, que fornecerá páginas dinâmicas pra construir uma Single Page Application, atualizações sem recarregar a página.
// Além disso possui Interoperabilidade entre HTML e C# (razor)
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


//------------

builder.Services.AddScoped<IUserService, UserService>();

//------------


// Serviço que adiciona a biblioteca que contém o Websocket pra comunicação em tempo real do chat
builder.Services.AddSignalR();

// Serviço necessário pra usar banco de dados, que nesse caso é um SQLite
builder.Services.AddDbContextFactory<MensagemContext>(opt =>
opt.UseSqlite("Data Source=mensagens.db"));


var app = builder.Build();

// Basicamente cria as tabelas do banco de dados caso não existam
await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<MensagemContext>>();
await DatabaseUtility.EnsureDbCreatedAsync(options);

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// mapeamento usado para escutar e ativar eventos HUB pelo SignalR
app.MapHub<ChatHub>("/chathub");

app.Run();
