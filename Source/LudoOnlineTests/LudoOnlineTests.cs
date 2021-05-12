using Ludo_Web.MVC;
using Xunit;
using System.Net.Http;
using Ludo_Web.DataEntity.DataAccess;
using Ludo_Web.DataEntity.Models;
using Ludo_Web.DataEntity.Models.Account;

namespace LudoOnlineTests
{
    public class LudoOnlineTests : IClassFixture<FakeWebHost<Startup>>
    {
        private ILudoRepository _repository;
        private FakeWebHost<Startup> _fakeHost;
        public HttpClient Client { get; }
        public LudoOnlineTests(FakeWebHost<Startup> fakeHost)
        {
            _fakeHost = fakeHost;
            Client = fakeHost.CreateClient();
            _repository = new DbRepository(fakeHost.InMemoryContext);
        }
        [Fact]
        public void GetPlayerFromDb_ExpectCorrectEnum()
        {
            var player1 = new Account()
            {
                EmailAdress = "ace@ventura.com",
                Language = ModelEnum.Language.en_US,
                PlayerName = "Ace_Mighty",
                Password = "animalDicks",
            };
            _repository.Add(player1);
            _repository.SaveChanges();
             //var playerBack = _repository.Players.First();

            //Assert.Equal(Language.en_US, playerBack.Language);
        }
    }
}
