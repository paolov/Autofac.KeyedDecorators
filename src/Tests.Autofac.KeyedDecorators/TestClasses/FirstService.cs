namespace Tests.Autofac.KeyedDecorators.TestClasses
{
    public class FirstService : IService
    {
        private readonly Tester tester;

        public FirstService(Tester tester)
        {
            this.tester = tester;
        }

        public void Execute()
        {
            tester.Add("Fs");
        }
    }
}