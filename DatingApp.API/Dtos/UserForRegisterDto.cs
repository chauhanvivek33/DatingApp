using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be 4 to 8 character long")]
        public string Password { get; set; }
    }
}