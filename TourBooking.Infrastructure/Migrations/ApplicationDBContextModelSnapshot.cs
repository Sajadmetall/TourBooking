﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourBooking.Infrastructure.DBContext;

#nullable disable

namespace TourBooking.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TourBooking.Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<short?>("Currency")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TourBooking.Domain.Entities.BookingPartyLeader", b =>
                {
                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PartyLeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingId", "PartyLeaderId");

                    b.HasIndex("PartyLeaderId");

                    b.ToTable("BookingPartyLeaders");
                });

            modelBuilder.Entity("TourBooking.Domain.Entities.PartyLeader", b =>
                {
                    b.Property<Guid>("PartyLeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartyLeaderId");

                    b.ToTable("PartyLeader");

                    b.HasData(
                        new
                        {
                            PartyLeaderId = new Guid("d2fc8dea-e40c-4b09-805c-b19c99991f24"),
                            Name = "AliBaba"
                        },
                        new
                        {
                            PartyLeaderId = new Guid("5b8a57ee-b147-4f8c-b7e6-f8725119deb4"),
                            Name = "EliGasht"
                        });
                });

            modelBuilder.Entity("TourBooking.Domain.Entities.BookingPartyLeader", b =>
                {
                    b.HasOne("TourBooking.Domain.Entities.Booking", "Booking")
                        .WithMany("BookingPartyLeaders")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourBooking.Domain.Entities.PartyLeader", "PartyLeader")
                        .WithMany("BookingPartyLeaders")
                        .HasForeignKey("PartyLeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("PartyLeader");
                });

            modelBuilder.Entity("TourBooking.Domain.Entities.Booking", b =>
                {
                    b.Navigation("BookingPartyLeaders");
                });

            modelBuilder.Entity("TourBooking.Domain.Entities.PartyLeader", b =>
                {
                    b.Navigation("BookingPartyLeaders");
                });
#pragma warning restore 612, 618
        }
    }
}
