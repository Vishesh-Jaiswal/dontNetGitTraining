using BlogSpotApp.Models;
using Microsoft.EntityFrameworkCore;
using BlogSpotApp.Models;
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

    }
}