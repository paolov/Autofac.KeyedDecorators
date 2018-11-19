using NUnit.Framework;
using System.Text;

namespace Tests.Autofac.KeyedDecorators
{
    public class Tester
    {
        private readonly StringBuilder accumulator = new StringBuilder();

        public void Add(string str)
        {
            if (accumulator.Length > 0)
                accumulator.Append('-');

            accumulator.Append(str);
        }

        public void Test(string testString)
        {
            Assert.AreEqual(accumulator.ToString(), testString);
        }
    }
}