using Google.Apis.Admin.Directory.directory_v1.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telenor.PageObject
{
    class BroadBandHandlaPage
    {
        private IWebDriver driver;

        private String strAddress = "Address";
        private String strApartment = "//select[@data-test='apartment-number-dropdown']";
        private String strProduct = "//div[@class='offers-address-search-result__access-types__access-type__products trailer']";
        private String strProductList = "//div[@class='offers-address-search-result-item-panel pill-container pill-container--leader offers-address-search-result-item']";
        private WebDriverWait wait;

        public BroadBandHandlaPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
        }


        public void searchAddress(String addToBeSearch)
        {
            IWebElement txtAddress = driver.FindElement(By.Id(strAddress));
            txtAddress.SendKeys(addToBeSearch);
            System.Threading.Thread.Sleep(2000);
            txtAddress.SendKeys(Keys.Enter);
        }

        public void selectApartment()
        {    
            wait.Until(driver => driver.FindElement(By.XPath(strApartment)));
            IWebElement eleApartment = driver.FindElement(By.XPath(strApartment));
            SelectElement selectApartment = new SelectElement(eleApartment);
            selectApartment.SelectByIndex(1);
        }

        public void verifyProduct()
        {
            wait.Until(driver => driver.FindElement(By.XPath(strProduct)));
            int productCount = driver.FindElements(By.XPath(strProductList)).Count();
            Assert.GreaterOrEqual(productCount, 1);
        }
    }
}
