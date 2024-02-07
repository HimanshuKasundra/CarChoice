namespace CarChoice.Areas.Car_User.Models
{
    public class Car_UserModel
    {

        public int CarID { get; set; }

        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int BrandID { get; set; }

        public string Model { get; set; }
        public int Year { get; set; }
        public string TransmissionType { get; set; }
        public int TransmissionID { get; set; }

        public string FuelType { get; set; }
        public int FuelID { get; set; }

        public string Availability { get; set; }
        public string VehicleNo { get; set; }
        public double Rent { get; set; }
        public int RentID { get; set; }
        public string CarType { get; set; }
        public string CarImageURL { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
