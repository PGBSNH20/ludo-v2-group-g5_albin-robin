using Ludo_Web.MVC;
using System;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Ludo_Web.DataAccess;
using Ludo_Web.MVC.Models;

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
        public void GetPersonFromDb_ExpectCorrectEnum()
        {
            var player1 = new Player()
            {
                EmailAdress = "ace@ventura.com",
                Language = PropertyEnums.Language.en_US,
                PlayerName = "Ace_Mighty",
                Password = "animalDicks",
                PlayerType = PropertyEnums.PlayerType.Professional
            };
            _repository.Add(player1);
            _repository.SaveChanges();
             var playerBack = _repository.Players.First();

            Assert.Equal(PropertyEnums.PlayerType.Professional, playerBack.PlayerType);
            Assert.Equal(PropertyEnums.Language.en_US, playerBack.Language);
        }
    }
}
