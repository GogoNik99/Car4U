﻿// <auto-generated />
using System;
using Car4U.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Car4U.Infrastructure.Migrations
{
    [DbContext(typeof(Car4UDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("FuelType Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("FuelType Name");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");

                    b.HasComment("Vehicle FuelType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electric"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Petrol"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gasoline"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Diesel"
                        });
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Brand Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Model Name");

                    b.HasKey("Id");

                    b.ToTable("Models");

                    b.HasComment("Car Model");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Peugeot 308"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Opel Insignia"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Citroen C4"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kia K5"
                        });
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Owner Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Owner's Address");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasComment("Owner's phone number");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Owner's Rating");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Owners");

                    b.HasComment("Owner of the Car");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Sofia, j.k. Tolstoi, Building 52, Entrance D, ap. 98",
                            PhoneNumber = "+35952835632",
                            Rating = 8.2m,
                            UserId = "fd09b928-e634-4d61-a792-f2531b5c1c30"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Sofia, j.k. Drujba 2, Building 208, Entrance E, ap. 113",
                            PhoneNumber = "+35957155446",
                            Rating = 5.2m,
                            UserId = "441159ec-b2dd-4f8b-b8f8-5ff14e516459"
                        });
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Vehicle Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasComment("Vehicle Description");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("int")
                        .HasComment("FuelType Identifier");

                    b.Property<string>("ImageFileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the Image");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Is Vehicle Approved by Administrator");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Vehicle Manufacturer");

                    b.Property<int>("ModelId")
                        .HasColumnType("int")
                        .HasComment("Model Identifier");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasComment("Owner Identifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the Vehicle");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("User Identifier of the Person Renting");

                    b.HasKey("Id");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Vehicles");

                    b.HasComment("Vehicle for lending");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Description = "Двигател 1.2 PureTech (130 кс) Automatic. Начало на производство Октомври, 2022 г. - До днешна дата. Тип каросерия Кросоувър - Фастбек, Брой места 5, Брой врати 4",
                            FuelTypeId = 3,
                            ImageFileName = "CitroenC4.jpg",
                            IsActive = true,
                            Manufacturer = "France",
                            ModelId = 3,
                            OwnerId = 2,
                            Price = 220m,
                            RenterId = "9f86abd5-38fa-434a-a2b0-9379e0b79a1d"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Двигател 2.0 BlueHDi (150 кс) Automatic. Начало на производство Януари, 2017 г. - Край на производство Септември, 2018 г.Тип каросерия Комби, Брой места 5, Брой врати 5",
                            FuelTypeId = 2,
                            ImageFileName = "OpelInsignia.jpg",
                            IsActive = true,
                            Manufacturer = "Germany",
                            ModelId = 2,
                            OwnerId = 1,
                            Price = 150m
                        },
                        new
                        {
                            Id = 1,
                            Description = "Двигател 1.5 Turbo (140 кс) Automatic. Начало на производство Юли, 2018 г - Край на производство Февруари, 2020 г. Тип каросерия Хечбек, Брой места 5, Брой врати 5",
                            FuelTypeId = 4,
                            ImageFileName = "Peugeot.jpg",
                            IsActive = true,
                            Manufacturer = "France",
                            ModelId = 1,
                            OwnerId = 1,
                            Price = 200m,
                            RenterId = "897b211e-7ccc-4a50-804d-755fba6dc000"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Двигател 2.5 GDI (191 кс) AWD Automatic. Начало на производство Февруари, 2024 г. - До днешна дата. Тип каросерия Седан-Фастбек, Брой места 5, Брой врати 4",
                            FuelTypeId = 2,
                            ImageFileName = "KiaK5.jpg",
                            IsActive = false,
                            Manufacturer = "Japan",
                            ModelId = 4,
                            OwnerId = 2,
                            Price = 230m
                        });
                });

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.HasData(
                        new
                        {
                            Id = "fd09b928-e634-4d61-a792-f2531b5c1c30",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f20f464d-b956-4701-a04b-4117d4d1966c",
                            Email = "misho@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "misho@gmail.com",
                            NormalizedUserName = "misho@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEKDUriYcXj7WvLdjRgQku06aWzCUYP7CaxVwg3XWnYEPrV4SEK+sKTt4LtwUopSORw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a77e7dfb-5dae-4237-9f94-1a8698525b7c",
                            TwoFactorEnabled = false,
                            UserName = "misho@gmail.com"
                        },
                        new
                        {
                            Id = "441159ec-b2dd-4f8b-b8f8-5ff14e516459",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a735aad-e347-4604-867f-6388c2538800",
                            Email = "dimi@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "dimi@gmail.com",
                            NormalizedUserName = "dimi@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEKVnAj7gKnkso41/1MubfTjNUHdKwSfRFpaXnLH1151E/gJAo9yj68V197Rl2Ul0mA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "03de5abc-6acb-477c-a98e-f21639cbd770",
                            TwoFactorEnabled = false,
                            UserName = "dimi@gmail.com"
                        },
                        new
                        {
                            Id = "897b211e-7ccc-4a50-804d-755fba6dc000",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8a9ed4d8-2b92-4f9d-bc93-3b50ccc96682",
                            Email = "gosho@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "gosho@gmail.com",
                            NormalizedUserName = "gosho@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAovUefV6kGU9IyqNdFLm3wFZbhpHuOy5TUIMFLUc6rrHX7da2hmHcuztiNSS8GnLw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fda0b58e-0c3a-45b2-95c5-ccd6c082842f",
                            TwoFactorEnabled = false,
                            UserName = "gosho@gmail.com"
                        },
                        new
                        {
                            Id = "9f86abd5-38fa-434a-a2b0-9379e0b79a1d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "89b3681c-3866-48cc-a7df-3f9dac8042f4",
                            Email = "filip@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "filip@gmail.com",
                            NormalizedUserName = "filip@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAENvuFTw9dmujYspf8CUOrqXxtxMqiy6unfhk0mcWRGBsGnv2pU9HxqE3Jk2b7aFDRw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4f9ddb48-b605-4b4a-885b-01e1c31c887c",
                            TwoFactorEnabled = false,
                            UserName = "filip@gmail.com"
                        });
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

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.Owner", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.HasOne("Car4U.Infrastructure.Data.Models.FuelType", "FuelType")
                        .WithMany("Vehicles")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Car4U.Infrastructure.Data.Models.Model", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Car4U.Infrastructure.Data.Models.Owner", "Owner")
                        .WithMany("Vehicles")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FuelType");

                    b.Navigation("Model");

                    b.Navigation("Owner");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.FuelType", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.Model", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.Owner", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
