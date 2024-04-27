using Car4U.Data.Infrastructure;
using Car4U.Infrastructure.Data.Common;
using Car4U.Infrastructure.Data.Models;
using Car4U.Tests.Mocks;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace Car4U.Tests.Tests
{
    public class UnitTestsBase
    {
        public Owner Owner { get; set; }
        public Owner AdminOwner { get; set; }
        public Model Peugeot { get; set; }

        public Model Opel { get; set; }
        public FuelType Electric { get; set; }

        public FuelType Petrol { get; set; }
        public ApplicationUser OwnerUser { get; set; }

        public ApplicationUser RenterUser { get; set; }
        public Vehicle RentedVehicle { get; set; }

        public Vehicle VehicleToEdit { get; set; }



        public Vehicle NotRentedVehicle { get; set; }
        public Vehicle VehicleToDelete { get; set; }
        public Rating Rating { get; set; }

        protected Car4UDbContext _context;
        protected IRepository _repository;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            _context = DatabaseMock.Instance;
            _repository = RepositoryMock.Instance(_context);
            seedData();
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            _context.Dispose();
        }

        private void seedData()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            OwnerUser = new ApplicationUser()
            {
                Id = "fd09b928-e634-4d61-a792-f2531b5c1c30",
                UserName = "misho@gmail.com",
                NormalizedUserName = "misho@gmail.com",
                Email = "misho@gmail.com",
                NormalizedEmail = "misho@gmail.com",
                FirstName = "Mihail",
                LastName = "Nikolov"
            };
            OwnerUser.PasswordHash = hasher.HashPassword(OwnerUser, "misho123");
            _context.Users.Add(OwnerUser);

            RenterUser = new ApplicationUser()
            {
                Id = "0251e959-ffa1-4167-900f-9cc0efec14dd",
                UserName = "filip@mail.com",
                NormalizedUserName = "filip@mail.com",
                Email = "filip@mail.com",
                NormalizedEmail = "filip@mail.com",
                FirstName = "Filip",
                LastName = "Trifonov"
            };

            RenterUser.PasswordHash = hasher.HashPassword(RenterUser, "filip123");
            _context.Users.Add(RenterUser);

            Owner = new Owner()
            {
                Id = 1,
                Address = "Sofia, j.k. Tolstoi, Building 52, Entrance D, ap. 98",
                PhoneNumber = "+35952835632",
                Rating = 0,
                UserId = OwnerUser.Id
            };
            _context.Owners.Add(Owner);

            Electric = new FuelType()
            {
                Id = 1,
                Name = "Electric"
            };
            _context.FuelTypes.Add(Electric);
            Petrol = new FuelType()
            {
                Id = 2,
                Name = "Petrol"
            };
            _context.FuelTypes.Add(Petrol);

            Peugeot = new Model()
            {
                Id = 1,
                Name = "Peugeot 308"
            };
            _context.Models.Add(Peugeot);
            Opel = new Model()
            {
                Id = 2,
                Name = "Opel"
            };
            _context.Models.Add(Opel);

            RentedVehicle = new Vehicle()
            {
                Id = 1,
                Description = "Двигател 1.5 Turbo (140 кс) Automatic. Начало на производство Юли, 2018 г - Край на производство Февруари, 2020 г. Тип каросерия Хечбек, Брой места 5, Брой врати 5",
                IsActive = true,
                FuelTypeId = Electric.Id,
                ImageFileName = "Peugeot.jpg",
                Manufacturer = "France",
                ModelId = Peugeot.Id,
                OwnerId = Owner.Id,
                Price = 200,
                RenterId = RenterUser.Id
            };
            _context.Vehicles.Add(RentedVehicle);

            NotRentedVehicle = new Vehicle()
            {
                Id = 2,
                Description = "Двигател 2.0 BlueHDi (150 кс) Automatic. Начало на производство Януари, 2017 г. - Край на производство Септември, 2018 г.Тип каросерия Комби, Брой места 5, Брой врати 5",
                IsActive = true,
                FuelTypeId = Petrol.Id,
                ImageFileName = "OpelInsignia.jpg",
                Manufacturer = "Germany",
                ModelId = Opel.Id,
                OwnerId = Owner.Id,
                Price = 150
            };
            _context.Vehicles.Add(NotRentedVehicle);

            VehicleToDelete = new Vehicle()
            {
                Id = 3,
                Description = "Двигател 1.5 Turbo (140 кс) Automatic. Начало на производство Юли, 2018 г - Край на производство Февруари, 2020 г. Тип каросерия Хечбек, Брой места 5, Брой врати 5",
                IsActive = false,
                FuelTypeId = Electric.Id,
                ImageFileName = "image.jpg",
                Manufacturer = "France",
                ModelId = Peugeot.Id,
                OwnerId = Owner.Id,
                Price = 200,
            };
            _context.Vehicles.Add(VehicleToDelete);

            VehicleToEdit = new Vehicle()
            {
                Id = 4,
                Description = "Двигател 1.5 Turbo (140 кс) Automatic. Начало на производство Юли, 2018 г - Край на производство Февруари, 2020 г. Тип каросерия Хечбек, Брой места 5, Брой врати 5",
                IsActive = false,
                FuelTypeId = Electric.Id,
                ImageFileName = "image.jpg",
                Manufacturer = "France",
                ModelId = Peugeot.Id,
                OwnerId = Owner.Id,
                Price = 200,
            };
            _context.Vehicles.Add(VehicleToEdit);

            Rating = new Rating()
            {
                Id = 1,
                RatingValue = 7.2m,
                OwnerId = Owner.Id,
                Description = "I was completely impressed with their professionalism and customer service."
            };
            _context.Ratings.Add(Rating);
            _context.SaveChanges();
        }
    }
}


