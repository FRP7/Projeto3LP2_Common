using System;
using System.Collections.Generic;

namespace Common
{
    public static class ServiceLocator
    {
        // Dicionário de serviços.
        private static readonly IDictionary<Type, object> services = new Dictionary<Type, object>();

        // Método para registar serviço.
        public static void Register<T>(object serviceInstance)
        {
            services[typeof(T)] = serviceInstance;
        }

        // Método para obter serviço.
        public static T GetService<T>()
        {
            return (T)services[typeof(T)];
        }
    }
}
