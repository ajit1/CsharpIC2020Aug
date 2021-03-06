using Commons.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebAutomation.Page;

namespace WebAutomation.Test
{
    class BillingOrderTest
    {

        private IWebDriver driver;

        [SetUp]

        public void SetUp()
        {
            driver = new ChromeDriver();
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
            orderPage.Submit();
        }

        //BillingOrder orderObject = new BillingOrder
        //{
        //    AddressLine1 = "test",
        //    AddressLine2 = "test",
        //    FirstName = "ajit",
        //    LastName = "test",
        //    Phone = "1234567898",
        //    ZipCode = "123456",
        //    ItemNumber = 1,
        //    State = "AL",
        //    Email = "aj@testing.com",
        //    City = "test",
        //    Comment = "test comment"
        //};


        [Test]
        public void CreateBillingOrderTestModel()
        {
            BillingOrder orderObject = new BillingOrder(email: "");
            driver.Url = "http://qaauto.co.nz/billing-order-form/";
            BillingOrderPage orderPage = new BillingOrderPage(driver);
            orderPage.Login();
            orderPage.FillOrderForm(orderObject);
            orderPage.Submit();
            orderPage.Validate();

            //assertion ...
        }
    }
}
