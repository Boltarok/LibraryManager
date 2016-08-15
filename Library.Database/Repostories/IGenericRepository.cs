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
    /// Provides an interface for data entity repositories. 
    /// </summary>
    /// <typeparam name="T">The System.Type of the entities to be contained.</typeparam>
    public interface IGenericRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Returns the only element of the repository that satisfies a condition, or a default value if no such element is found.
        /// This method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <param name="where">The condition to satisfy.</param>
        /// <param name="includeProperties"></param>
        /// <returns>The single element of the repository that satisfies the condition, or the default value if no such element is found.</returns>
        T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Returns the first element of the repository that satisfies a condition, or a default value if no such element is found.
        /// </summary>
        /// <param name="where">The condition to satisfy.</param>
        /// <param name="includeProperties"></param>
        /// <returns>The first element of the repository that satisfies the condition, or the default value if no such element is found.</returns>
        T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
    }
}
