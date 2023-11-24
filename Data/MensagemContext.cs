using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BlinkNet.Data;

public class MensagemContext : DbContext
{
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
}
