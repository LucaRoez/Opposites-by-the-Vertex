using Microsoft.EntityFrameworkCore;
using Opuestos_por_el_Vertice.Data.Entities;

namespace Opuestos_por_el_Vertice.Data
{
    public class PostingDbContext : DbContext
    {
        public PostingDbContext()
        {

        }
        public PostingDbContext(DbContextOptions<PostingDbContext> op)
            : base(op) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<User> Users_Security { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<New>().HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId); modelBuilder.Entity<New>().Property(p => p.Body).HasMaxLength(4000);
            modelBuilder.Entity<Event>().HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId); ; modelBuilder.Entity<Event>().Property(p => p.Body).HasMaxLength(4000);
            modelBuilder.Entity<Artist>().HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId); ; modelBuilder.Entity<Artist>().Property(p => p.Body).HasMaxLength(4000);
            modelBuilder.Entity<Album>().HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId); ; modelBuilder.Entity<Album>().Property(p => p.Body).HasMaxLength(4000);
            modelBuilder.Entity<Genre>().HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId); ; modelBuilder.Entity<Genre>().Property(p => p.Body).HasMaxLength(4000);
        }
    }
}
