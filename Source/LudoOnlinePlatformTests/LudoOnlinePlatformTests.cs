using Xunit;
using System.Net.Http;
using Ludo_Web.MVC_Platform;
using LudoAPI.DataAccess;
using LudoAPI.Models.Account;

namespace LudoOnlinePlatformTests
{
    public class LudoOnlinePlatformTests : IClassFixture<FakeWebHost<Startup>>
    {
        private ILudoPlatformRepository _repository;
        private FakeWebHost<Startup> _fakeHost;
        public HttpClient Client { get; }
        public LudoOnlinePlatformTests(FakeWebHost<Startup> fakeHost)
        {
            _fakeHost = fakeHost;
            Client = fakeHost.CreateClient();
            _repository = new DbPlatformRepository(fakeHost.InMemoryContext);
        }
        [Fact]
        public void GetPlayerFromDb_ExpectCorrectEnum()
        {
            var player1 = new Account()
            {
                EmailAdress = "ace@ventura.com",
                Language = ModelEnum.Language.EnUs,
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
