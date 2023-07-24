using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TuneOrBuy.Data.Models;

namespace TuneOrBuy.Services.Cars.Models
{
    public class CarServiceModel
    { 
        public Guid Id { get; set; }

        public string Manufacturer { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string BodyType { get; set; } = null!;

        public string? VIN { get; set; }

        public string Fuel { get; set; } = null!;

        public int HorsePower { get; set; }

        public DateTime Year { get; set; }

        public DateTime FirstRegistrationYear { get; set; }

        public decimal Price { get; set; }

        public int TraveledDistance { get; set; }

        public Guid SellerId { get; set; }
        public Seller Seller { get; set; } = null!;

        public string GearType { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string NumberOfDoors { get; set; } = null!;

        public string NumberOfSeats { get; set; } = null!;

        public virtual IEnumerable<EquipmentAndService> Equipments { get; set; }

        public string? Description { get; set; }

        public bool ServiceHistory { get; set; }
    }
}
