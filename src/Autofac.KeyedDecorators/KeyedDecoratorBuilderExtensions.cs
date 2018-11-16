using System;

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
    }
}