using System;

namespace Autofac.KeyedDecorators
{
    public class KeyedDecoratorModule<TInterface> : Module
    {
        private readonly KeyedDecoratorRegistrationData data;

        public KeyedDecoratorModule(KeyedDecoratorRegistrationData data)
        {
            this.data = data;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (typeof(TInterface) == typeof(IMissInterfaceDefinition))
            {
                if (data.InterfaceSpecified)
                    return;
                else
                    throw new InvalidOperationException($"Interface is not specified for service {data.ServiceType.Name}");
            }

            if (data.ServiceKey == null)
                throw new InvalidOperationException($"Key is not specified for service {data.ServiceType.Name} and interface {typeof(TInterface).Name}");

            var currentKey = data.GenerateKey(data.ServiceDecoratorOrder.Count == 0);

            builder.RegisterType(data.ServiceType).Keyed<TInterface>(currentKey);

            for (int i = data.ServiceDecoratorOrder.Count - 1; i >= 0; i--)
            {
                var decoratorType = data.ServiceDecoratorOrder[i];

                builder.RegisterType(decoratorType);

                var nextKey = data.GenerateKey(i == 0);

                var registrationFunc = new Func<IComponentContext, TInterface, TInterface>((ctx, inner) => (TInterface)ctx.Resolve(decoratorType, new TypedParameter(typeof(TInterface), inner)));

                builder.RegisterDecorator(registrationFunc, currentKey).Keyed<TInterface>(nextKey);

                currentKey = nextKey;
            }
        }
    }
}