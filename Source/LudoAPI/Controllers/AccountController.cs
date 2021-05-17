using System.Collections.Generic;
using LudoAPI.Authentication;
using LudoAPI.DataAccess;
using LudoAPI.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
            return Ok();
        }
    }
}