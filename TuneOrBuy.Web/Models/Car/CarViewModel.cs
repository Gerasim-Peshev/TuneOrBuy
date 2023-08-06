using TuneOrBuy.Data;

namespace TuneOrBuy.Web.Models.Car
{
    public class CarViewModel
    {
        public string Id { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string? VIN { get; set; }

        public string BodyType { get; set; } = null!;

        public string Fuel { get; set; } = null!;

        public int HorsePower { get; set; }

        public string Year { get; set; }

        public string FirstRegistrationYear { get; set; }

        public decimal Price { get; set; }

        public int TraveledDistance { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string SellerId { get; set; } = null!;

        public string GearType { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string NumberOfDoors { get; set; }= null!;

        public string NumberOfSeats { get; set; }= null!;

        public string Equipments { get; set; }

        public string? Description { get; set; }

        public bool ServiceHistory { get; set; }

        public IEnumerable<EquipmentAndService>? Manufactures { get; set; }
        public IEnumerable<EquipmentAndService>? BodyTypes { get; set; }
        public IEnumerable<EquipmentAndService>? Fuels { get; set; }
        public IEnumerable<EquipmentAndService>? GearTypes { get; set; }
        public IEnumerable<EquipmentAndService>? NumbersOfDoors { get; set; }
        public IEnumerable<EquipmentAndService>? NumbersOfSeats { get; set; }
        public IEnumerable<CheckBoxOption>? EquipmentsToChooseFrom { get; set; }
    }
}
