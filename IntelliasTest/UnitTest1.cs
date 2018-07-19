using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PhpTravelsTest.Elements;
using PhpTravelsTest.Models;

namespace PhpTravelsTest
{
    [TestFixture]
    public class Test1
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTest()
        {
        }
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }

        [Test]
        public void Scenario1()
        {
            using (var driver = new ChromeDriver()) 
            {
                var url = "https://www.phptravels.net";
                var username = "user@phptravels.com";
                var password = "demouser";
                var hotel = "Hurghada Sunset Desert Safari";
                var review = new ReviewModel() { Clean = "10",Staff = "2",Reviews = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." };

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);

                var toolbar = new ToobarElement(driver);
                var loginPage = toolbar.GoToLoginPage();
                var accPage = loginPage.Login(username, password);
                var reviewModal = accPage.OpenWriteReviewForHotel(hotel);
                reviewModal.WriteReview(review);
                var invoicePage = accPage.OpenInvoice(hotel);
                var tableValues = invoicePage.GetValuesFromTable();

                Assert.AreEqual("USD $20.90", tableValues.DepositNow);
                Assert.AreEqual("USD $19", tableValues.TaxAndVat);
                Assert.AreEqual("USD $209", tableValues.DepositNow);
            }
        }
    }
}
