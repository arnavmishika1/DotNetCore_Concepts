using System.ComponentModel.DataAnnotations;

namespace ConcertBooking.UI.ViewModels.UserInfoViewModels
{
    public class UserInfoViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Apko user name field ko fill krna hai")]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
