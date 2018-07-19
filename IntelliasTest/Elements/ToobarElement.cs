using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PhpTravelsTest.PageObject;

namespace PhpTravelsTest.Elements
{
    public class ToobarElement
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly IWebElement _toolbar;
        public ToobarElement(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new TimeSpan(0,0,50));
            _toolbar = _driver.FindElement(By.XPath("//nav[@class='navbar navbar-default']"));
        }

        private IWebElement MyAccountButton
        {
            get { return _toolbar.FindElement(By.XPath(".//li[@id='li_myaccount']")); }
        }

        private IWebElement LoginButton
        {
            get { return _toolbar.FindElement(By.XPath(".//a[text()=' Login']")); }
        }


        public LoginPage GoToLoginPage()
        {
            MyAccountButton.Click();
            LoginButton.Click();
            return new LoginPage(_driver);
        }

        public void GoToSignUpPage()
        {
            throw new NotImplementedException();
        }
    }
}
