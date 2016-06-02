using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication1.BlogData;

namespace WebApplication1.BlogData
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Blog> Blogs { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
