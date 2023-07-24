using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Cars.Models;

namespace TuneOrBuy.Web.Models.Car
{
    public class AllCarsQueryModel
    {
        public AllCarsQueryModel()
        {
            this.Cars = new List<CarServiceModel>();
        }


        public string? Manufacturer = null;

        public string? BodyType = null;

        public string? Fuel = null;

        public int? HorsePower = null;

        public DateTime? Year = null;

        public decimal? Price = null;

        public string? GearType = null;

        public string? Color = null;

        public string? NumberOfDoors = null;

        public string? NumberOfSeats = null;

        public bool? ServiceHistory = null;



        public IEnumerable<EquipmentAndService> Manufactures { get; set; }
        public IEnumerable<EquipmentAndService> BodyTypes { get; set; }
        public IEnumerable<EquipmentAndService> Fuels { get; set; }
        public IEnumerable<EquipmentAndService> GearTypes { get; set; }
        public IEnumerable<EquipmentAndService> Colors { get; set; }
        public IEnumerable<EquipmentAndService> NumbersOfDoors { get; set; }
        public IEnumerable<EquipmentAndService> NumbersOfSeats { get; set; }
        public IEnumerable<CarServiceModel> Cars { get; set; }
    }
}
