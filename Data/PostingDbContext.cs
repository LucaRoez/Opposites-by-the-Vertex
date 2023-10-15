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

        public DbSet<Post> Posts { get; set; }
    }
}
