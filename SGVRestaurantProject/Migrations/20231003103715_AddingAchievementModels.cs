using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVRestaurantProject.Migrations
{
    public partial class AddingAchievementModels : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "AchievementsAchievementId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    AchievementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchievementName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.AchievementId);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    UserAchievementsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AchievementId = table.Column<int>(type: "int", nullable: false),
                    AchievementsAchievementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievements", x => x.UserAchievementsId);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Achievements_AchievementsAchievementId",
                        column: x => x.AchievementsAchievementId,
                        principalTable: "Achievements",
                        principalColumn: "AchievementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAchievements_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_banquetID",
                table: "Booking",
                column: "banquetID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AchievementsAchievementId",
                table: "AspNetUsers",
                column: "AchievementsAchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_AchievementsAchievementId",
                table: "UserAchievements",
                column: "AchievementsAchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_UserId",
                table: "UserAchievements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Achievements_AchievementsAchievementId",
                table: "AspNetUsers",
                column: "AchievementsAchievementId",
                principalTable: "Achievements",
                principalColumn: "AchievementId");

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
                name: "FK_AspNetUsers_Achievements_AchievementsAchievementId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "fk_booking_banquet",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Booking_banquetID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AchievementsAchievementId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "AchievementsAchievementId",
                table: "AspNetUsers");
        }
    }
}
