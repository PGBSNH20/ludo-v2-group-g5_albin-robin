using System;
using System.ComponentModel.DataAnnotations;

namespace Ludo_Web.MVC.Models.Account
{
    public record AccountToken
    {
        [Key]
        public string Token { get; set; }
        public Account Account { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}