﻿// <auto-generated />
using System;
using Car4U.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Car4U.Infrastructure.Migrations
{
    [DbContext(typeof(Car4UDbContext))]
    [Migration("20240425162658_RenterAddedToVehicle")]
    partial class RenterAddedToVehicle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.ApplicationUser", b =>
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
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

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
                            ConcurrencyStamp = "4949fc8c-6d89-4fbd-bf9e-727fee6dfadc",
                            Email = "misho@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Mihail",
                            LastName = "Nikolov",
                            LockoutEnabled = false,
                            NormalizedEmail = "misho@gmail.com",
                            NormalizedUserName = "misho@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ2tifSBg77fCbyYze84hwF1BopgcQMYahNiw+TzfHUW7auDVi3P8QYIKmzv8jf2cA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c426e0bb-21b6-40cb-b5b1-850bded47028",
                            TwoFactorEnabled = false,
                            UserName = "misho@gmail.com"
                        },
                        new
                        {
                            Id = "441159ec-b2dd-4f8b-b8f8-5ff14e516459",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "be892e34-053a-4439-85d6-731c9c56294b",
                            Email = "dimi@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Dimi",
                            LastName = "Kolev",
                            LockoutEnabled = false,
                            NormalizedEmail = "dimi@gmail.com",
                            NormalizedUserName = "dimi@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAENL2F01y2kIuqQtS39+4aksL0XGb4vuT+gcEKgWN/5GFX1Fsl4EsPnUzNjYnWxxCfA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4cb92147-09aa-42a4-a54d-9c7cae4b62c6",
                            TwoFactorEnabled = false,
                            UserName = "dimi@gmail.com"
                        },
                        new
                        {
                            Id = "897b211e-7ccc-4a50-804d-755fba6dc000",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "74b78dc8-a601-40b2-b273-3be3d292201f",
                            Email = "gosho@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Georgi",
                            LastName = "Ivanonv",
                            LockoutEnabled = false,
                            NormalizedEmail = "gosho@gmail.com",
                            NormalizedUserName = "gosho@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEPeoZa5ONImO83DcF9JYPmYYu+0cv60wm/m8SGA80D2/5u75odeHRLAynXWUmXt/ng==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "67dbae13-b9ed-4a9a-a29b-b99dcb749297",
                            TwoFactorEnabled = false,
                            UserName = "gosho@gmail.com"
                        },
                        new
                        {
                            Id = "9f86abd5-38fa-434a-a2b0-9379e0b79a1d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "83556a78-6abb-4163-8a92-bc4e14cdb62a",
                            Email = "filip@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Filip",
                            LastName = "Trifonov",
                            LockoutEnabled = false,
                            NormalizedEmail = "filip@gmail.com",
                            NormalizedUserName = "filip@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAELLhBXb3v+m1qM9iTS/kkpTCJdecmk+QPjWgx30P7lSiZmJAWu9jXy8v9/aN2lyO5w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c67692bf-8d69-478c-8e5b-41567d7452c6",
                            TwoFactorEnabled = false,
                            UserName = "filip@gmail.com"
                        },
                        new
                        {
                            Id = "438a3adc-511b-43d6-aa1a-fa29bda460a0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b8ac5a02-a944-4365-8b89-d860925c4e46",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Adminov",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@mail.com",
                            NormalizedUserName = "admin@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEN/nPf4pnSwiIpYU5VhSbafmZIaRRYJWBXWxyIh+QrzGXz2DC0HrtWA7vK1G48YQQg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e4668ed3-ae7e-4fe5-b1a3-86c20caf31f8",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        });
                });

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

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Owners");

                    b.HasComment("Owner of the Car");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Sofia, j.k. Tolstoi, Building 52, Entrance D, ap. 98",
                            PhoneNumber = "+35952835632",
                            Rating = 0m,
                            UserId = "fd09b928-e634-4d61-a792-f2531b5c1c30"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Sofia, j.k. Drujba 2, Building 208, Entrance E, ap. 113",
                            PhoneNumber = "+35957155446",
                            Rating = 0m,
                            UserId = "441159ec-b2dd-4f8b-b8f8-5ff14e516459"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Sofia, Ul. Neofit Rilski 25, Entrance A, ap. 5",
                            PhoneNumber = "+35926676810",
                            Rating = 0m,
                            UserId = "438a3adc-511b-43d6-aa1a-fa29bda460a0"
                        });
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Rating Description");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasComment("Owner Identifier");

                    b.Property<decimal>("RatingValue")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Rating value");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "I was completely impressed with their professionalism and customer service.",
                            OwnerId = 1,
                            RatingValue = 7.2m
                        },
                        new
                        {
                            Id = 2,
                            OwnerId = 1,
                            RatingValue = 5.5m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Pricing is fair and transparent - definitely value for money.",
                            OwnerId = 2,
                            RatingValue = 6.3m
                        },
                        new
                        {
                            Id = 4,
                            OwnerId = 2,
                            RatingValue = 8.2m
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
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier of the Person Renting");

                    b.HasKey("Id");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RenterId");

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
                            IsActive = true,
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
                    b.HasOne("Car4U.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithOne("Owner")
                        .HasForeignKey("Car4U.Infrastructure.Data.Models.Owner", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.Rating", b =>
                {
                    b.HasOne("Car4U.Infrastructure.Data.Models.Owner", "Owner")
                        .WithMany("Ratings")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");
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

                    b.HasOne("Car4U.Infrastructure.Data.Models.ApplicationUser", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId");

                    b.Navigation("FuelType");

                    b.Navigation("Model");

                    b.Navigation("Owner");

                    b.Navigation("Renter");
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
                    b.HasOne("Car4U.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Car4U.Infrastructure.Data.Models.ApplicationUser", null)
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

                    b.HasOne("Car4U.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Car4U.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Car4U.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Owner");
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
                    b.Navigation("Ratings");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}