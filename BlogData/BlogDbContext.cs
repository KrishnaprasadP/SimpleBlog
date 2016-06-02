using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.BlogData;

namespace WebApplication1.BlogData
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        //Adding required DBSet for DB creation
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
                
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
            
        }

        public void InitializeDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Blog>().HasKey(x => x.Id);
            builder.Entity<Blog>().Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Entity<Blog>().Property(x => x.Title).HasMaxLength(30);
            //builder.Entity<Blog>().Property(x => x.UserId).IsRequired();

            builder.Entity<Comment>().HasKey(x => x.Id);
            builder.Entity<Comment>().Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Entity<Comment>().HasOne(x => x.Blog).WithMany(x => x.Comments).HasForeignKey(x=>x.BlogId);            
        }

        //public class DBInitializer : DropCreateDatabaseAlways
    }
}
