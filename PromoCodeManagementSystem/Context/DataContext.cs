using Microsoft.EntityFrameworkCore;
using PromoCodeManagementSystem.Models;
namespace PromoCodeManagementSystem.Context
{
    public class DataContext:DbContext
    {
        public DbSet<PromocodesModel> Promocodes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Promocodes
            modelBuilder.Entity<PromocodesModel>().ToTable("Promocodes");

            modelBuilder.Entity<PromocodesModel>().HasKey(u => u.id).HasName("PK_Promocodes");

            modelBuilder.Entity<PromocodesModel>().Property(u => u.id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<PromocodesModel>().Property(u => u.promocode).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PromocodesModel>().Property(u => u.createdDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<PromocodesModel>().Property(u => u.updatedDateTime).HasColumnType("datetime").IsRequired(false);
            #endregion

          
        }
    }
}
