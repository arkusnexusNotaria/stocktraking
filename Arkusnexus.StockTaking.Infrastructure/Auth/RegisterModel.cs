using System.ComponentModel.DataAnnotations;

namespace Arkusnexus.StockTaking.Infrastructure.Auth
{
    public class RegisterModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; } 

        public string Pwd { get; set; }

    }
}
