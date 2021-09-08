using Commons.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebAutomation.Page;

namespace WebAutomation.Feature.steps
{
    [Binding]
    public class BillingOrderSteps
    {
        IWebDriver driver;
        BillingOrderPage orderPage;


        [Given(@"I am on billing order page")]
        public void GivenIAmOnBillingOrderPage()
        {
            driver = new ChromeDriver();
            orderPage = new BillingOrderPage(driver);
            orderPage.Login();

        }

        [Given(@"enter user details")]
        public void GivenEnterUserDetails()
        {
            BillingOrder order = new BillingOrder();// << data
            orderPage.FillOrderForm(order);
        }

        [When(@"click submit button")]
        public void WhenClickSubmitButton()
        {
            orderPage.Submit();
        }

        [Then(@"user details should be submitted")]
        public void ThenUserDetailsShouldBeSubmitted()
        {
            orderPage.Validate();
        }
    }
}
