using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuneOrBuy.Data
{
    public class DataConstants
    {
        public class Buyer
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public class Seller
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
            public const string PhoneNumberRegEx = @"^([+]?[\d]){7,15}$";

            public const int ImageUrlMaxLength = 2048;
        }

        public class CarServiceOwner
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
            public const string PhoneNumberRegEx = @"^([+]?[\d]){7,15}$";
        }

        public class Town
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 176;
        }

        public class Car
        {
            public const int VINLength = 17;

            public const int HoursePowerMinValue = 0;
            public const int HoursePowerMaxValue = 5000;

            public const int PriceMinValue = 0;
            public const int PriceMaxValue = int.MaxValue;

            public const int TraveledDistanceMinValue = 0;
            public const int TraveledDistanceMaxValue = int.MaxValue;

            public const int ImageUrlMaxLength = 2048;

            public const int ColorMinLength = 2;
            public const int ColorMaxLength = 20;

            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 2000;
        }

        public class Part
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int PriceMinValue = 0;
            public const int PriceMaxValue = int.MaxValue;

            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 2000;

            public const int ImageUrlMaxLength = 2048;
        }

        public class CarService
        {
            public const int AddressMinLength = 2;
            public const int AddressMaxLength = 200;

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
            public const string PhoneNumberRegEx = @"^([+]?[\\d]){7,15}$";

            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 2000;
        }
    }
}
