namespace Tests.Autofac.KeyedDecorators.TestClasses
{
    public class SecondService : IService
    {
        private readonly Tester tester;

        public SecondService(Tester tester)
        {
            this.tester = tester;
        }

        public void Execute()
        {
            tester.Add("Ss");
        }
    }
}