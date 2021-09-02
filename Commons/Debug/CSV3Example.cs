using Commons.Model;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Commons.Debug
{
    class CSV3Example
    {

        [TestCaseSource("TestData")]
        public void CSVTestExample(BillingOrder order)
        {
            TestContext.WriteLine(order.FirstName);
            TestContext.WriteLine(order.LastName);
            TestContext.WriteLine(order.Email);
        }


        static IEnumerable<TestCaseData> TestData()
        {
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "TestData\\basic.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    BillingOrder order =
                        new BillingOrder(firstName: csv["firstname"],
                        lastName: csv["lastname"], email: csv["email"]);

                    if (csv["dp"].Equals("1")) yield return new TestCaseData(order);
                }
            }
        }
    }
}
