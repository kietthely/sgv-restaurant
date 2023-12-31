﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGVRestaurantProject.Models
{
    public partial class sgvRestaurantContext : DbContext
    {
        public sgvRestaurantContext()
        {
        }

        public sgvRestaurantContext(DbContextOptions<sgvRestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BanquetAndMenuItem> BanquetAndMenuItems { get; set; } = null!;
        public virtual DbSet<BanquetMenu> BanquetMenus { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<RestaurantBanquetMenu> RestaurantBanquetMenus { get; set; } = null!;
        public virtual DbSet<RestaurantSitting> RestaurantSittings { get; set; } = null!;
        public virtual DbSet<Sitting> Sittings { get; set; } = null!;
        public virtual DbSet<UserAccount> UserAccounts { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-UVIN9MQ\\SQLEXPRESS;Initial Catalog=sgvRestaurant;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanquetAndMenuItem>(entity =>
            {
                entity.HasKey(e => e.BanquetAndMenuItemsId)
                    .HasName("pk_BanquetAndMenuItems");

                entity.Property(e => e.BanquetAndMenuItemsId).HasColumnName("banquetAndMenuItemsID");

                entity.Property(e => e.BanquetId).HasColumnName("banquetID");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.HasOne(d => d.Banquet)
                    .WithMany(p => p.BanquetAndMenuItems)
                    .HasForeignKey(d => d.BanquetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BanquetAndMenuItems_banquetID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.BanquetAndMenuItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BanquetAndMenuItems_itemID");
            });

            modelBuilder.Entity<BanquetMenu>(entity =>
            {
                entity.HasKey(e => e.BanquetId)
                    .HasName("pk_banquetID");

                entity.ToTable("BanquetMenu");

                entity.Property(e => e.BanquetId).HasColumnName("banquetID");

                entity.Property(e => e.BanquetAvailability).HasColumnName("banquetAvailability");

                entity.Property(e => e.BanquetCost).HasColumnName("banquetCost");

                entity.Property(e => e.BanquetName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("banquetName");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurantID");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.BanquetMenus)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BanquetMenu_restaurantID");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("bookingID");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurantID");

                entity.Property(e => e.SittingId).HasColumnName("sittingID");

                entity.Property(e => e.DefaultUserId).HasColumnName("userID");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_booking_Restaurant");

                entity.HasOne(d => d.Sitting)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SittingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_booking_sittingID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DefaultUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_booking_UserAccount");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("pk_itemID");

                entity.ToTable("MenuItem");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("itemName");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurantID");

                entity.Property(e => e.RestaurantAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("restaurantAddress");

                entity.Property(e => e.RestaurantName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("restaurantName");
            });

            modelBuilder.Entity<RestaurantBanquetMenu>(entity =>
            {
                entity.ToTable("RestaurantBanquetMenu");

                entity.Property(e => e.RestaurantBanquetMenuId).HasColumnName("restaurantBanquetMenuID");

                entity.Property(e => e.BanquetId).HasColumnName("banquetID");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurantID");

                entity.HasOne(d => d.Banquet)
                    .WithMany(p => p.RestaurantBanquetMenus)
                    .HasForeignKey(d => d.BanquetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RestaurantBanquetMenu_banquetID");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantBanquetMenus)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RestaurantBanquetMenu_restaurantID");
            });

            modelBuilder.Entity<RestaurantSitting>(entity =>
            {
                entity.HasKey(e => e.RestaurantSittingsId)
                    .HasName("pk_restaurantSittings");

                entity.Property(e => e.RestaurantSittingsId).HasColumnName("restaurantSittingsID");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurantID");

                entity.Property(e => e.SittingId).HasColumnName("sittingID");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantSittings)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_restaurantsittings_restaurantID");

                entity.HasOne(d => d.Sitting)
                    .WithMany(p => p.RestaurantSittings)
                    .HasForeignKey(d => d.SittingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_restaurantsittings_sittingID");
            });

            modelBuilder.Entity<Sitting>(entity =>
            {
                entity.ToTable("Sitting");

                entity.Property(e => e.SittingId).HasColumnName("sittingID");

                entity.Property(e => e.SittingEnd).HasColumnName("sittingEnd");

                entity.Property(e => e.SittingStart).HasColumnName("sittingStart");

                entity.Property(e => e.SittingType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sittingType");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_userID");

                entity.ToTable("UserAccount");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("emailAddress");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
