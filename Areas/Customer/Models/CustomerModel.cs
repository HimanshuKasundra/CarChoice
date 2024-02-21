using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace CarChoice.Areas.Customer.Models
{
	public class CustomerModel
	{
		[Required]
		public int CustomerID { get; set; }
		//[Required]
		[Display (Name ="FirstName field is required")]
		public string FirstName { get; set; }

		//[Required]
		[Display(Name = "LastName field is required")]

		[Required]
		public string LastName { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }	

		//[Required]
		[Display(Name = "Email field is required")]

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		//[Required]
		[Display(Name = "Mobile number field is required")]

		[StringLength(10)]
		[MinLength(10)]
		[MaxLength(10)]
		public string Mobile { get; set; }

		[Required]
		[Display(Name = "Address field is required")]

		public string Address { get; set; }

		[Required]
		[Display(Name = "Licence number field is required")]
		[StringLength(15)]
		[MinLength(15)]
		[MaxLength(15)]
		public string LicenceNumber { get; set; }


		[Required]
		public string LicenceImageURL { get; set; }

		[Required]
		[Display(Name = "LicenceImage field is required")]

		public IFormFile LicenceImage { get; set; }


		[Required]
		public string CustomerImageURL { get; set; }

		[Required]
		[Display(Name = "CustomerImageURL field is required")]

		public IFormFile CustomerImage { get; set; }

		public DateTime Created { get; set; }	

		public DateTime Modified { get; set; }	
	}
}  
