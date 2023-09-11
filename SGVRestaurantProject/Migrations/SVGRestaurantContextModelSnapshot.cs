﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGVRestaurantProject.Models;

#nullable disable

namespace SGVRestaurantProject.Migrations
{
    [DbContext(typeof(SVGRestaurantContext))]
    partial class SVGRestaurantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.BanquetAndMenuItem", b =>
                {
                    b.Property<int>("BanquetAndMenuItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("banquetAndMenuItemsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BanquetAndMenuItemsId"), 1L, 1);

                    b.Property<int>("BanquetId")
                        .HasColumnType("int")
                        .HasColumnName("banquetID");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("itemID");

                    b.HasKey("BanquetAndMenuItemsId")
                        .HasName("pk_BanquetAndMenuItems");

                    b.HasIndex("BanquetId");

                    b.HasIndex("ItemId");

                    b.ToTable("BanquetAndMenuItems");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.BanquetMenu", b =>
                {
                    b.Property<int>("BanquetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("banquetID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BanquetId"), 1L, 1);

                    b.Property<bool>("BanquetAvailability")
                        .HasColumnType("bit")
                        .HasColumnName("banquetAvailability");

                    b.Property<int?>("BanquetCost")
                        .HasColumnType("int")
                        .HasColumnName("banquetCost");

                    b.Property<string>("BanquetName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("banquetName");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurantID");

                    b.HasKey("BanquetId")
                        .HasName("pk_banquetID");

                    b.HasIndex("RestaurantId");

                    b.ToTable("BanquetMenu", (string)null);
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("bookingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurantID");

                    b.Property<int>("SittingId")
                        .HasColumnType("int")
                        .HasColumnName("sittingID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.HasKey("BookingId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("SittingId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.MenuItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("itemID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"), 1L, 1);

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("itemName");

                    b.HasKey("ItemId")
                        .HasName("pk_itemID");

                    b.ToTable("MenuItem", (string)null);
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("restaurantID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"), 1L, 1);

                    b.Property<string>("RestaurantAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("restaurantAddress");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("restaurantName");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurant", (string)null);
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.RestaurantBanquetMenu", b =>
                {
                    b.Property<int>("RestaurantBanquetMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("restaurantBanquetMenuID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantBanquetMenuId"), 1L, 1);

                    b.Property<int>("BanquetId")
                        .HasColumnType("int")
                        .HasColumnName("banquetID");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurantID");

                    b.HasKey("RestaurantBanquetMenuId");

                    b.HasIndex("BanquetId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantBanquetMenu", (string)null);
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.RestaurantSitting", b =>
                {
                    b.Property<int>("RestaurantSittingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("restaurantSittingsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantSittingsId"), 1L, 1);

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurantID");

                    b.Property<int>("SittingId")
                        .HasColumnType("int")
                        .HasColumnName("sittingID");

                    b.HasKey("RestaurantSittingsId")
                        .HasName("pk_restaurantSittings");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("SittingId");

                    b.ToTable("RestaurantSittings");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.Sitting", b =>
                {
                    b.Property<int>("SittingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sittingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SittingId"), 1L, 1);

                    b.Property<int>("SittingEnd")
                        .HasColumnType("int")
                        .HasColumnName("sittingEnd");

                    b.Property<int>("SittingStart")
                        .HasColumnType("int")
                        .HasColumnName("sittingStart");

                    b.Property<string>("SittingType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sittingType");

                    b.HasKey("SittingId");

                    b.ToTable("Sitting", (string)null);
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.UserAccount", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("emailAddress");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("phoneNumber");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("userType");

                    b.HasKey("UserId")
                        .HasName("pk_userID");

                    b.ToTable("UserAccount", (string)null);
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.Users.DefaultUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UserCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SGVRestaurantProject.Models.Users.DefaultUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SGVRestaurantProject.Models.Users.DefaultUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGVRestaurantProject.Models.Users.DefaultUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SGVRestaurantProject.Models.Users.DefaultUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.BanquetAndMenuItem", b =>
                {
                    b.HasOne("SGVRestaurantProject.Models.BanquetMenu", "Banquet")
                        .WithMany("BanquetAndMenuItems")
                        .HasForeignKey("BanquetId")
                        .HasConstraintName("fk_BanquetAndMenuItems_banquetID");

                    b.HasOne("SGVRestaurantProject.Models.MenuItem", "Item")
                        .WithMany("BanquetAndMenuItems")
                        .HasForeignKey("ItemId")
                        .IsRequired()
                        .HasConstraintName("fk_BanquetAndMenuItems_itemID");

                    b.Navigation("Banquet");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.BanquetMenu", b =>
                {
                    b.HasOne("SGVRestaurantProject.Models.Restaurant", "Restaurant")
                        .WithMany("BanquetMenus")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.Booking", b =>
                {
                    b.HasOne("SGVRestaurantProject.Models.Restaurant", "Restaurant")
                        .WithMany("Bookings")
                        .HasForeignKey("RestaurantId")
                        .IsRequired()
                        .HasConstraintName("fk_booking_Restaurant");

                    b.HasOne("SGVRestaurantProject.Models.Sitting", "Sitting")
                        .WithMany("Bookings")
                        .HasForeignKey("SittingId")
                        .IsRequired()
                        .HasConstraintName("fk_booking_sittingID");

                    b.HasOne("SGVRestaurantProject.Models.UserAccount", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_booking_UserAccount");

                    b.Navigation("Restaurant");

                    b.Navigation("Sitting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.RestaurantBanquetMenu", b =>
                {
                    b.HasOne("SGVRestaurantProject.Models.BanquetMenu", "Banquet")
                        .WithMany("RestaurantBanquetMenus")
                        .HasForeignKey("BanquetId")
                        .IsRequired()
                        .HasConstraintName("fk_RestaurantBanquetMenu_banquetID");

                    b.HasOne("SGVRestaurantProject.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantBanquetMenus")
                        .HasForeignKey("RestaurantId")
                        .IsRequired()
                        .HasConstraintName("fk_RestaurantBanquetMenu_restaurantID");

                    b.Navigation("Banquet");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.RestaurantSitting", b =>
                {
                    b.HasOne("SGVRestaurantProject.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantSittings")
                        .HasForeignKey("RestaurantId")
                        .IsRequired()
                        .HasConstraintName("fk_restaurantsittings_restaurantID");

                    b.HasOne("SGVRestaurantProject.Models.Sitting", "Sitting")
                        .WithMany("RestaurantSittings")
                        .HasForeignKey("SittingId")
                        .IsRequired()
                        .HasConstraintName("fk_restaurantsittings_sittingID");

                    b.Navigation("Restaurant");

                    b.Navigation("Sitting");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.BanquetMenu", b =>
                {
                    b.Navigation("BanquetAndMenuItems");

                    b.Navigation("RestaurantBanquetMenus");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.MenuItem", b =>
                {
                    b.Navigation("BanquetAndMenuItems");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.Restaurant", b =>
                {
                    b.Navigation("BanquetMenus");

                    b.Navigation("Bookings");

                    b.Navigation("RestaurantBanquetMenus");

                    b.Navigation("RestaurantSittings");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.Sitting", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("RestaurantSittings");
                });

            modelBuilder.Entity("SGVRestaurantProject.Models.UserAccount", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
