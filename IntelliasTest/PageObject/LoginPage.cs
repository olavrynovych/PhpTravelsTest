using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PhpTravelsTest.PageObject
{
    public class LoginPage
    {
        readonly IWebDriver _driver;
        readonly WebDriverWait _wait;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 60));
        }
        private IWebElement UserNameField
        {
            get
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));
                return _driver.FindElement(By.Name("username"));
            }
        }
        private IWebElement PasswordField
        {
            get
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
                return _driver.FindElement(By.Name("password"));
            }
        }

        private IWebElement LoginBtn
        {
            get
            {
                return _driver.FindElement(By.XPath(".//button[text()='Login']"));
            }
        }

        public void SetUserName(string username)
        {
            UserNameField.SendKeys(username);
        }

        public void SetPassword(string password)
        {
            PasswordField.SendKeys(password);
        }
        public void ClickLogin()
        {
            LoginBtn.Click();
        }
        public AccountPage Login(string username, string password)
        {
            SetUserName(username);
            SetPassword(password);
            ClickLogin();
            return new AccountPage(_driver);
        }
    }
}
