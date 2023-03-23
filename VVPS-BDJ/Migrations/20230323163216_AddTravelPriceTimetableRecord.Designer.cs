﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VVPS_BDJ.DAL;

#nullable disable

namespace VVPS_BDJ.Migrations
{
    [DbContext(typeof(BDJContext))]
    [Migration("20230323163216_AddTravelPriceTimetableRecord")]
    partial class AddTravelPriceTimetableRecord
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("VVPS_BDJ.Models.DiscountCard", b =>
                {
                    b.Property<int?>("DiscountCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("DiscountValue")
                        .HasColumnType("REAL");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DiscountCardId");

                    b.ToTable("DiscountCards");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DiscountCard");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("VVPS_BDJ.Models.Reservation", b =>
                {
                    b.Property<int?>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Canceled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReservedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("VVPS_BDJ.Models.Ticket", b =>
                {
                    b.Property<int?>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ChildUnder16Present")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FromCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsTwoWay")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Price")
                        .HasColumnType("REAL");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UsedDiscountCardDiscountCardId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TicketId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("UsedDiscountCardDiscountCardId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("VVPS_BDJ.Models.TimetableRecord", b =>
                {
                    b.Property<int?>("TimetableRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArrivalLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("ArrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartureLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("DepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("TravelPrice")
                        .HasColumnType("REAL");

                    b.HasKey("TimetableRecordId");

                    b.ToTable("TimetableRecords");

                    b.HasData(
                        new
                        {
                            TimetableRecordId = 1,
                            ArrivalLocation = "Plovdiv",
                            ArrivalTime = new TimeOnly(10, 0, 0),
                            DepartureLocation = "Sofia",
                            DepartureTime = new TimeOnly(8, 0, 0),
                            TravelPrice = 10.0
                        },
                        new
                        {
                            TimetableRecordId = 2,
                            ArrivalLocation = "Varna",
                            ArrivalTime = new TimeOnly(12, 0, 0),
                            DepartureLocation = "Sofia",
                            DepartureTime = new TimeOnly(10, 0, 0),
                            TravelPrice = 15.35
                        },
                        new
                        {
                            TimetableRecordId = 3,
                            ArrivalLocation = "Burgas",
                            ArrivalTime = new TimeOnly(14, 0, 0),
                            DepartureLocation = "Sofia",
                            DepartureTime = new TimeOnly(12, 0, 0),
                            TravelPrice = 11.800000000000001
                        },
                        new
                        {
                            TimetableRecordId = 4,
                            ArrivalLocation = "Plovdiv",
                            ArrivalTime = new TimeOnly(16, 0, 0),
                            DepartureLocation = "Sofia",
                            DepartureTime = new TimeOnly(14, 0, 0),
                            TravelPrice = 9.9000000000000004
                        },
                        new
                        {
                            TimetableRecordId = 5,
                            ArrivalLocation = "Sofia",
                            ArrivalTime = new TimeOnly(18, 0, 0),
                            DepartureLocation = "Varna",
                            DepartureTime = new TimeOnly(16, 0, 0),
                            TravelPrice = 15.35
                        },
                        new
                        {
                            TimetableRecordId = 6,
                            ArrivalLocation = "Burgas",
                            ArrivalTime = new TimeOnly(20, 0, 0),
                            DepartureLocation = "Varna",
                            DepartureTime = new TimeOnly(18, 0, 0),
                            TravelPrice = 14.5
                        });
                });

            modelBuilder.Entity("VVPS_BDJ.Models.User", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DiscountCardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("DiscountCardId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Admin",
                            IsAdmin = true,
                            LastName = "Admin",
                            Password = "admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("VVPS_BDJ.Models.ElderlyDiscountCard", b =>
                {
                    b.HasBaseType("VVPS_BDJ.Models.DiscountCard");

                    b.HasDiscriminator().HasValue("ElderlyDiscountCard");
                });

            modelBuilder.Entity("VVPS_BDJ.Models.FamilyDiscountCard", b =>
                {
                    b.HasBaseType("VVPS_BDJ.Models.DiscountCard");

                    b.HasDiscriminator().HasValue("FamilyDiscountCard");
                });

            modelBuilder.Entity("VVPS_BDJ.Models.Ticket", b =>
                {
                    b.HasOne("VVPS_BDJ.Models.Reservation", null)
                        .WithMany("ReservedTickets")
                        .HasForeignKey("ReservationId");

                    b.HasOne("VVPS_BDJ.Models.DiscountCard", "UsedDiscountCard")
                        .WithMany()
                        .HasForeignKey("UsedDiscountCardDiscountCardId");

                    b.Navigation("UsedDiscountCard");
                });

            modelBuilder.Entity("VVPS_BDJ.Models.User", b =>
                {
                    b.HasOne("VVPS_BDJ.Models.DiscountCard", "DiscountCard")
                        .WithOne()
                        .HasForeignKey("VVPS_BDJ.Models.User", "DiscountCardId");

                    b.Navigation("DiscountCard");
                });

            modelBuilder.Entity("VVPS_BDJ.Models.Reservation", b =>
                {
                    b.Navigation("ReservedTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
