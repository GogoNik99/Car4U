using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4U.Infrastructure.Migrations
{
    public partial class RatingsAddedAndSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Owners_UserId",
                table: "Owners");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "Rating Description"),
                    RatingValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Rating value"),
                    OwnerId = table.Column<int>(type: "int", nullable: false, comment: "Owner Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "441159ec-b2dd-4f8b-b8f8-5ff14e516459",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "449ffc54-7fb6-4039-af22-e47f7114c17e", "Dimi", "Kolev", "AQAAAAEAACcQAAAAEKWguyP7saGasZPy3/McpvLtmsZbNIkMkcU348T2LxqbT7e0xM5vtgrLwrTVGI03pg==", "225de162-9392-42ec-8b04-e3c1f87e8537" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "897b211e-7ccc-4a50-804d-755fba6dc000",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b093482-c01d-4137-b03e-aa4319a04f7e", "Georgi", "Ivanonv", "AQAAAAEAACcQAAAAEGs2ifL/rhyURJargEUeUDoKlQlRUGUEBe9u+/nCarzSs4m8nyx51azOVmtL4fPVtA==", "599f7f08-945c-41b8-bbf3-d93db53f58d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86abd5-38fa-434a-a2b0-9379e0b79a1d",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82010a84-b749-471d-a637-ebcc59bcbb43", "Filip", "Trifonov", "AQAAAAEAACcQAAAAEEpVc5MvYwwc4gktuMRQzSuhVEGsdxFeop88NCrqi7ixTyezlifPP7EFftOFgwKnPQ==", "74f77b15-cbdf-43a1-8828-7686cde21b38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd09b928-e634-4d61-a792-f2531b5c1c30",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e665d2f2-33a5-43f6-b00b-104d283e1b6e", "Mihail", "Nikolov", "AQAAAAEAACcQAAAAECCwffjnYqrkCLm1FcoOl4RNRUVVK8G/8T+nKf1Ydkwg/8jrsfjkm+qbG0Zcwd2IXQ==", "736ce822-0c88-491f-8aa1-a439486a9c10" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "438a3adc-511b-43d6-aa1a-fa29bda460a0", 0, "c7a2082d-1711-43b9-b826-7044022e7afb", "admin@mail.com", false, "Admin", "Adminov", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEKFrpIQYoXfjrsddz8MHgHqO1FxK4YhXoiDuIQ+aKQnAhtv4Ox9MPYP9pq2cw/jATA==", null, false, "6336218b-a258-4bd4-89c9-8d5fb83884ab", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 0m);

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Description", "OwnerId", "RatingValue" },
                values: new object[,]
                {
                    { 1, "I was completely impressed with their professionalism and customer service.", 1, 7.2m },
                    { 2, null, 1, 5.5m },
                    { 3, "Pricing is fair and transparent - definitely value for money.", 2, 6.3m },
                    { 4, null, 2, 8.2m }
                });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "PhoneNumber", "Rating", "UserId" },
                values: new object[] { 3, "Sofia, Ul. Neofit Rilski 25, Entrance A, ap. 5", "+35926676810", 0m, "438a3adc-511b-43d6-aa1a-fa29bda460a0" });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserId",
                table: "Owners",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OwnerId",
                table: "Ratings",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Owners_UserId",
                table: "Owners");

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438a3adc-511b-43d6-aa1a-fa29bda460a0");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "441159ec-b2dd-4f8b-b8f8-5ff14e516459",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a735aad-e347-4604-867f-6388c2538800", "AQAAAAEAACcQAAAAEKVnAj7gKnkso41/1MubfTjNUHdKwSfRFpaXnLH1151E/gJAo9yj68V197Rl2Ul0mA==", "03de5abc-6acb-477c-a98e-f21639cbd770" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "897b211e-7ccc-4a50-804d-755fba6dc000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a9ed4d8-2b92-4f9d-bc93-3b50ccc96682", "AQAAAAEAACcQAAAAEAovUefV6kGU9IyqNdFLm3wFZbhpHuOy5TUIMFLUc6rrHX7da2hmHcuztiNSS8GnLw==", "fda0b58e-0c3a-45b2-95c5-ccd6c082842f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86abd5-38fa-434a-a2b0-9379e0b79a1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89b3681c-3866-48cc-a7df-3f9dac8042f4", "AQAAAAEAACcQAAAAENvuFTw9dmujYspf8CUOrqXxtxMqiy6unfhk0mcWRGBsGnv2pU9HxqE3Jk2b7aFDRw==", "4f9ddb48-b605-4b4a-885b-01e1c31c887c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd09b928-e634-4d61-a792-f2531b5c1c30",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f20f464d-b956-4701-a04b-4117d4d1966c", "AQAAAAEAACcQAAAAEKDUriYcXj7WvLdjRgQku06aWzCUYP7CaxVwg3XWnYEPrV4SEK+sKTt4LtwUopSORw==", "a77e7dfb-5dae-4237-9f94-1a8698525b7c" });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 8.2m);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 5.2m);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserId",
                table: "Owners",
                column: "UserId");
        }
    }
}
