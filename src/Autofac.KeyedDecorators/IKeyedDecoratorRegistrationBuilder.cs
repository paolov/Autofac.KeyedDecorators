using System;

namespace Autofac.KeyedDecorators
{
    public interface IKeyedDecoratorRegistrationBuilder<TInterface>
    {
        IKeyedDecoratorRegistrationBuilder<TInterface> WithDecorator<TDecorator>();

        IKeyedDecoratorRegistrationBuilder<TInterface> WithDecorator(Type decoratorType);

        IKeyedDecoratorRegistrationBuilder<TInterface> WithKey(object key);

        IKeyedDecoratorRegistrationBuilder<T> ForInterface<T>();
    }
}