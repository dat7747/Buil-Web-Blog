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
        public DbSet<BMW> BMW { get; set; } 
        public DbSet<LoaiBMW> LoaiBMW { get; set; } 
        public DbSet<Ferrari> Ferrari { get; set; }
        public DbSet<LoaiFerrari> LoaiFerrari { get; set; }
        public DbSet<Volkswagen> Volkswagen { get; set; } 
        public DbSet<LoaiVolkswagen> LoaiVolkswagen { get; set; }
        public DbSet<Lamborghini> Lamborghini { get; set; }
        public DbSet<LoaiLamborghini> LoaiLamborghini { get; set; }
        public DbSet<Toyota> Toyota { get; set; }
        public DbSet<LoaiToyota> LoaiToyota { get; set; }
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
            modelBuilder.Entity<BMW>()
                .HasOne(a => a.LoaiBMW)
                .WithMany(l => l.BMWList)
                .HasForeignKey(a => a.LoaiID); 
            modelBuilder.Entity<Ferrari>()
                .HasOne(f => f.LoaiFerrari)
                .WithMany(l => l.FerrariList)
                .HasForeignKey(f => f.LoaiID);
            modelBuilder.Entity<Volkswagen>()
                .HasOne(v => v.LoaiVolkswagen)
                .WithMany(l => l.VolkswagenList)
                .HasForeignKey(v => v.LoaiID);
            modelBuilder.Entity<Lamborghini>()
                .HasOne(l => l.LoaiLamborghini)
                .WithMany(l => l.LamborghiniList)
                .HasForeignKey(l => l.LoaiID);
            modelBuilder.Entity<Toyota>()
                .HasOne(t => t.LoaiToyota)
                .WithMany(l => l.ToyotaList)
                .HasForeignKey(t => t.LoaiID);
        }
    }
}
