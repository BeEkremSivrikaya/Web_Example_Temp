using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Web_Example_Temp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Öğrenci> Öğrenciler { get; set; }
        public DbSet<Veli> Veliler { get; set; }
        public DbSet<Okul> Okullar { get; set; }
        public DbSet<ÖğrenciVeli> ÖğrenciVeliler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Okul>()
                .HasMany(o => o.Öğrenciler)
                .WithOne(ö => ö.Okul)
                .HasForeignKey(ö => ö.OkulId);

            modelBuilder.Entity<ÖğrenciVeli>()
                .HasKey(öv => new { öv.ÖğrenciId, öv.VeliId });

            modelBuilder.Entity<ÖğrenciVeli>()
                .HasOne(öv => öv.Öğrenci)
                .WithMany(ö => ö.ÖğrenciVeliler)
                .HasForeignKey(öv => öv.ÖğrenciId);

            modelBuilder.Entity<ÖğrenciVeli>()
                .HasOne(öv => öv.Veli)
                .WithMany(v => v.ÖğrenciVeliler)
                .HasForeignKey(öv => öv.VeliId);

            modelBuilder.Entity<Okul>()
                .Property(o => o.Ad)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Öğrenci>()
                .Property(ö => ö.Ad)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Öğrenci>()
                .Property(ö => ö.Soyad)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Veli>()
                .Property(v => v.Ad)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Veli>()
                .Property(v => v.Soyad)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
