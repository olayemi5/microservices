using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id =  1, ProductName = "Iphone XR", Description="One of the best ever made", Amount=100},
                new Coupon { Id =  2, ProductName = "Fridge", Description="Nice to have", Amount=600}
                );
        }
    }
}
