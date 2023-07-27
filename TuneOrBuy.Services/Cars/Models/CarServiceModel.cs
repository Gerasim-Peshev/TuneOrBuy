using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TuneOrBuy.Data;

namespace TuneOrBuy.Services.Cars.Models
{
    public class CarServiceModel
    {
        public string Id { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string? VIN { get; set; }

        public string BodyType { get; set; } = null!;

        public string Fuel { get; set; } = null!;

        public int HorsePower { get; set; }

        public DateTime Year { get; set; }

        public DateTime FirstRegistrationYear { get; set; }

        public decimal Price { get; set; }

        public int TraveledDistance { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string SellerId { get; set; } = null!;

        public string GearType { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string NumberOfDoors { get; set; } = null!;

        public string NumberOfSeats { get; set; } = null!;

        public IEnumerable<string> Equipments { get; set; }

        public string? Description { get; set; }

        public bool ServiceHistory { get; set; }
    }
}
