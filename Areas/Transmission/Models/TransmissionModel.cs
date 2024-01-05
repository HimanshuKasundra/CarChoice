using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarChoice.Areas.Transmission.Models
{
    public class TransmissionModel
    {
        public int TransmissionID { get; set; }

        [Required]
        [DisplayName("Transmission Type ")]
        public string? TransmissionType { get; set; }

       
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }


}


