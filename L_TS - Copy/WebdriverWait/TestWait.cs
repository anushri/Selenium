using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;


namespace SeleniumProject.TestScripts.WebdriverWait
{
    [TestClass]
    public class TestWait
    {
        [TestMethod]
        public void Test_Wait()
        {
            //explicit wait for page loads
            //it sets the page load time to the specified amount in the app config, if the system takes less time then its ok otherwise it throws an error
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
            //implicit wait for elements
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.XPath("//*[@id='authentication-link' and @class='login']"));
            LinkHelper.ClickLink(By.XPath("//div[@class='Qk3sp3k23b-uqHOY6J1-E']"));

        }


        [TestMethod]
        public void TestDynamciWait()
        {
            NavigationHelper.NavigateToUrl("https://www.skyscanner.com.au/");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));//after 50sec its going to throw timeout exception
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);//checks the wait logic for any exeptions
            //if we find these exceptions then script doesnt stop it just igores those and continues
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(waitforSearchbox());
            Console.WriteLine(wait.Until(waitforTitle()));
            IWebElement element = wait.Until(waitElement(By.XPath("//*[@id='fsc-destination-search']")));

            element.SendKeys("Osaka");
            ButtonHelper.ClickButton(By.XPath("//*[@id='flights-search-controls-root']/div/div/form/div[3]/button"));
            wait.Until(waitElement(By.XPath("//*[@id='app-root']/div[2]/div[2]/div[1]/div[2]")));
            Console.WriteLine("Best price is : {0}",ButtonHelper.GetButtonText_alt(By.XPath("//*[@id='app-root']/div[2]/div[2]/div[1]/div[2]/button[1]/div/div/span")));
            //wait.Until(waitforLastElemet()).Click();
            //Console.WriteLine("Title : {0}", wait.Until(waitforpageTitle()));
        }

        //acc -specifiers fun<input,out> { (x) => {}}
        //annonynous func whose input is iwebdrivere elemt and return type is bool.
        private Func<IWebDriver, bool> waitforSearchbox()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for text Box -- destination");
                //we are checking hw many webelemts r present with that xpath idealy should be 1 if more then duplicate elemets are present if less then elemet isnt there
                return x.FindElements(By.XPath("//*[@id='fsc-destination-search']")).Count == 1;
            });
        }

        //returns string
        private Func<IWebDriver, string> waitforTitle()
        {
            return ((x) =>
            {
                if (x.Title.Contains("Cheap"))
                    return x.Title;
                return null;
            });
        }

        //returns Iwebeement
        private Func<IWebDriver, IWebElement> waitforElement()
        {
            return ((x) =>
            {
                
                Console.WriteLine("Waiting for element");
                if (x.FindElements(By.XPath("//*[@id='fsc-destination-search']")).Count == 1)
                    return x.FindElement(By.XPath("//*[@id='fsc-destination-search']"));
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> waitElement(By locator)
        {
            return ((x) =>
            {

                Console.WriteLine("Waiting for element");
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }

        //private Func<IWebDriver, IWebElement> waitforLastElemet()
        //{
        //    return ((x) =>
        //    {
        //        Console.WriteLine("Waiting for Last Element");
        //        if (
        //            x.FindElements(
        //                By.XPath("//span[contains(text(),'These 5 Habits Will Help You Improve Your Health')]")).Count ==
        //            1)
        //            return
        //                x.FindElement(
        //                    By.XPath("//span[contains(text(),'These 5 Habits Will Help You Improve Your Health')]"));
        //        return null;
        //    });
        //}

        private Func<IWebDriver, string> waitforpageTitle()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Title");
                if (
                    x.FindElements(By.CssSelector(".course-title")).Count == 1)
                    return x.FindElement(By.CssSelector(".course-title")).Text;
                return null;
            });
        }

    }
}
