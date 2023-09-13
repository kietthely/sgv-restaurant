using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVRestaurantProject.Migrations
{
    public partial class associationbookinganduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_booking_DefaultUser",
                table: "Booking");

            //migrationBuilder.DropIndex(
            //    name: "IX_Booking_DefaultUserId",
            //    table: "Booking");

            migrationBuilder.DropColumn(
                name: "DefaultUserId",
                table: "Booking");

            migrationBuilder.AddColumn<string>(
                name: "DefaultUserId",
                table: "Booking",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DefaultUserId",
                table: "Booking",
                column: "DefaultUserId");

            migrationBuilder.AddForeignKey(
                name: "fk_booking_DefaultUser",
                table: "Booking",
                column: "DefaultUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_booking_DefaultUser",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_DefaultUserId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DefaultUserId",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "DefaultUserId",
                table: "Booking",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DefaultUserId",
                table: "Booking",
                column: "DefaultUserId");

            migrationBuilder.AddForeignKey(
                name: "fk_booking_DefaultUser",
                table: "Booking",
                column: "DefaultUserId",
                principalTable: "AspNetUser",
                principalColumn: "Id");
        }
    }
}
