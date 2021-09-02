using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Commons.Debug
{
    class CSVExample
    {
        [TestCaseSource("TestData")]
        public void CSVTestExample(string name)
        {
            TestContext.WriteLine(name);
        }


        static IEnumerable<string> TestData()
        {
            string filename = "TestData\\basic.csv";
            string currentDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            string completePath = currentDir + filename;

            using (var reader = new CsvReader(new StreamReader(completePath), false))
            {
                while (reader.ReadNextRecord())
                    yield return reader[0];
            }
        }
    }
}
