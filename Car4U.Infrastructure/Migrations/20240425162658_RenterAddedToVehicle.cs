using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4U.Infrastructure.Migrations
{
    public partial class RenterAddedToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true,
                comment: "User Identifier of the Person Renting",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User Identifier of the Person Renting");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438a3adc-511b-43d6-aa1a-fa29bda460a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8ac5a02-a944-4365-8b89-d860925c4e46", "AQAAAAEAACcQAAAAEN/nPf4pnSwiIpYU5VhSbafmZIaRRYJWBXWxyIh+QrzGXz2DC0HrtWA7vK1G48YQQg==", "e4668ed3-ae7e-4fe5-b1a3-86c20caf31f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "441159ec-b2dd-4f8b-b8f8-5ff14e516459",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be892e34-053a-4439-85d6-731c9c56294b", "AQAAAAEAACcQAAAAENL2F01y2kIuqQtS39+4aksL0XGb4vuT+gcEKgWN/5GFX1Fsl4EsPnUzNjYnWxxCfA==", "4cb92147-09aa-42a4-a54d-9c7cae4b62c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "897b211e-7ccc-4a50-804d-755fba6dc000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74b78dc8-a601-40b2-b273-3be3d292201f", "AQAAAAEAACcQAAAAEPeoZa5ONImO83DcF9JYPmYYu+0cv60wm/m8SGA80D2/5u75odeHRLAynXWUmXt/ng==", "67dbae13-b9ed-4a9a-a29b-b99dcb749297" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86abd5-38fa-434a-a2b0-9379e0b79a1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83556a78-6abb-4163-8a92-bc4e14cdb62a", "AQAAAAEAACcQAAAAELLhBXb3v+m1qM9iTS/kkpTCJdecmk+QPjWgx30P7lSiZmJAWu9jXy8v9/aN2lyO5w==", "c67692bf-8d69-478c-8e5b-41567d7452c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd09b928-e634-4d61-a792-f2531b5c1c30",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4949fc8c-6d89-4fbd-bf9e-727fee6dfadc", "AQAAAAEAACcQAAAAEJ2tifSBg77fCbyYze84hwF1BopgcQMYahNiw+TzfHUW7auDVi3P8QYIKmzv8jf2cA==", "c426e0bb-21b6-40cb-b5b1-850bded47028" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RenterId",
                table: "Vehicles",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_RenterId",
                table: "Vehicles",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_RenterId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_RenterId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User Identifier of the Person Renting",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "User Identifier of the Person Renting");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438a3adc-511b-43d6-aa1a-fa29bda460a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7a2082d-1711-43b9-b826-7044022e7afb", "AQAAAAEAACcQAAAAEKFrpIQYoXfjrsddz8MHgHqO1FxK4YhXoiDuIQ+aKQnAhtv4Ox9MPYP9pq2cw/jATA==", "6336218b-a258-4bd4-89c9-8d5fb83884ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "441159ec-b2dd-4f8b-b8f8-5ff14e516459",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "449ffc54-7fb6-4039-af22-e47f7114c17e", "AQAAAAEAACcQAAAAEKWguyP7saGasZPy3/McpvLtmsZbNIkMkcU348T2LxqbT7e0xM5vtgrLwrTVGI03pg==", "225de162-9392-42ec-8b04-e3c1f87e8537" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "897b211e-7ccc-4a50-804d-755fba6dc000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b093482-c01d-4137-b03e-aa4319a04f7e", "AQAAAAEAACcQAAAAEGs2ifL/rhyURJargEUeUDoKlQlRUGUEBe9u+/nCarzSs4m8nyx51azOVmtL4fPVtA==", "599f7f08-945c-41b8-bbf3-d93db53f58d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f86abd5-38fa-434a-a2b0-9379e0b79a1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82010a84-b749-471d-a637-ebcc59bcbb43", "AQAAAAEAACcQAAAAEEpVc5MvYwwc4gktuMRQzSuhVEGsdxFeop88NCrqi7ixTyezlifPP7EFftOFgwKnPQ==", "74f77b15-cbdf-43a1-8828-7686cde21b38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd09b928-e634-4d61-a792-f2531b5c1c30",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e665d2f2-33a5-43f6-b00b-104d283e1b6e", "AQAAAAEAACcQAAAAECCwffjnYqrkCLm1FcoOl4RNRUVVK8G/8T+nKf1Ydkwg/8jrsfjkm+qbG0Zcwd2IXQ==", "736ce822-0c88-491f-8aa1-a439486a9c10" });
        }
    }
}
