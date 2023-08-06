using System.ComponentModel.DataAnnotations;
using TuneOrBuy.Data;
using static TuneOrBuy.Data.DataConstants.Car;

namespace TuneOrBuy.Web.Models.Car
{
    public class AddCarViewModel
    {
        [Required]
        public string Manufacturer { get; set; } = null!;

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        [Display(Name = "Body type")]
        public string BodyType { get; set; } = null!;

        [StringLength(VINLength, MinimumLength = VINLength, ErrorMessage = "Incorrect VIN")]
        public string? VIN { get; set; }

        [Required]
        public string Fuel { get; set; } = null!;

        [Required]
        [Range(HoursePowerMinValue, HoursePowerMaxValue, ErrorMessage = "Incorrect horse power")]
        [Display(Name = "Horse Power")]
        public int HorsePower { get; set; }

        [Required]
        [Display(Name = "Year of car")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Year of first registration")]
        public int FirstRegistrationYear { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = "Incorrect price")]
        [Display(Name = "Price in BGN")]
        public decimal Price { get; set; }

        [Required]
        [Range(TraveledDistanceMinValue, TraveledDistanceMaxValue, ErrorMessage = "Incorrect Traveled Distance")]
        [Display(Name = "Traveled Distance in km")]
        public int TraveledDistance { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength, ErrorMessage = "Incorrect Car Image")]
        [Display(Name = "Car Image")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Gear")]
        public string GearType { get; set; } = null!;

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength, ErrorMessage = "Incorrect Color")]
        public string Color { get; set; } = null!;

        [Required]
        [Display(Name = "Number of doors")]
        public string NumberOfDoors { get; set; } = null!;

        [Required]
        [Display(Name = "Number of seats")]
        public string NumberOfSeats { get; set; } = null!;

        public virtual List<string> Equipments { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Incorrect Description")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Service History")]
        public bool ServiceHistory { get; set; } = false;

        public IEnumerable<EquipmentAndService>? Manufactures { get; set; }
        public IEnumerable<EquipmentAndService>? BodyTypes { get; set; }
        public IEnumerable<EquipmentAndService>? Fuels { get; set; }
        public IEnumerable<EquipmentAndService>? GearTypes { get; set; }
        public IEnumerable<EquipmentAndService>? NumbersOfDoors { get; set; }
        public IEnumerable<EquipmentAndService>? NumbersOfSeats { get; set; }
        public IEnumerable<CheckBoxOption>? EquipmentsToChooseFrom { get; set; }
    }
}
