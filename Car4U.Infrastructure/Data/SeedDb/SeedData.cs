using Car4U.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Car4U.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {


        public Owner Owner1 { get; set; }

        public Owner Owner2 { get; set; }
        public Model Peugeot { get; set; }
        public Model Opel { get; set; }
        public Model Citroen { get; set; }
        public Model KIA { get; set; }
        public FuelType Electric { get; set; }
        public FuelType Petrol { get; set; }
        public FuelType Gasoline { get; set; }
        public FuelType Diesel { get; set; }
        public IdentityUser User1 { get; set; }
        public IdentityUser User2 { get; set; }
        public IdentityUser User3 { get; set; }

        public IdentityUser User4 { get; set; }
        public Vehicle FirstVehicle { get; set; }
        public Vehicle SecondVehicle { get; set; }
        public Vehicle ThirdVehicle { get; set; }
        public Vehicle FourthVehicle { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedOwners();
            SeedModels();
            SeedFuelTypes();
            SeedVehicles();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            User1 = new IdentityUser()
            {
                Id = "fd09b928-e634-4d61-a792-f2531b5c1c30",
                UserName = "misho@gmail.com",
                NormalizedUserName = "misho@gmail.com",
                Email = "misho@gmail.com",
                NormalizedEmail = "misho@gmail.com"
            };

            User1.PasswordHash = hasher.HashPassword(User1, "misho123");

            User2 = new IdentityUser()
            {
                Id = "441159ec-b2dd-4f8b-b8f8-5ff14e516459",
                UserName = "dimi@gmail.com",
                NormalizedUserName = "dimi@gmail.com",
                Email = "dimi@gmail.com",
                NormalizedEmail = "dimi@gmail.com"
            };

            User2.PasswordHash = hasher.HashPassword(User2, "dimi123");

            User3 = new IdentityUser()
            {
                Id = "897b211e-7ccc-4a50-804d-755fba6dc000",
                UserName = "gosho@gmail.com",
                NormalizedUserName = "gosho@gmail.com",
                Email = "gosho@gmail.com",
                NormalizedEmail = "gosho@gmail.com"
            };

            User3.PasswordHash = hasher.HashPassword(User3, "gosho123");

            User4 = new IdentityUser()
            {
                Id = "9f86abd5-38fa-434a-a2b0-9379e0b79a1d",
                UserName = "filip@gmail.com",
                NormalizedUserName = "filip@gmail.com",
                Email = "filip@gmail.com",
                NormalizedEmail = "filip@gmail.com"
            };

            User4.PasswordHash = hasher.HashPassword(User4, "filip123");

        }

        private void SeedOwners()
        {
            Owner1 = new Owner()
            {
                Id = 1,
                Address = "Sofia, j.k. Tolstoi, Building 52, Entrance D, ap. 98",
                PhoneNumber = "+35952835632",
                Rating = 8.2m,
                UserId = User1.Id
            };

            Owner2 = new Owner()
            {
                Id = 2,
                Address = "Sofia, j.k. Drujba 2, Building 208, Entrance E, ap. 113",
                PhoneNumber = "+35957155446",
                Rating = 5.2m,
                UserId = User2.Id
            };
        }

        private void SeedFuelTypes()
        {
            Electric = new FuelType()
            {
                Id = 1,
                Name = "Electric"
            };
            Petrol = new FuelType()
            {
                Id = 2,
                Name = "Petrol"
            };
            Gasoline = new FuelType()
            {
                Id = 3,
                Name = "Gasoline"
            };
            Diesel = new FuelType()
            {
                Id = 4,
                Name = "Diesel"
            };
        }

        private void SeedModels()
        {
            Peugeot = new Model()
            {
                Id = 1,
                Name = "Peugeot 308"
            };
            Opel = new Model()
            {
                Id = 2,
                Name = "Opel Insignia"
            };
            Citroen = new Model()
            {
                Id = 3,
                Name = "Citroen C4"
            };
            KIA = new Model()
            {
                Id = 4,
                Name = "Kia K5"
            };
        }

        private void SeedVehicles()
        {
            FirstVehicle = new Vehicle()
            {
                Id = 1,
                Description = "Двигател 1.5 Turbo (140 кс) Automatic. Начало на производство Юли, 2018 г - Край на производство Февруари, 2020 г. Тип каросерия Хечбек, Брой места 5, Брой врати 5",
                IsActive = true,
                FuelTypeId = Diesel.Id,
                ImageFileName = "Peugeot.jpg",
                Manufacturer = "France",
                ModelId = Peugeot.Id,
                OwnerId = Owner1.Id,
                Price = 200,
                RenterId = User3.Id
            };
            SecondVehicle = new Vehicle()
            {
                Id = 2,
                Description = "Двигател 2.0 BlueHDi (150 кс) Automatic. Начало на производство Януари, 2017 г. - Край на производство Септември, 2018 г.Тип каросерия Комби, Брой места 5, Брой врати 5",
                IsActive = true,
                FuelTypeId = Petrol.Id,
                ImageFileName = "OpelInsignia.jpg",
                Manufacturer = "Germany",
                ModelId = Opel.Id,
                OwnerId = Owner1.Id,
                Price = 150
            };
            ThirdVehicle = new Vehicle()
            {
                Id = 3,
                Description = "Двигател 1.2 PureTech (130 кс) Automatic. Начало на производство Октомври, 2022 г. - До днешна дата. Тип каросерия Кросоувър - Фастбек, Брой места 5, Брой врати 4",
                IsActive = true,
                FuelTypeId = Gasoline.Id,
                ImageFileName = "CitroenC4.jpg",
                Manufacturer = "France",
                ModelId = Citroen.Id,
                OwnerId = Owner2.Id,
                Price = 220,
                RenterId = User4.Id
            };
            FourthVehicle = new Vehicle()
            {
                Id = 4,
                Description = "Двигател 2.5 GDI (191 кс) AWD Automatic. Начало на производство Февруари, 2024 г. - До днешна дата. Тип каросерия Седан-Фастбек, Брой места 5, Брой врати 4",
                IsActive = true,
                FuelTypeId = Petrol.Id,
                ImageFileName = "KiaK5.jpg",
                Manufacturer = "Japan",
                ModelId = KIA.Id,
                OwnerId = Owner2.Id,
                Price = 230
            };
        }




    }
}
