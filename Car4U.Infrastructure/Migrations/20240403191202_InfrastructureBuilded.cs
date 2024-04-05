using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4U.Infrastructure.Migrations
{
    public partial class InfrastructureBuilded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "FuelType Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "FuelType Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                },
                comment: "Vehicle FuelType");

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Brand Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Model Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                },
                comment: "Car Model");

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Owner Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false, comment: "Owner's phone number"),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Owner's Address"),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Owner's Rating"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                },
                comment: "Owner of the Car");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Vehicle Manufacturer"),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Vehicle Description"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the Vehicle"),
                    ImageFileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the Image"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is Vehicle Approved by Administrator"),
                    OwnerId = table.Column<int>(type: "int", nullable: false, comment: "Owner Identifier"),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "User Identifier of the Person Renting"),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false, comment: "FuelType Identifier"),
                    ModelId = table.Column<int>(type: "int", nullable: false, comment: "Model Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Vehicle for lending");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PhoneNumber",
                table: "Owners",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FuelTypeId",
                table: "Vehicles",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OwnerId",
                table: "Vehicles",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
