using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Library.DataModel.Mappings
{
    public static class Mappings
    {
        // Static fields.
        private static bool _isInitialized;

        /// <summary>
        /// Initializes all object mappings.
        /// </summary>
        public static void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }

            lock (typeof(Mappings))
            {
                RegisterModules();
                _isInitialized = true;
            }
        }

        /// <summary>
        /// Resets all mapping tables and cleans up reues.
        /// </summary>
        public static void Cleanup()
        {
            if (!_isInitialized)
            {
                return;
            }

            lock (typeof(Mappings))
            {
                Mapper.Reset();
                _isInitialized = false;
            }
        }

        /// <summary>
        /// Maps members of an object to another one following the mapping rules set.
        /// </summary>
        /// <typeparam name="TSource">The System.Type of the source object.</typeparam>
        /// <typeparam name="TDestination">The System.Type of the destination object.</typeparam>
        /// <param name="source">The source object.</param>
        /// <returns>A new object of the destination Type, with all members mapped from the source.</returns>
        public static TDestination Map<TSource, TDestination>(this TSource source)
            where TSource : class
            where TDestination : class
        {
            if (!_isInitialized)
            {
                Initialize();
                //throw new InvalidOperationException("Must initialize before any mappings can be done");
            }

            return Mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Maps members of an object to another one following the mapping rules set.
        /// </summary>
        /// <typeparam name="TSource">The System.Type of the source object.</typeparam>
        /// <typeparam name="TDestination">The System.Type of the destination object.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="destination">The destination object.</param>
        /// <returns>A new object of the destination Type, with all members mapped from the source.</returns>
        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            if (!_isInitialized)
            {
                Initialize();
                //throw new InvalidOperationException("Must initialize before any mappings can be done");
            }

            return Mapper.Map(source, destination);
        }

        /// <summary>
        /// Maps members of an object to another one following the mapping rules set.
        /// </summary>
        /// <typeparam name="TSource">The System.Type of the source object.</typeparam>
        /// <typeparam name="TDestination">The System.Type of the destination object.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="destination">The destination object.</param>
        /// <param name="sourceType">The System.Type of the source object.</param>
        /// <param name="destinationType">The System.Type of the destination object.</param>
        /// <returns>A new object of the destination Type, with all members mapped from the source.</returns>
        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Type sourceType, Type destinationType)
        {
            if (!_isInitialized)
            {
                Initialize();
                //throw new InvalidOperationException("Must initialize before any mappings can be done");
            }

            return (TDestination)Mapper.Map(source, destination, sourceType, destinationType);
        }

        /// <summary>
        /// Maps an IEnumerable using the pre-configured Automapper.
        /// </summary>
        public static IEnumerable<TDestination> Map<TSource, TDestination>(this IEnumerable<TSource> source)
            where TSource : class
            where TDestination : class
        {
            foreach (var t in source)
            {
                yield return t.Map<TSource, TDestination>();
            }
        }

        /// <summary>
        /// Registers mapping modules.
        /// </summary>
        private static void RegisterModules()
        {
            var modules = new List<IMappingModule>
            {
                new LoanMappingModule(),
                new BookMappingModule(),
                new MemberMappingModule()
            };

            modules.ForEach(m => m.Register());
            Mapper.AssertConfigurationIsValid();
        }

    }
}
