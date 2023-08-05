using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TuneOrBuy.Services.Cars.Enums;
using TuneOrBuy.Services.Cars.Models;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Models.Car;
using System.Linq;
using TuneOrBuy.Data;
using TuneOrBuy.Web.Models;

namespace TuneOrBuy.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public CarController(ICarService service)
        {
            this.carService = service;
        }

        public async Task<IActionResult> All()
        {
            var enumerableOfCars = new List<CarServiceModel>();

            enumerableOfCars = await carService.AllCarsAsync();

            if (enumerableOfCars == null)
            {
                enumerableOfCars = new List<CarServiceModel>();
            }
            return View(enumerableOfCars);
        }

        [HttpGet]
        public async Task<IActionResult> AddCar()
        {
            var viewToReturn = new AddCarViewModel();

            return View(CreateAddCarViewModel(viewToReturn));
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarViewModel carToAdd)
        {
            if (!ModelState.IsValid && carToAdd.FirstRegistrationYear < carToAdd.Year)
            {
                return View(CreateAddCarViewModel(carToAdd));
            }

            await carService.CreateCarAsync(carToAdd.Manufacturer, carToAdd.Brand, carToAdd.BodyType, carToAdd.VIN,
                                            carToAdd.Fuel, carToAdd.HorsePower,
                                            carToAdd.Year, carToAdd.FirstRegistrationYear, carToAdd.Price,
                                            carToAdd.TraveledDistance, UserId(), carToAdd.ImageUrl, carToAdd.GearType, carToAdd.Color,
                                            carToAdd.NumberOfDoors, carToAdd.NumberOfSeats, carToAdd.Equipments,
                                            carToAdd.Description, carToAdd.ServiceHistory);

            

            return RedirectToAction("All", "Car");
        }

        public async Task<IActionResult> CarDetails(string carId)
        {
            var carToReturn = await carService.CarDetailsByIdAsync(carId);

            return View(carToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> EditCar(string carId)
        {
            var car = await carService.GetCarAsync(carId);

            var modelToReturn = new EditCarViewModel()
            {
                Id = car.Id,
                Manufacturer = car.Manufacturer,
                Brand = car.Brand,
                VIN = car.VIN,
                BodyType = car.BodyType,
                Fuel = car.Fuel,
                HorsePower = car.HorsePower,
                Year = car.Year.Year,
                FirstRegistrationYear = car.FirstRegistrationYear.Year,
                Price = car.Price,
                TraveledDistance = car.TraveledDistance,
                SellerId = car.SellerId,
                ImageUrl = car.ImageUrl,
                GearType = car.GearType,
                Color = car.Color,
                NumberOfDoors = car.NumberOfDoors,
                NumberOfSeats = car.NumberOfSeats,
                Equipments = car.Equipments.Split(", ").ToList(),
                Description = car.Description,
                ServiceHistory = car.ServiceHistory,
            };


            return View(CreateEditCarViewModel(modelToReturn));
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(EditCarViewModel editedCar)
        {
            if (!ModelState.IsValid && editedCar.Year <= editedCar.FirstRegistrationYear)
            {
                return View(CreateEditCarViewModel(editedCar));
            }

            await carService.EditCarAsync(editedCar.Id, editedCar.Manufacturer, editedCar.Brand, editedCar.BodyType,
                                          editedCar.VIN, editedCar.Fuel, editedCar.HorsePower, editedCar.Year,
                                          editedCar.FirstRegistrationYear, editedCar.Price, editedCar.TraveledDistance,
                                          editedCar.SellerId, editedCar.ImageUrl,
                                          editedCar.GearType, editedCar.Color, editedCar.NumberOfDoors,
                                          editedCar.NumberOfSeats, String.Join(", ", editedCar.Equipments), editedCar.Description, editedCar.ServiceHistory);

            return RedirectToAction("All", "Car");
        }

        public async Task<IActionResult> DeleteCar(string carId)
        {
            await carService.DeleteCarAsync(carId);

            return RedirectToAction("All", "Car");
        }

        public async Task<IActionResult> CarToFavourite(string carId)
        {
            var userId = UserId();

            await carService.ToFavouriteCarsAsync(carId, userId);

            return RedirectToAction("All", "Car");
        }

        public async Task<IActionResult> MyCars()
        {
            var favoriteCars = await carService.MyFavoriteCarsAsync(UserId());
            return View(favoriteCars);
        }

        private AddCarViewModel CreateAddCarViewModel(AddCarViewModel viewToReturn)
        {
            var manufacturers = new List<EquipmentAndService>();
            var bodyTypes = new List<EquipmentAndService>();
            var fuelTypes = new List<EquipmentAndService>();
            var gearTypes = new List<EquipmentAndService>();
            var numberOfDoors = new List<EquipmentAndService>();
            var numberOfSeats = new List<EquipmentAndService>();
            var equipmentToChooseFrom = new List<CheckBoxOption>();

            int id = 1;

            foreach (var manufacturer in CarConstants.Manufacturers)
            {
                manufacturers.Add(new EquipmentAndService() { Id = id, Name = manufacturer });
                id++;
            }

            id = 1;

            foreach (var bodyType in CarConstants.BodyTypes)
            {
                bodyTypes.Add(new EquipmentAndService() { Id = id, Name = bodyType });
                id++;
            }

            id = 1;

            foreach (var fuelType in CarConstants.FuelType)
            {
                fuelTypes.Add(new EquipmentAndService() { Id = id, Name = fuelType });
                id++;
            }

            id = 1;

            foreach (var gearType in CarConstants.GearTypes)
            {
                gearTypes.Add(new EquipmentAndService() { Id = id, Name = gearType });
                id++;
            }

            id = 1;

            foreach (var numberOfDoor in CarConstants.NumberOfDoors)
            {
                numberOfDoors.Add(new EquipmentAndService() { Id = id, Name = numberOfDoor });
                id++;
            }

            id = 1;

            foreach (var numberOfSeat in CarConstants.NumberOfSeats)
            {
                numberOfSeats.Add(new EquipmentAndService() { Id = id, Name = numberOfSeat });
                id++;
            }

            id = 1;

            foreach (var equipment in CarConstants.EquipmentsToChooseFrom)
            {
                equipmentToChooseFrom.Add(new CheckBoxOption() { IsChecked = false, Description = equipment, Value = $"OPTION{id}"});
                id++;
            }

            viewToReturn = new AddCarViewModel()
            {
                Manufactures = manufacturers,
                BodyTypes = bodyTypes,
                Fuels = fuelTypes,
                GearTypes = gearTypes,
                NumbersOfDoors = numberOfDoors,
                NumbersOfSeats = numberOfSeats,
                EquipmentsToChooseFrom = equipmentToChooseFrom
            };

            return viewToReturn;
        }

        private EditCarViewModel CreateEditCarViewModel(EditCarViewModel viewToReturn)
        {
            var manufacturers = new List<EquipmentAndService>();
            var bodyTypes = new List<EquipmentAndService>();
            var fuelTypes = new List<EquipmentAndService>();
            var gearTypes = new List<EquipmentAndService>();
            var numberOfDoors = new List<EquipmentAndService>();
            var numberOfSeats = new List<EquipmentAndService>();
            var equipmentToChooseFrom = new List<CheckBoxOption>();

            int id = 1;

            foreach (var manufacturer in CarConstants.Manufacturers)
            {
                manufacturers.Add(new EquipmentAndService() { Id = id, Name = manufacturer });
                id++;
            }

            id = 1;

            foreach (var bodyType in CarConstants.BodyTypes)
            {
                bodyTypes.Add(new EquipmentAndService() { Id = id, Name = bodyType });
                id++;
            }

            id = 1;

            foreach (var fuelType in CarConstants.FuelType)
            {
                fuelTypes.Add(new EquipmentAndService() { Id = id, Name = fuelType });
                id++;
            }

            id = 1;

            foreach (var gearType in CarConstants.GearTypes)
            {
                gearTypes.Add(new EquipmentAndService() { Id = id, Name = gearType });
                id++;
            }

            id = 1;

            foreach (var numberOfDoor in CarConstants.NumberOfDoors)
            {
                numberOfDoors.Add(new EquipmentAndService() { Id = id, Name = numberOfDoor });
                id++;
            }

            id = 1;

            foreach (var numberOfSeat in CarConstants.NumberOfSeats)
            {
                numberOfSeats.Add(new EquipmentAndService() { Id = id, Name = numberOfSeat });
                id++;
            }

            id = 1;

            foreach (var equipment in CarConstants.EquipmentsToChooseFrom)
            {
                equipmentToChooseFrom.Add(new CheckBoxOption() { IsChecked = false, Description = equipment, Value = $"OPTION{id}" });
                id++;
            }


            viewToReturn.Manufactures = manufacturers;
            viewToReturn.BodyTypes = bodyTypes;
            viewToReturn.Fuels = fuelTypes;
            viewToReturn.GearTypes = gearTypes;
            viewToReturn.NumbersOfDoors = numberOfDoors;
            viewToReturn.NumbersOfSeats = numberOfSeats;
            viewToReturn.EquipmentsToChooseFrom = equipmentToChooseFrom;
                    
            return viewToReturn;
        }
    }
}
