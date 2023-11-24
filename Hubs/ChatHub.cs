using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
	public async Task EnviarMensagem(string mensagem)
	{
        Console.WriteLine("Foi chamado enviar mensagem, enviando para os clientes...");
        await Clients.All.SendAsync("ReceberMensagem", mensagem);
	}
}