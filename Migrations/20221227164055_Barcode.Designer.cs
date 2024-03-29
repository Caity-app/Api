﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(CaityContext))]
    [Migration("20221227164055_Barcode")]
    partial class Barcode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.Models.GroceryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GroceryItems");
                });

            modelBuilder.Entity("Api.Models.GroceryListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uuid");

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("ItemId");

                    b.ToTable("GroceryListItems");
                });

            modelBuilder.Entity("Api.Models.House", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Api.Models.LoginMetadata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("LoginMetadata");
                });

            modelBuilder.Entity("Api.Models.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("HouseMember", b =>
                {
                    b.Property<Guid>("HousesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MembersId")
                        .HasColumnType("uuid");

                    b.HasKey("HousesId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("HouseMember");
                });

            modelBuilder.Entity("Api.Models.GroceryListItem", b =>
                {
                    b.HasOne("Api.Models.House", null)
                        .WithMany("GroceryListItems")
                        .HasForeignKey("HouseId");

                    b.HasOne("Api.Models.GroceryItem", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Api.Models.House", b =>
                {
                    b.HasOne("Api.Models.Member", "CreatedBy")
                        .WithMany("CreatedHouses")
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Api.Models.LoginMetadata", b =>
                {
                    b.HasOne("Api.Models.Member", "Member")
                        .WithMany("KnownDevices")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HouseMember", b =>
                {
                    b.HasOne("Api.Models.House", null)
                        .WithMany()
                        .HasForeignKey("HousesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.House", b =>
                {
                    b.Navigation("GroceryListItems");
                });

            modelBuilder.Entity("Api.Models.Member", b =>
                {
                    b.Navigation("CreatedHouses");

                    b.Navigation("KnownDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
