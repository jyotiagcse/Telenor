using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Telenor.PageObject;

namespace Telenor
{
    class BroadBandHandla

    {
        IWebDriver driver;
        
        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void verifyBroadbandProductTestCase()
        {
            HomePage homePage = new HomePage(driver);

            Console.WriteLine("Step 1 Navigate to URL");
            homePage.goToPage(); 
            homePage.acceptCookie();

            Console.WriteLine("Step 2 Using the Handla menu, navigate to the broadband page");
            homePage.selectBroadband();

            BroadBandHandlaPage broadBandHandlaPage = new BroadBandHandlaPage(driver);

            Console.WriteLine("Step 3 search for address ");
            broadBandHandlaPage.searchAddress("Storgatan 1, Uppsala");

            Console.WriteLine("Step 4 select first apartment");
            broadBandHandlaPage.selectApartment();

            Console.WriteLine("Step 5 Verify that at least one product is displayed");
            broadBandHandlaPage.verifyProduct();

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
