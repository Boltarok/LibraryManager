using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Database.Repostories
{
    using System;
    using System.Linq.Expressions;
    using EntityFramework.Patterns;

    /// <summary>
    /// Provides a base class for repositories, representing a data source containing data entities and providing methods to query, insert, update and delete instances.
    /// </summary>
    /// <typeparam name="T">The System.Type of the data entity to manage.</typeparam>
    public class GenericRepository<T> : Repository<T>, IGenericRepository<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="factory">An object used to instantiate an ObjectSet containing data entities and manage their state.</param>
        public GenericRepository(IObjectSetFactory factory)
            : base(factory)
        {
        }

        /// <summary>
        /// Returns the only element of the repository that satisfies a condition, or a default value if no such element is found.
        /// This method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <param name="where">The condition to satisfy.</param>
        /// <param name="includeProperties"></param>
        /// <returns>The single element of the repository that satisfies the condition, or the default value if no such element is found.</returns>
        public T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                return Single(where, includeProperties);
            }
            catch (InvalidOperationException)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Returns the first element of the repository that satisfies a condition, or a default value if no such element is found.
        /// </summary>
        /// <param name="where">The condition to satisfy.</param>
        /// <param name="includeProperties"></param>
        /// <returns>The first element of the repository that satisfies the condition, or the default value if no such element is found.</returns>
        public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                return First(where, includeProperties);
            }
            catch (InvalidOperationException)
            {
                return default(T);
            }
        }
    }
}
