using System;
using System.Collections.Generic;
using System.Linq;

namespace Autofac.KeyedDecorators
{
    public static class KeyedDecoratorBuilderExtensions
    {
        public static IKeyedDecoratorRegistrationBuilder<IMissInterfaceDefinition> RegisterKeyedType<TService>(this ContainerBuilder builder)
        {
            return RegisterKeyedType(builder, typeof(TService));
        }

        public static IKeyedDecoratorRegistrationBuilder<IMissInterfaceDefinition> RegisterKeyedType(this ContainerBuilder builder, Type serviceType)
        {
            return new KeyedDecoratorRegistrationBuilder<IMissInterfaceDefinition>(builder, serviceType);
        }

        public static IEnumerable<IKeyedDecoratorRegistrationBuilder<IMissInterfaceDefinition>> RegisterKeyedTypes<TKey>(this ContainerBuilder builder, IDictionary<TKey, Type> serviceMapping)
        {
            return serviceMapping.Select(map => new KeyedDecoratorRegistrationBuilder<IMissInterfaceDefinition>(builder, map.Value).WithKey(map.Key)).ToArray();
        }

        public static IEnumerable<IKeyedDecoratorRegistrationBuilder<T>> WithDecorators<T>(this IEnumerable<IKeyedDecoratorRegistrationBuilder<T>> builders, IEnumerable<Type> decoratorTypes)
        {
            return builders.Select(b => b.WithDecorators(decoratorTypes)).ToArray();
        }

        public static IEnumerable<IKeyedDecoratorRegistrationBuilder<TInterface>> ForInterface<TInterface>(this IEnumerable<IKeyedDecoratorRegistrationBuilder<IMissInterfaceDefinition>> builders)
        {
            return builders.Select(b => b.ForInterface<TInterface>()).ToArray();
        }
    }
}