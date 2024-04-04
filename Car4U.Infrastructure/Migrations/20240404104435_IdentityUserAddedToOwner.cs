using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4U.Infrastructure.Migrations
{
    public partial class IdentityUserAddedToOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Owners",
                type: "nvarchar(450)",
                nullable: false,
                comment: "User Identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User Identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserId",
                table: "Owners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AspNetUsers_UserId",
                table: "Owners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AspNetUsers_UserId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_UserId",
                table: "Owners");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                comment: "User Identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "User Identifier");
        }
    }
}
