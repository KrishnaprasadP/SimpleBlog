using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.BlogData;

namespace WebApplication1.BlogData
{
    public class DBInitializer
    {
        private BlogDbContext _ctxt;
        private UserManager<ApplicationUser> _userManager;

        public DBInitializer(BlogDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _ctxt = dbContext;
            _userManager = userManager;            
        }

        public async Task InitializeData()
        {
            await PopulateSampleUser();
            PopulateBlogData();
        }

        private async Task PopulateSampleUser()
        {
            var user = new ApplicationUser { UserName = "Admin", Email = "admin@gmail.com" };
            await _userManager.CreateAsync(user, "@dMIN14");            
            await _userManager.AddClaimAsync(user, new Claim("ManageStore", "Allowed"));
        }

        private void PopulateBlogData()
        {
            
            _ctxt.Blogs.Add(new Blog
            {
                Title = "First Auto Created blog",
                Content = "No idea",
                Comments = new List<Comment>
                {
                    new Comment {Content = "Great" }
                }
            });

            _ctxt.SaveChanges();
        }
    }
}
