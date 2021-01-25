using System;
using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Class where the GameData is registered (instead of using static
    /// properties).
    /// </summary>
    public static class ServiceLocator
    {
        // Dictionary of services.
        private static readonly IDictionary<Type, object> Services =
            new Dictionary<Type, object>();

        /// <summary>
        /// Method to register service.
        /// </summary>
        /// <typeparam name="T"> Type of service.</typeparam>
        /// <param name="serviceInstance"> The service instance.</param>
        public static void Register<T>(object serviceInstance)
        {
            Services[typeof(T)] = serviceInstance;
        }

        /// <summary>
        /// Method to access service.
        /// </summary>
        /// <typeparam name="T"> Service type.</typeparam>
        /// <returns> Returns service.</returns>
        public static T GetService<T>()
        {
            return (T)Services[typeof(T)];
        }
    }
}
