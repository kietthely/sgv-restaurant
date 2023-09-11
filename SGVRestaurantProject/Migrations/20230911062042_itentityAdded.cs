using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVRestaurantProject.Migrations
{
    public partial class itentityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    itemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_itemID", x => x.itemID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    restaurantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurantAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    restaurantName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.restaurantID);
                });

            migrationBuilder.CreateTable(
                name: "Sitting",
                columns: table => new
                {
                    sittingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sittingType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    sittingStart = table.Column<int>(type: "int", nullable: false),
                    sittingEnd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitting", x => x.sittingID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    emailAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userID", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BanquetMenu",
                columns: table => new
                {
                    banquetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    banquetName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    restaurantID = table.Column<int>(type: "int", nullable: false),
                    banquetCost = table.Column<int>(type: "int", nullable: true),
                    banquetAvailability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_banquetID", x => x.banquetID);
                    table.ForeignKey(
                        name: "FK_BanquetMenu_Restaurant_restaurantID",
                        column: x => x.restaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "restaurantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantSittings",
                columns: table => new
                {
                    restaurantSittingsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurantID = table.Column<int>(type: "int", nullable: false),
                    sittingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_restaurantSittings", x => x.restaurantSittingsID);
                    table.ForeignKey(
                        name: "fk_restaurantsittings_restaurantID",
                        column: x => x.restaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "restaurantID");
                    table.ForeignKey(
                        name: "fk_restaurantsittings_sittingID",
                        column: x => x.sittingID,
                        principalTable: "Sitting",
                        principalColumn: "sittingID");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    bookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sittingID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    restaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.bookingID);
                    table.ForeignKey(
                        name: "fk_booking_Restaurant",
                        column: x => x.restaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "restaurantID");
                    table.ForeignKey(
                        name: "fk_booking_sittingID",
                        column: x => x.sittingID,
                        principalTable: "Sitting",
                        principalColumn: "sittingID");
                    table.ForeignKey(
                        name: "fk_booking_UserAccount",
                        column: x => x.userID,
                        principalTable: "UserAccount",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "BanquetAndMenuItems",
                columns: table => new
                {
                    banquetAndMenuItemsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemID = table.Column<int>(type: "int", nullable: false),
                    banquetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_BanquetAndMenuItems", x => x.banquetAndMenuItemsID);
                    table.ForeignKey(
                        name: "fk_BanquetAndMenuItems_banquetID",
                        column: x => x.banquetID,
                        principalTable: "BanquetMenu",
                        principalColumn: "banquetID");
                    table.ForeignKey(
                        name: "fk_BanquetAndMenuItems_itemID",
                        column: x => x.itemID,
                        principalTable: "MenuItem",
                        principalColumn: "itemID");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantBanquetMenu",
                columns: table => new
                {
                    restaurantBanquetMenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurantID = table.Column<int>(type: "int", nullable: false),
                    banquetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantBanquetMenu", x => x.restaurantBanquetMenuID);
                    table.ForeignKey(
                        name: "fk_RestaurantBanquetMenu_banquetID",
                        column: x => x.banquetID,
                        principalTable: "BanquetMenu",
                        principalColumn: "banquetID");
                    table.ForeignKey(
                        name: "fk_RestaurantBanquetMenu_restaurantID",
                        column: x => x.restaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "restaurantID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BanquetAndMenuItems_banquetID",
                table: "BanquetAndMenuItems",
                column: "banquetID");

            migrationBuilder.CreateIndex(
                name: "IX_BanquetAndMenuItems_itemID",
                table: "BanquetAndMenuItems",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_BanquetMenu_restaurantID",
                table: "BanquetMenu",
                column: "restaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_restaurantID",
                table: "Booking",
                column: "restaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_sittingID",
                table: "Booking",
                column: "sittingID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_userID",
                table: "Booking",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBanquetMenu_banquetID",
                table: "RestaurantBanquetMenu",
                column: "banquetID");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBanquetMenu_restaurantID",
                table: "RestaurantBanquetMenu",
                column: "restaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantSittings_restaurantID",
                table: "RestaurantSittings",
                column: "restaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantSittings_sittingID",
                table: "RestaurantSittings",
                column: "sittingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BanquetAndMenuItems");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "RestaurantBanquetMenu");

            migrationBuilder.DropTable(
                name: "RestaurantSittings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "BanquetMenu");

            migrationBuilder.DropTable(
                name: "Sitting");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
