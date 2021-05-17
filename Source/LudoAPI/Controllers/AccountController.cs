using System;
using System.Collections.Generic;
using System.Linq;
using LudoAPI.Authentication;
using LudoAPI.DataAccess;
using LudoAPI.Models.Account;
using LudoAPI.Translation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;

namespace LudoAPI.Controllers 
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
     private readonly ILudoRepository _repository;
       private readonly IConfiguration _configuration;
       public AccountController(ILudoRepository repository, IConfiguration configuration)
        {
            _repository = repository;
           _configuration = configuration;
        }
        
        
        [Authorize]
        [HttpGet]
        [Route("GetAccounts")]
        public List<Account> GetAccounts()
        {
            return new List<Account>();
        }   
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            if (_repository.Accounts.SingleOrDefault(a => a.PlayerName == model.AccountName) != null)
                return Conflict();
            var account = new Account();
            var lang = TranslationEngine.ParseEnum(model.PreferredLanguage);
            if (TranslationEngine.EnumExists(model.PreferredLanguage))
            {
                account.Language = TranslationEngine.ParseEnum(model.PreferredLanguage);
                return Ok(account.Language.ToString());
            }
            var enums = Enum.GetValues<TranslationEngine.Language>()
                .Select(language => language.ToString()).ToList();
            var message = "The chosen language was not found. Please pick one of below:\n";
            enums.ForEach(l => message+= l + "\n");
            return NotFound(message);
        }
    }
}