using BlinkNet.Data;
using Microsoft.EntityFrameworkCore;

namespace BlinkNet
{
    public static class DatabaseUtility
    {
        public static async Task EnsureDbCreatedAsync(DbContextOptions<MensagemContext> options)
        {
            var factory = new LoggerFactory();
            var builder = new DbContextOptionsBuilder<MensagemContext>(options)
                .UseLoggerFactory(factory);

            using var context = new MensagemContext(builder.Options);
            await context.Database.EnsureCreatedAsync();
        }
    }
}