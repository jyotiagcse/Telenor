using Google.Apis.Admin.Directory.directory_v1.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telenor.PageObject
{
    class HomePage
    {
        private IWebDriver driver;

        private String btnCookie = "//button[@data-test='accept-cookies-button']" ;
        private String menuHandla = "//a[@data-test='Handla']";
        private String menuBroadband = "//a[@data-test='Handla bredband']";

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://www.telenor.se/");
        }

        public void acceptCookie()
        {
            IWebElement eleBtnCookie = driver.FindElement(By.XPath(btnCookie));
            if (eleBtnCookie.Displayed)
                eleBtnCookie.Click();
        }

        public void selectBroadband()
        {
            driver.FindElement(By.XPath(menuHandla)).Click();
            driver.FindElement(By.XPath(menuBroadband)).Click();
        }

    }
}
