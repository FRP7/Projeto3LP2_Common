using System;
using System.Collections.Generic;

namespace Common
{
    public static class ServiceLocator
    {
        // Dicionario de serviços.
        private static readonly IDictionary<Type, object> services = new Dictionary<Type, object>();

        // Metodo para registar serviço.
        public static void Register<T>(object serviceInstance)
        {
            services[typeof(T)] = serviceInstance;
        }

        // Metodo para obter serviço
        public static T GetService<T>()
        {
            return (T)services[typeof(T)];
        }
    }
}
