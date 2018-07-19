using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PhpTravelsTest.Elements;

namespace PhpTravelsTest.PageObject
{
    public class InvoicePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly IWebElement _invoicePage;
        public InvoicePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 50));
            var lastWindow = _driver.WindowHandles.Last(); //I think there is a better/smart way to switch :))
            _driver.SwitchTo().Window(lastWindow);
            _invoicePage = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='invoiceTable']")));
        }

        private IWebElement AmountTable
        {
            get { return _invoicePage.FindElement(By.XPath(".//table[@class='table table-bordered']")); }
        }

        public InvoiceAmountTableModel GetValuesFromTable()
        {
            var cells = AmountTable.FindElements(By.XPath(".//tbody/tr/td"));
            
            return new InvoiceAmountTableModel()
            {
                DepositNow = cells[0].Text, // could be implemented by finding value through finding index in header
                TaxAndVat = cells[1].Text,
                TotalAmount = cells[2].Text
            };
        }
    }
}
