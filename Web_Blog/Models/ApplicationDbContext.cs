using Microsoft.EntityFrameworkCore;

namespace Web_Blog.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Poscher> Poscher { get; set; } 
        public DbSet<LoaiPoscher> LoaiPoscher { get; set; }
        public DbSet<Mercedes> Mercedes { get; set; }
        public DbSet<LoaiMercedes> LoaiMercedes { get; set; }
        public DbSet<Audi> Audi { get; set; } 
        public DbSet<LoaiAudi> LoaiAudi { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poscher>()
                .Property(p => p.Image)
                .HasColumnName("Image"); 

            modelBuilder.Entity<LoaiPoscher>()
                .Property(l => l.TenLoai)
                .HasColumnName("TenLoai");

            modelBuilder.Entity<Poscher>()
                .HasOne(p => p.LoaiPoscher)
                .WithMany(l => l.Poschers)
                .HasForeignKey(p => p.LoaiID);
                
            modelBuilder.Entity<Mercedes>()
                .HasOne(m => m.LoaiMercedes)
                .WithMany(l => l.MercedesList)
                .HasForeignKey(m => m.LoaiID);
            modelBuilder.Entity<Audi>()
                .HasOne(a => a.LoaiAudi)
                .WithMany(l => l.AudiList)
                .HasForeignKey(a => a.LoaiID);    
        }
    }
}
