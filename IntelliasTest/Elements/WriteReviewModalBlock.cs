using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PhpTravelsTest.Models;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PhpTravelsTest.Elements
{
    public class WriteReviewModalBlock
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly IWebElement _modal;

        public WriteReviewModalBlock(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new TimeSpan(0,0,50));

            _modal = _wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//div[@class='modal fade in' and @style='display: block;']")));
        }

        private SelectElement CleanSelectElement
        {
            get
            {
                var el = _modal.FindElement(By.XPath(".//select[@name='reviews_clean']"));
                return new SelectElement(el);
            }
        }
       
        private SelectElement ComfortSelectElement
        {
            get
            {
                var el = _modal.FindElement(By.XPath(".//select[@name='reviews_comfort']"));
                return new SelectElement(el);
            }
        }
        private SelectElement LocationSelectElement
        {
            get
            {
                var el = _modal.FindElement(By.XPath(".//select[@name='reviews_location']"));
                return new SelectElement(el);
            }
        }
        private SelectElement FacilitiesSelectElement
        {
            get
            {
                var el = _modal.FindElement(By.XPath(".//select[@name='reviews_facilities']"));
                return new SelectElement(el);
            }
        }
        private SelectElement StaffSelectElement
        {
            get
            {
                var el = _modal.FindElement(By.XPath(".//select[@name='reviews_staff']"));
                return new SelectElement(el);
            }
        }

        private IWebElement ReviewsTextBlock
        {
            get { return _modal.FindElement(By.XPath(".//textarea[@name='reviews_comments']")); }
        }

        private IWebElement SubmitButton
        {
            get { return _modal.FindElement(By.XPath(".//button[@class='btn btn-primary addreview']")); }
        }

        public void WriteReview(ReviewModel review)
        {
            Thread.Sleep(5000);
            if(!string.IsNullOrEmpty(review.Clean))
                CleanSelectElement.SelectByValue(review.Clean);
            if (!string.IsNullOrEmpty(review.Comfort))
                ComfortSelectElement.SelectByText(review.Comfort);
            if (!string.IsNullOrEmpty(review.Location))
                LocationSelectElement.SelectByText(review.Location);
            if (!string.IsNullOrEmpty(review.Facilities))
                FacilitiesSelectElement.SelectByText(review.Facilities);
            if (!string.IsNullOrEmpty(review.Staff))
                StaffSelectElement.SelectByText(review.Staff);
            if (!string.IsNullOrEmpty(review.Reviews))
                ReviewsTextBlock.SendKeys(review.Reviews);

            SubmitButton.Click();
        }
    }
}
