using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace WebApplication1.BlogData
{
    public static class Extension
    {
        public static T FindByPrimaryKey<T>(this DbSet<T> set, object id) where T:class
        {
            var context = ((IInfrastructure<IServiceProvider>)set).GetService<DbContext>();

            var entityType = context.Model.FindEntityType(typeof(T));
            var key = entityType.FindPrimaryKey();

            if (key.Properties.Count > 1)
            {
                return null;
            }

            // Loop through key's properties and check if any of te names is present in change tracker values
            var entries = context.ChangeTracker.Entries<T>();
            foreach (var item in key.Properties)
            {
                entries = entries.Where(e => e.Property(item.Name).CurrentValue == id);
            }

            if (entries.Any())
            {
                // Return the local object if it exists.
                return entries.First().Entity;
            }

            // TODO: Build the real LINQ Expression
            // set.Where(x => x.Id == keyValues[0]);
            var parameter = Expression.Parameter(typeof(T), "x");
            var query = set.Where((Expression<Func<T, bool>>)
                Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, "Id"),
                        Expression.Constant(id)),
                    parameter));

            // Look in the database
            return query.FirstOrDefault();
        }
    }
}
