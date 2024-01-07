using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarChoice.Areas.Rent.Models
{
    public class RentModel
    {

        public int RentID { get; set; }

        [Required]
        [DisplayName("Rent")]
        public double Rent { get; set; }

        [Required]
        public string CarType { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
    public class RentDropDownModel
    {
        public int RentID { get; set; }
        public Double Rent { get; set; }

        public string CarType { get; set; }

    }

}
