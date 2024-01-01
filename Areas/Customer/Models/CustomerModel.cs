using System.ComponentModel.DataAnnotations;

namespace CarChoice.Areas.Customer.Models
{
	public class CustomerModel
	{
		public int CustomerID { get; set; }
		[Required]
		[Display (Name ="FirstName field is required")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "LastName field is required")]

		public string LastName { get; set; }

		[Required]
		[Display(Name = "Email field is required")]

		public string Email { get; set; }

		[Required]
		[Display(Name = "Mobile number field is required")]

		public string Mobile { get; set; }

		[Required]
		[Display(Name = "Address field is required")]

		public string Address { get; set; }

		[Required]
		[Display(Name = "Licence number field is required")]

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

		public DateTime created { get; set; }	

		public DateTime Modified { get; set; }	
	}
}  
