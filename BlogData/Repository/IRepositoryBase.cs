using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.BlogData
{
    interface IRepositoryBase<T> : IReadOnlyRepositoryBase<T> where T : class
    {
        void Delete(T entity);
        void Delete(int id);
        void Update(T entity);
        void Add(T entity);
    }
}
