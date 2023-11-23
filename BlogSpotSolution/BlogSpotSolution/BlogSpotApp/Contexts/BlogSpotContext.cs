using BlogSpotApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BlogSpotApp.Contexts
{
    public class BlogSpotContext : DbContext
    {
        public BlogSpotContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(u => u.Blogs)
                .WithOne(bp => bp.Author)
                .HasForeignKey(bp => bp.UserEmail)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Blog>()
             .HasMany(b => b.Comments)
             .WithOne(c => c.BlogPost)
             .HasForeignKey(c => c.BlogId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserEmail)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.BlogPost)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Follow>()
                .HasKey(uf => new { uf.FollowerEmail, uf.FollowedEmail });

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowerEmail)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Followed)
                .WithMany(u => u.Follows)
                .HasForeignKey(f => f.FollowedEmail)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }


    }
}