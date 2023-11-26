using BlinkNet;
using BlinkNet.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Servi�os necess�rios pra usar o Blazor, que fornecer� p�ginas din�micas pra construir uma Single Page Application, atualiza��es sem recarregar a p�gina.
// Al�m disso possui Interoperabilidade entre HTML e C# (razor)
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


//------------

builder.Services.AddScoped<IUserService, UserService>();

//------------


// Servi�o que adiciona a biblioteca que cont�m o Websocket pra comunica��o em tempo real do chat
builder.Services.AddSignalR();

// Servi�o necess�rio pra usar banco de dados, que nesse caso � um SQLite
builder.Services.AddDbContextFactory<MensagemContext>(opt =>
opt.UseSqlite("Data Source=mensagens.db"));


var app = builder.Build();

// Basicamente cria as tabelas do banco de dados caso n�o existam
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
