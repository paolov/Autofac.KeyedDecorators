namespace Tests.Autofac.KeyedDecorators.TestClasses
{
    public class FirstDecorator : IService
    {
        private readonly IService service;
        private readonly Tester tester;

        public FirstDecorator(IService service, Tester tester)
        {
            this.service = service;
            this.tester = tester;
        }

        public void Execute()
        {
            tester.Add("Fd1");
            service.Execute();
            tester.Add("Fd2");
        }
    }
}