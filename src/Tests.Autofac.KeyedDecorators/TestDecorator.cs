using Autofac;
using Autofac.Features.Indexed;
using Autofac.KeyedDecorators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tests.Autofac.KeyedDecorators.TestClasses;

namespace Tests.Autofac.KeyedDecorators
{
    [TestFixture]
    public class TestDecorator
    {
        [Test]
        public void TestDecoratorOrder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterKeyedType<FirstService>()
                   .WithDecorator<FirstDecorator>()
                   .WithDecorator<SecondDecorator>()
                   .ForInterface<IService>()
                   .WithKey("A");

            var tester = new Tester();

            builder.Register(_ => tester);

            var container = builder.Build();

            var factory = container.Resolve<IIndex<string, IService>>();

            var firstService = factory["A"];

            firstService.Execute();

            tester.Test("Fd1-Sd1-Fs-Sd2-Fd2");
        }

        [Test]
        public void TestMultipleDecorators()
        {
            var mapping = new Dictionary<string, Type>()
            {
                ["First"] = typeof(FirstService),
                ["Second"] = typeof(SecondService),
            };

            var decorators = new[]
            {
                typeof(FirstDecorator),
                typeof(SecondDecorator)
            };

            var builder = new ContainerBuilder();

            builder.RegisterKeyedTypes(mapping)
                   .ForInterface<IService>()
                   .WithDecorators(decorators);

            var tester = new Tester();

            builder.Register(_ => tester);

            var container = builder.Build();

            var factory = container.Resolve<IIndex<string, IService>>();

            var firstService = factory["First"];
            var secondService = factory["Second"];

            firstService.Execute();
            secondService.Execute();

            tester.Test("Fd1-Sd1-Fs-Sd2-Fd2-Fd1-Sd1-Ss-Sd2-Fd2");
        }
    }
}