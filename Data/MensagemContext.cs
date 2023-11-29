using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BlinkNet.Data;

public class MensagemContext : DbContext
{
	public MensagemContext(DbContextOptions<MensagemContext> options) : base(options)
	{
		Debug.WriteLine($"{ContextId} context created.");
	}

	// Cria um contexto onde terá uma tabela no banco de dados SQLite que corresponde a classe de mensagens do chat
	public DbSet<ChatMensagem>? ChatMensagens { get; set; }

	public DbSet<Person>? People { get; set; }


	/*
	public MensagemContext(DbContextOptions<MensagemContext> options) : base(options)
	{
		Debug.WriteLine($"{ContextId} context created.");
	}

	public DbSet<ChatMensagem>? ChatMensagens { get; set; }


	public override void Dispose()
	{
		Debug.WriteLine($"{ContextId} context disposed.");
		base.Dispose();
	}

	public override ValueTask DisposeAsync()
	{
		Debug.WriteLine($"{ContextId} context disposed async");
		return base.DisposeAsync();
	}
	*/
}
