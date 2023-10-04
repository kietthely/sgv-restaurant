using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVRestaurantProject.Migrations
{
    public partial class sprint4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Restaurant",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "restaurantEmail",
                table: "Restaurant",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "restaurantPhoneNumber",
                table: "Restaurant",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "banquetID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "bookingDate",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "completed",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "numberOfGuest",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_banquetID",
                table: "Booking",
                column: "banquetID");

            migrationBuilder.AddForeignKey(
                name: "fk_booking_banquet",
                table: "Booking",
                column: "banquetID",
                principalTable: "BanquetMenu",
                principalColumn: "banquetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_booking_banquet",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_banquetID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "restaurantEmail",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "restaurantPhoneNumber",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "banquetID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "bookingDate",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "completed",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "numberOfGuest",
                table: "Booking");
        }
    }
}
