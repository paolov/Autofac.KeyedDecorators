namespace Tests.Autofac.KeyedDecorators
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new TestDecorator().TestDecoratorOrder();
            new TestDecorator().TestMultipleDecorators();
        }
    }
}