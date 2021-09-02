using NUnit.Framework;
using System.Collections.Generic;

namespace Commons.Debug
{
    class LoopExample
    {
        [TestCaseSource("TestData")]
        public void CSVTestExample(string name)
        {
            TestContext.WriteLine(name);
        }


        static IEnumerable<string> TestData()
        {
            for (int i = 0; i <= 100; i++)
                yield return "Test " + i;
        }
    }
}
