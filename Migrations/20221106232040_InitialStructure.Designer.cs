﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Api.Data;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(CaityContext))]
    [Migration("20221106232040_InitialStructure")]
    partial class InitialStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api.Models.GroceryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GroceryItems");
                });

            modelBuilder.Entity("api.Models.GroceryListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GroceryItemId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("GroceryListItem");
                });

            modelBuilder.Entity("api.Models.House", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<Guid>>("Members")
                        .HasColumnType("uuid[]");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("api.Models.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<List<Guid>>("Houses")
                        .HasColumnType("uuid[]");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("api.Models.GroceryListItem", b =>
                {
                    b.HasOne("api.Models.House", null)
                        .WithMany("GroceryListItems")
                        .HasForeignKey("HouseId");
                });

            modelBuilder.Entity("api.Models.House", b =>
                {
                    b.Navigation("GroceryListItems");
                });
#pragma warning restore 612, 618
        }
    }
}
