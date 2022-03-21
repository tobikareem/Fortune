
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class UserForm
    {
        [Required(ErrorMessage = "*First Name is required"), Display(Name = "First Name"), MinLength(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*Last Name is required"), Display(Name = "Last Name"), MinLength(2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*Email is required"), Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Message is required"), Display(Name = "Message")]
        public string Message { get; set; }
    }
}
