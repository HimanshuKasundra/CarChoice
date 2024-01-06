namespace CarChoice.Areas.Car.Models
{
    public class CarModel
    {

       public   int CarID { get; set; }
        
       public   string CarName { get; set; }
        public   string BrandName { get; set; }
        public    string  Model { get; set; }
        public   string Year { get; set; }
        public   string TransmissionType { get; set; }
       public   string FuelType { get; set; }
        public   string Availability { get; set; }
        public   string VehicleNo { get; set; }
        public   Double Rent { get; set; }
        public   string CarImageURL { get; set; }
        public   DateTime Created { get; set; }
        public   DateTime Modified { get; set; }
    }

    public class TransmissionDropdownModel
    {
        public int TransmissionID { get; set; }
        public string TransmissionType { get; set;}
    }

    public class BrandDropdownModel
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandLogo { get; set; }
    }

    public class FuelDropdownModel
    {
        public int FuelID { get; set; }
        public string FuelType { get; set;}
    }

    public class RentDropdownModel
    {
        public int BrandID { get; set; }
        public Double Rent { get; set; }

        public string CarType { get; set; }

    }
}
