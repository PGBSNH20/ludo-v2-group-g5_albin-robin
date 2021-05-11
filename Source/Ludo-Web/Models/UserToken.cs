using System;
using System.ComponentModel.DataAnnotations;

namespace Ludo_Web.Models
{
    public record UserToken
    {
        [Key]
        public string Token { get; set; }
        public Player Player { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}