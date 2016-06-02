using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.BlogData
{
    interface IReadOnlyRepositoryBase<T> where T : class
    {
        IQueryable<T> Get();

        T GetById(int id);

        IQueryable<T> GetWithTracking();        
    }
}
