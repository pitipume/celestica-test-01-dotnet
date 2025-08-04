using Celestica.Models;
using Microsoft.EntityFrameworkCore;

namespace Celestica.Services
{
    public class ShabuMemberPromotionDBContext : DbContext
    {
        public ShabuMemberPromotionDBContext(DbContextOptions<ShabuMemberPromotionDBContext> options) : base(options)
        {

        }
        public DbSet<ShabuMemberPromotion> ShabuMemberPromotion { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Promotion> Promotion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShabuMemberPromotion>()
                .HasKey(x => new
                {
                    x.MemberId,
                    x.PromotionId,
                    x.RedeemedOn,
                });

            modelBuilder.Entity<ShabuMemberPromotion>()
                .HasOne(x => x.Member)
                .WithMany(x => x.ShabuMemberPromotion)
                .HasForeignKey(x => x.MemberId);

            modelBuilder.Entity<ShabuMemberPromotion>()
                .HasOne(x => x.Promotion)
                .WithMany(x => x.ShabuMemberPromotion)
                .HasForeignKey(x => x.PromotionId);
        }
    }
}