using BlazorComplator.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorComplator.AppDbContext
{
    public class QueryDbContext : DbContext
    {
        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
        {

        }

        public DbSet<Query> Queries { get; set; }
    }
}
