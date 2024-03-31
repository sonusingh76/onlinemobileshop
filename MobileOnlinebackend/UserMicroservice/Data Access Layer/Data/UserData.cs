using Microsoft.EntityFrameworkCore;
using MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.PaymentMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Data
{
    public class UserData : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Mobile>Mobiles { get; set; }
        public DbSet<Payment>Payments { get; set; }

        public UserData(DbContextOptions<UserData> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.ConfirmPassword)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.IsAdmin)
                .IsRequired();

            //Relationship 

            modelBuilder.Entity<Order>()
                .HasOne(o=>o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Mobile)
                .WithMany()
                .HasForeignKey(o => o.MobileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
              .HasOne(p => p.Order)
              .WithOne()
              .HasForeignKey<Payment>(p => p.OrderId)
              .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }

}
