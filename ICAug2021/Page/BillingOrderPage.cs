using Commons.Model;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAutomation.Page
{

    public class BillingOrderPage : BasePage
    {

        By _firstName = By.Id("wpforms-24-field_0");
        By _lastName = By.Id("wpforms-24-field_0-last");
        By _email = By.Id("wpforms-24-field_1");
        By _phone = By.Id("wpforms-24-field_2");
        By _addressLine1 = By.Id("wpforms-24-field_3");
        By _addressLine2 = By.Id("wpforms-24-field_3-address2");
        By _city = By.Id("wpforms-24-field_3-postal");
        By _submitButton = By.Id("wpforms-submit-24");

        public BillingOrderPage(IWebDriver driver) : base(driver)
        {
            Visit("http://qaauto.co.nz/billing-order-form/");
            TestContext.WriteLine("BillingOrderPage(IWebDriver driver)");
        }

        public void FirstName(string value) => Type(_firstName, value);
        public void LastName(string value) => Type(_lastName, value);
        public void Email(string value) => Type(_email, value);
        public void Phone(string value) => Type(_phone, value);
        public void AddressLine1(string value) => Type(_addressLine1, value);
        public void AddressLine2(string value) => Type(_addressLine2, value);
        public void City(string value) => Type(_city, value);

        public void FillOrderForm(BillingOrder order)
        {
            FirstName(order.FirstName);
            LastName(order.LastName);
            Email(order.Email);
            AddressLine1(order.AddressLine1);
            AddressLine2(order.AddressLine2);

        }

        public void Login()
        {
            Type(By.Id("wpforms-locked-24-field_form_locker_password"), "Testing");
            Type(By.Id("wpforms-locked-24-field_form_locker_password"), Keys.Enter);
        }

        internal void Validate()
        {
            //do validation here...
        }

        public void Submit() => Click(_submitButton);
    }
}
