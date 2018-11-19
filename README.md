# Autofac.KeyedDecorators
Helper functions for registering decorators of keyed services that support Autofac indexes (Autofac.Features.Indexed.IIndex&lt;K,V>)

```C#
var builder = new ContainerBuilder();

//simple registration per service and per decorator
 builder.RegisterKeyedType<FirstService>()
        .WithDecorator<FirstDecorator>()
        .WithDecorator<SecondDecorator>()
        .ForInterface<IService>()
        .WithKey("A");

builder.RegisterKeyedType<SecondService>()
       .WithDecorator<FirstDecorator>()
       .WithDecorator<SecondDecorator>()
       .ForInterface<IService>()
       .WithKey("B");

//or multiple registrations
var mapping = new Dictionary<string, Type>()
{
  ["A"] = typeof(FirstService),
  ["B"] = typeof(SecondService),
};

var decorators = new[]
{
typeof(FirstDecorator),
typeof(SecondDecorator)
};

builder.RegisterKeyedTypes(mapping)
       .ForInterface<IService>()
       .WithDecorators(decorators);

var container = builder.Build();

var factory = container.Resolve<IIndex<string, IService>>();
var svc = factory["A"];

 svc.Execute();
 ```
