using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarChoice.Areas.Fuel.Models
{
    public class FuelModel
    {
        public int FuelID { get; set; }

        [Required]
        [DisplayName("Fuel Type ")]
        public string? FuelType { get; set; }

       
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class FuelDropDownModel
    {
        public int FuelID { get; set; }
        public string FuelType { get; set; }
    }
}


