﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TuneOrBuy.Data.Migrations;
using static TuneOrBuy.Data.DataConstants.Part;

namespace TuneOrBuy.Data.Models
{
    public class Part
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Incorrect name")]
        public string Name { get; set; } = null!;

        [Required]
        public string Manufacturer { get; set; } = null!;

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public DateTime Year { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = "Incorrect price")]
        public decimal Price { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Incorrect description")]
        public string? Description { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength, MinimumLength = 0, ErrorMessage = "Incorrect image")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Seller))]
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; } = null!;
    }
}
