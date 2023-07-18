using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TuneOrBuy.Data.DataConstants.Car;

namespace TuneOrBuy.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Equipments = new List<EquipmentAndService>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Manufacturer { get; set; } = null!;

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string BodyType { get; set; } = null!;

        [StringLength(VINLength, MinimumLength = VINLength)]
        public string? VIN { get; set; }

        [Required]
        public string Fuel { get; set; } = null!;

        [Required]
        [Range(HoursePowerMinValue, HoursePowerMaxValue)]
        public int HorsePower { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public DateTime FirstRegistrationYear { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(TraveledDistanceMinValue, TraveledDistanceMaxValue)]
        public int TraveledDistance { get; set; }

        [Required]
        [ForeignKey(nameof(Seller))]
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; } = null!;

        [Required]
        [Display(Name = "Gear")]
        public string GearType { get; set; } = null!;

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; } = null!;

        [Required]
        public string NumberOfDoors { get; set; } = null!;

        [Required]
        public string NumberOfSeats { get; set; } = null!;

        public virtual IEnumerable<EquipmentAndService> Equipments { get; set; }

        public string? Description { get; set; }

        [Required]
        public bool ServiceHistory { get; set; }
    }
}
