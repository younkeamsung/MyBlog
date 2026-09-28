using BlazorApp2.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Database;

public class BlogDbContext(DbContextOptions<BlogDbContext> options)
    : DbContext(options)
{
    public DbSet<BlogPost> BlogPosts { get; set; } // Db에 세팅할건데 BlogPost라는 곳에있는 필드로 BlogPosts라는 이름의 테이블

    public DbSet<Category> Categorys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogPost>()
            .HasOne(p => p.Category)
            .WithMany(c => c.BlogPosts)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
