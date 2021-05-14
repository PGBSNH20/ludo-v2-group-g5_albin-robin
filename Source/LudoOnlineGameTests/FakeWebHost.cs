using System.Linq;
using System.Net.Http;
using Ludo_Web.MVC_Game.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LudoOnlineGameTests
{
    public class FakeWebHost<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
    {
        
        private readonly string _dbName = "MockDB";
        public IConfiguration Configuration { get; private set; }

        public new HttpClient CreateClient()
        {
            return base.CreateClient();
        }
        private LudoGameContext _inMemoryContext;
        public LudoGameContext InMemoryContext
        {
            get
            {
                if (_inMemoryContext == null)
                {
                    var options = new DbContextOptionsBuilder<LudoGameContext>()
                             .UseInMemoryDatabase(databaseName: _dbName)
                             .Options;
                    _inMemoryContext = new LudoGameContext(options);
                }
                return _inMemoryContext;
            }
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<LudoGameContext>));

                services.Remove(descriptor);
                
                services.AddDbContext<LudoGameContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName: _dbName);
                });
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var dbContext = scopedServices.GetRequiredService<LudoGameContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<FakeWebHost<TStartup>>>();

                    dbContext.Database.EnsureCreated();
                }
            });
        }
    }
}
