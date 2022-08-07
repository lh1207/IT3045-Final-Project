using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IT3045C_FinalProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakfast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    FavoriteBreakfastFood = table.Column<string>(nullable: true),
                    FavoriteSide = table.Column<string>(nullable: true),
                    FavoriteBreakfastTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dinner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    FavoriteDish = table.Column<string>(nullable: true),
                    FavoriteSide = table.Column<string>(nullable: true),
                    FavoriteJoint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobby",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    FavoriteHobby = table.Column<string>(nullable: true),
                    HowItStarted = table.Column<string>(nullable: true),
                    WhyItStarted = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobby", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Program = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Breakfast",
                columns: new[] { "Id", "FavoriteBreakfastFood", "FavoriteBreakfastTime", "FavoriteSide", "FullName" },
                values: new object[,]
                {
                    { 1, "Pop Tarts", "10:30 AM", "Water", "Levi Huff" },
                    { 2, "Xavier's Tears", "12:00 PM", "Did I mention Xavier's Tears", "Bearcat" }
                });

            migrationBuilder.InsertData(
                table: "Dinner",
                columns: new[] { "Id", "FavoriteDish", "FavoriteJoint", "FavoriteSide", "FullName" },
                values: new object[,]
                {
                    { 1, "Pizza Rolls", "Canes", "Chips", "Levi Huff" },
                    { 2, "Xavier's Tears", "Fifth Third Arena", "I literally only consume Xavier's tears", "Bearcat" }
                });

            migrationBuilder.InsertData(
                table: "Hobby",
                columns: new[] { "Id", "FavoriteHobby", "FullName", "HowItStarted", "WhyItStarted" },
                values: new object[,]
                {
                    { 1, "Technology", "Levi Huff", "Family computer", "I was drawn to them right away" },
                    { 2, "Mascotting", "Bearcat", "Kentucky Wildcats 1914 Game", "Fans cheered ‘Baehr-Cat’" }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "ID", "DOB", "FullName", "Program", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Levi Huff", "Information Technology", "Junior" },
                    { 2, new DateTime(1914, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bearcat", "Spirit", "107th" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakfast");

            migrationBuilder.DropTable(
                name: "Dinner");

            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
