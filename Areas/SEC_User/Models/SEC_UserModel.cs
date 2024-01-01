using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarChoice.Areas.SEC_User.Models
{

    public class SEC_UserModel
    {
        public int UserID { get; set; }


        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display (Name ="Choose your image")]
        public IFormFile UserImage{ get; set; }

		public string UserImageURL { get; set; }

		public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

}
