﻿// <auto-generated />
using System;
using IT3045C_FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IT3045C_FinalProject.Migrations
{
    [DbContext(typeof(MemberInfo))]
    [Migration("20220807004949_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IT3045C_FinalProject.Models.Breakfast", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FavoriteBreakfastFood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavoriteBreakfastTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavoriteSide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Breakfast");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FavoriteBreakfastFood = "Pop Tarts",
                            FavoriteBreakfastTime = "10:30 AM",
                            FavoriteSide = "Water",
                            FullName = "Levi Huff"
                        },
                        new
                        {
                            Id = 2,
                            FavoriteBreakfastFood = "Xavier's Tears",
                            FavoriteBreakfastTime = "12:00 PM",
                            FavoriteSide = "Did I mention Xavier's Tears",
                            FullName = "Bearcat"
                        });
                });

            modelBuilder.Entity("IT3045C_FinalProject.Models.Dinner", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FavoriteDish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavoriteJoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavoriteSide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dinner");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FavoriteDish = "Pizza Rolls",
                            FavoriteJoint = "Canes",
                            FavoriteSide = "Chips",
                            FullName = "Levi Huff"
                        },
                        new
                        {
                            Id = 2,
                            FavoriteDish = "Xavier's Tears",
                            FavoriteJoint = "Fifth Third Arena",
                            FavoriteSide = "I literally only consume Xavier's tears",
                            FullName = "Bearcat"
                        });
                });

            modelBuilder.Entity("IT3045C_FinalProject.Models.Hobby", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FavoriteHobby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HowItStarted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhyItStarted")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hobby");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FavoriteHobby = "Technology",
                            FullName = "Levi Huff",
                            HowItStarted = "Family computer",
                            WhyItStarted = "I was drawn to them right away"
                        },
                        new
                        {
                            Id = 2,
                            FavoriteHobby = "Mascotting",
                            FullName = "Bearcat",
                            HowItStarted = "Kentucky Wildcats 1914 Game",
                            WhyItStarted = "Fans cheered ‘Baehr-Cat’"
                        });
                });

            modelBuilder.Entity("IT3045C_FinalProject.Models.Member", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Program")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DOB = new DateTime(2001, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Levi Huff",
                            Program = "Information Technology",
                            Year = "Junior"
                        },
                        new
                        {
                            ID = 2,
                            DOB = new DateTime(1914, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Bearcat",
                            Program = "Spirit",
                            Year = "107th"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}