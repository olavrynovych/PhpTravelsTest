using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PhpTravelsTest.Elements;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PhpTravelsTest.PageObject
{
    public class AccountPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public AccountPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new TimeSpan(0,0,50));
        }

        private IWebElement BookingsBlock
        {
            get { return _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("bookings"))); }
        }
        

        public WriteReviewModalBlock OpenWriteReviewForHotel(string byHotelName)
        {
            BookingsBlock.Click();
            var row = new BookingRow(_driver, byHotelName);
            return row.OpenWriteReviewModal();
        }

        public InvoicePage OpenInvoice(string byHotelName)
        {
            BookingsBlock.Click();
            var row = new BookingRow(_driver, byHotelName);
            return row.OpenInvoice();
        }
    }
}
