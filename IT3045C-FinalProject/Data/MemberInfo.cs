using System;
using IT3045C_FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace IT3045C_FinalProject.Data
{
    public class MemberInfo : DbContext
    {

        public MemberInfo(DbContextOptions<MemberInfo> options) : base(options)
        {

        }

        public DbSet<Member> Member { get; set; }
        public DbSet<Hobby> Hobby { get; set; }
        public DbSet<Breakfast> Breakfast { get; set; }
        public DbSet<Dinner> Dinner { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Member>().HasData(
            new Member
            {
                ID = 1,
                FullName = "Levi Huff",
                Program = "Information Technology",
                Year = "Junior",
                DOB = new DateTime(2001, 12, 07)
            },
            new Member
                {
                  ID = 2,
                  FullName = "Bearcat",
                  Program = "Spirit",
                  Year = "107th",
                  DOB = new DateTime(1914, 10, 31)
                }
            );
            builder.Entity<Hobby>().HasData(
            new Hobby
            {
                Id = 1,
                FullName = "Levi Huff",
                FavoriteHobby = "Technology",
                HowItStarted = "Family computer",
                WhyItStarted = "I was drawn to them right away"
            },
            new Hobby
            {
                Id = 2,
                FullName = "Bearcat",
                FavoriteHobby = "Mascotting",
                HowItStarted = "Kentucky Wildcats 1914 Game",
                WhyItStarted = "Fans cheered ‘Baehr-Cat’"
            }
            );
            builder.Entity<Breakfast>().HasData(
            new Breakfast
            {
                Id = 1,
                FullName = "Levi Huff",
                FavoriteBreakfastFood = "Pop Tarts",
                FavoriteSide = "Water",
                FavoriteBreakfastTime = "10:30 AM"
            },
            new Breakfast
            {
                Id = 2,
                FullName = "Bearcat",
                FavoriteBreakfastFood = "Xavier's Tears",
                FavoriteSide = "Did I mention Xavier's Tears",
                FavoriteBreakfastTime = "12:00 PM"
            }
            );
            builder.Entity<Dinner>().HasData(
            new Dinner
             {
                Id = 1,
                FullName = "Levi Huff",
                FavoriteDish = "Pizza Rolls",
                FavoriteSide = "Chips",
                FavoriteJoint = "Canes"
            },
            new Dinner
            {
                Id = 2,
                FullName = "Bearcat",
                FavoriteDish = "Xavier's Tears",
                FavoriteSide = "I literally only consume Xavier's tears",
                FavoriteJoint = "Fifth Third Arena"
            }
          );
        }
    }
}