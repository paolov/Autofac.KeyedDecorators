namespace Tests.Autofac.KeyedDecorators.TestClasses
{
    public class SecondDecorator : IService
    {
        private readonly IService service;
        private readonly Tester tester;

        public SecondDecorator(IService service, Tester tester)
        {
            this.service = service;
            this.tester = tester;
        }

        public void Execute()
        {
            tester.Add("Sd1");
            service.Execute();
            tester.Add("Sd2");
        }
    }
}