using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4U.Infrastructure.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelTypeId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Owners_OwnerId",
                table: "Vehicles");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "441159ec-b2dd-4f8b-b8f8-5ff14e516459", 0, "7a735aad-e347-4604-867f-6388c2538800", "dimi@gmail.com", false, false, null, "dimi@gmail.com", "dimi@gmail.com", "AQAAAAEAACcQAAAAEKVnAj7gKnkso41/1MubfTjNUHdKwSfRFpaXnLH1151E/gJAo9yj68V197Rl2Ul0mA==", null, false, "03de5abc-6acb-477c-a98e-f21639cbd770", false, "dimi@gmail.com" },
                    { "897b211e-7ccc-4a50-804d-755fba6dc000", 0, "8a9ed4d8-2b92-4f9d-bc93-3b50ccc96682", "gosho@gmail.com", false, false, null, "gosho@gmail.com", "gosho@gmail.com", "AQAAAAEAACcQAAAAEAovUefV6kGU9IyqNdFLm3wFZbhpHuOy5TUIMFLUc6rrHX7da2hmHcuztiNSS8GnLw==", null, false, "fda0b58e-0c3a-45b2-95c5-ccd6c082842f", false, "gosho@gmail.com" },
                    { "9f86abd5-38fa-434a-a2b0-9379e0b79a1d", 0, "89b3681c-3866-48cc-a7df-3f9dac8042f4", "filip@gmail.com", false, false, null, "filip@gmail.com", "filip@gmail.com", "AQAAAAEAACcQAAAAENvuFTw9dmujYspf8CUOrqXxtxMqiy6unfhk0mcWRGBsGnv2pU9HxqE3Jk2b7aFDRw==", null, false, "4f9ddb48-b605-4b4a-885b-01e1c31c887c", false, "filip@gmail.com" },
                    { "fd09b928-e634-4d61-a792-f2531b5c1c30", 0, "f20f464d-b956-4701-a04b-4117d4d1966c", "misho@gmail.com", false, false, null, "misho@gmail.com", "misho@gmail.com", "AQAAAAEAACcQAAAAEKDUriYcXj7WvLdjRgQku06aWzCUYP7CaxVwg3XWnYEPrV4SEK+sKTt4LtwUopSORw==", null, false, "a77e7dfb-5dae-4237-9f94-1a8698525b7c", false, "misho@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electric" },
                    { 2, "Petrol" },
                    { 3, "Gasoline" },
                    { 4, "Diesel" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Peugeot 308" },
                    { 2, "Opel Insignia" },
                    { 3, "Citroen C4" },
                    { 4, "Kia K5" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "PhoneNumber", "Rating", "UserId" },
                values: new object[] { 1, "Sofia, j.k. Tolstoi, Building 52, Entrance D, ap. 98", "+35952835632", 8.2m, "fd09b928-e634-4d61-a792-f2531b5c1c30" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "PhoneNumber", "Rating", "UserId" },
                values: new object[] { 2, "Sofia, j.k. Drujba 2, Building 208, Entrance E, ap. 113", "+35957155446", 5.2m, "441159ec-b2dd-4f8b-b8f8-5ff14e516459" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "FuelTypeId", "ImageFileName", "IsActive", "Manufacturer", "ModelId", "OwnerId", "Price", "RenterId" },
                values: new object[,]
                {
                    { 1, "Двигател 1.5 Turbo (140 кс) Automatic. Начало на производство Юли, 2018 г - Край на производство Февруари, 2020 г. Тип каросерия Хечбек, Брой места 5, Брой врати 5", 4, "Peugeot.jpg", true, "France", 1, 1, 200m, "897b211e-7ccc-4a50-804d-755fba6dc000" },
                    { 2, "Двигател 2.0 BlueHDi (150 кс) Automatic. Начало на производство Януари, 2017 г. - Край на производство Септември, 2018 г.Тип каросерия Комби, Брой места 5, Брой врати 5", 2, "OpelInsignia.jpg", true, "Germany", 2, 1, 150m, null },
                    { 3, "Двигател 1.2 PureTech (130 кс) Automatic. Начало на производство Октомври, 2022 г. - До днешна дата. Тип каросерия Кросоувър - Фастбек, Брой места 5, Брой врати 4", 3, "CitroenC4.jpg", true, "France", 3, 2, 220m, "9f86abd5-38fa-434a-a2b0-9379e0b79a1d" },
                    { 4, "Двигател 2.5 GDI (191 кс) AWD Automatic. Начало на производство Февруари, 2024 г. - До днешна дата. Тип каросерия Седан-Фастбек, Брой места 5, Брой врати 4", 2, "KiaK5.jpg", false, "Japan", 4, 2, 230m, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelTypeId",
                table: "Vehicles",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Owners_OwnerId",
                table: "Vehicles",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelTypeId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Owners_OwnerId",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "897b211e-7ccc-4a50-804d-755fba6dc000");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86abd5-38fa-434a-a2b0-9379e0b79a1d");

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "441159ec-b2dd-4f8b-b8f8-5ff14e516459");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd09b928-e634-4d61-a792-f2531b5c1c30");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelTypeId",
                table: "Vehicles",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Owners_OwnerId",
                table: "Vehicles",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
