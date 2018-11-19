using System;
using System.Collections.Generic;

namespace Autofac.KeyedDecorators
{
    internal class KeyedDecoratorRegistrationBuilder<TInterface> : IKeyedDecoratorRegistrationBuilder<TInterface>
    {
        private readonly KeyedDecoratorRegistrationData data;

        public KeyedDecoratorRegistrationBuilder(ContainerBuilder builder, Type serviceType)
            : this(new KeyedDecoratorRegistrationData(builder, serviceType)) { }

        private KeyedDecoratorRegistrationBuilder(KeyedDecoratorRegistrationData data)
        {
            this.data = data;
            data.CheckModuleRegistration<TInterface>(data);
        }

        public IKeyedDecoratorRegistrationBuilder<T> ForInterface<T>()
        {
            data.InterfaceSpecified = true;
            return new KeyedDecoratorRegistrationBuilder<T>(data);
        }

        public IKeyedDecoratorRegistrationBuilder<TInterface> WithDecorator<TDecorator>()
        {
            return WithDecorator(typeof(TDecorator));
        }

        public IKeyedDecoratorRegistrationBuilder<TInterface> WithDecorator(Type decoratorType)
        {
            data.ServiceDecoratorOrder.Add(decoratorType);
            return this;
        }

        public IKeyedDecoratorRegistrationBuilder<TInterface> WithDecorators(IEnumerable<Type> decoratorTypes)
        {
            foreach (var type in decoratorTypes)
                data.ServiceDecoratorOrder.Add(type);

            return this;
        }

        public IKeyedDecoratorRegistrationBuilder<TInterface> WithKey(object key)
        {
            if (data.ServiceKey != null) throw new InvalidOperationException("Key already defined");
            data.ServiceKey = key;
            return this;
        }
    }
}