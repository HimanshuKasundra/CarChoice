using System.ComponentModel.DataAnnotations;

namespace CarChoice.Areas.Car.Models
{
    public class CarModel
    {

        [Required]
       public   int CarID { get; set; }
        
        [Required]
       public   string CarName { get; set; }
        [Required]
        public   string BrandName { get; set; }
        [Required]
        public int BrandID{ get; set; }

        [Required]
        public string  Model { get; set; }
        [Required]
        public   int Year { get; set; }
        
        public   string TransmissionType { get; set; }
        [Required]
        public int TransmissionID { get; set; }

        
        public string FuelType { get; set; }
        [Required]
        public int FuelID { get; set; }

        [Required]
        public string Availability { get; set; }
        [Required]
        public   string VehicleNo { get; set; }
       
        public   double Rent { get; set; }
        [Required]
        public int RentID { get; set; }
        [Required]
         public string CarType { get; set; }
       
        public string CarImageURL { get; set; }
        [Required]
        public IFormFile CarImage { get; set; }

        
        public DateTime Created { get; set; }
       
        public   DateTime Modified { get; set; }

       
    }    
}
