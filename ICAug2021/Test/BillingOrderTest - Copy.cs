using Commons.Model;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using WebAutomation.Page;

namespace WebAutomation.Test
{
    class BillingOrderTest1
    {

        private IWebDriver driver;

        [SetUp]

        public void SetUp()
        {
            driver = new ChromeDriver();
            //  driver.Url = "http://qaauto.co.nz/billing-order-form/";
        }

        [TearDown]
        protected void TearDown() => driver.Quit();

        [Test]
        public void CreateBillingOrderTest()
        {
            BillingOrderPage orderPage = new BillingOrderPage(driver);
            orderPage.Login();
            orderPage.FirstName("Ajit");
            orderPage.LastName("Sharma");
        }



        [TestCaseSource("TestData")]
        public void CreateBillingOrderTestModel(BillingOrder orderObject)
        {
            driver.Url = "http://qaauto.co.nz/billing-order-form/";
            BillingOrderPage orderPage = new BillingOrderPage(driver);
            orderPage.Login();
            orderPage.FillOrderForm(orderObject);
            orderPage.Submit();
            orderPage.Validate();
        }


        static IEnumerable<TestCaseData> TestData()
        {
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "TestData\\basic.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    BillingOrder order =
                        new BillingOrder(
                        firstName: csv["firstname"],
                        lastName: csv["lastname"],
                        email: csv["email"]);

                    yield return new TestCaseData(order).SetName(csv["tcname"]);
                }
            }
        }
    }
}
