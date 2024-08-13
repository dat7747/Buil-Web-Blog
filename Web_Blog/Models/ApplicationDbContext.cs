using Microsoft.EntityFrameworkCore;

namespace Web_Blog.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Poscher> Poscher { get; set; } // Định nghĩa DbSet cho bảng Poscher
        public DbSet<LoaiPoscher> LoaiPoscher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poscher>()
                .Property(p => p.Image)
                .HasColumnName("Image"); // Đảm bảo rằng tên cột đúng

            modelBuilder.Entity<LoaiPoscher>()
                .Property(l => l.TenLoai)
                .HasColumnName("TenLoai"); // Đảm bảo rằng tên cột đúng

            modelBuilder.Entity<Poscher>()
                .HasOne(p => p.LoaiPoscher)
                .WithMany(l => l.Poschers)
                .HasForeignKey(p => p.LoaiID);
        }
    }
}
