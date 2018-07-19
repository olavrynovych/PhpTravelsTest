using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PhpTravelsTest.PageObject;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PhpTravelsTest.Elements
{
    public class BookingRow
    {
        private readonly IWebDriver _driver;
        private readonly IWebElement _row;
        private readonly string _hotelName;
        private readonly WebDriverWait _wait;

        public BookingRow(IWebDriver driver, string hotelName)
        {
            _driver = driver;
            _hotelName = hotelName;
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 60));
        }

        private IWebElement Row
        {
            get
            {
                var row = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($".//b[text()='{_hotelName}']/ancestor::div[@class='row']")));
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", row);
                return row;
            }
        }

        private IWebElement WriteReviewButton
        {
            get { return _driver.FindElement(By.XPath(".//span[text()='Write Review ']")); }
        }

        private IWebElement InvoiceButton
        {
            get { return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//a[text()='Invoice']"))); }
        }

        public WriteReviewModalBlock OpenWriteReviewModal()
        {
            WriteReviewButton.Click();
            return new WriteReviewModalBlock(_driver);
        }

        public InvoicePage OpenInvoice()
        {
            InvoiceButton.Click();
            return new InvoicePage(_driver);
        }
    }
}
