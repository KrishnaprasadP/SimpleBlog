using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace WebApplication1.BlogData
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class ReadOnlyRepositoryBase<T> : IReadOnlyRepositoryBase<T> where T: class
    {
        BlogDbContext _dbContext;

        public ReadOnlyRepositoryBase(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetWithTracking()
        {
            return _dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().FindByPrimaryKey(id as object);
        }        
    }
}
