using System;
using System.Collections.Generic;

namespace Autofac.KeyedDecorators
{
    internal class KeyedDecoratorRegistrationData
    {
        private readonly ContainerBuilder builder;

        public KeyedDecoratorRegistrationData(ContainerBuilder builder, Type serviceType)
        {
            this.builder = builder;
            ServiceType = serviceType;
        }

        public List<Type> ServiceDecoratorOrder { get; } = new List<Type>();
        public object ServiceKey { get; set; }
        public Type ServiceType { get; set; }
        public bool InterfaceSpecified { get; set; }

        public void CheckModuleRegistration<TInterface>(KeyedDecoratorRegistrationData data)
        {
            builder.RegisterModule(new KeyedDecoratorModule<TInterface>(data));
        }

        public object GenerateKey(bool isFirst)
        {
            return isFirst ? ServiceKey : NewKey();
        }

        private object NewKey()
        {
            return Guid.NewGuid();
        }
    }
}