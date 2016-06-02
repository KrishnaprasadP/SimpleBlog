using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.BlogData
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
