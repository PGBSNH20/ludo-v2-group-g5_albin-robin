using System.Net.Http;
using Ludo_Web.MVC_Game;
using Ludo_Web.MVC_Game.DataAccess;
using Xunit;

namespace LudoOnlineGameTests
{
    public class LudoOnlineGameTests : IClassFixture<FakeWebHost<Startup>>
    {
        private ILudoGameRepository _repository;
        private FakeWebHost<Startup> _fakeHost;
        public HttpClient Client { get; }
        public LudoOnlineGameTests(FakeWebHost<Startup> fakeHost)
        {
            _fakeHost = fakeHost;
            Client = fakeHost.CreateClient();
            _repository = new DbGameRepository(fakeHost.InMemoryContext);
        }
      
    }
}
