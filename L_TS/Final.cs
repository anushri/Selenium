using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts
{
    [TestClass]
    public class Final
    {
        [TestMethod]
        public void Final_()
        {
            //explicit wait for page loads
            //it sets the page load time to the specified amount in the app config, if the system takes less time then its ok otherwise it throws an error
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
            //implicit wait for elements
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            //supply initial string step 1
            IWebElement destination = ObjectRepository.Driver.FindElement(By.CssSelector("input#fsc-destination-search"));
            destination.SendKeys("O");
            Thread.Sleep(10000);//gets sufficient time to get visible
            //step 2 wait fro autosuggest list
            //using dynamic wait
            var wait = GenericHelper.GetWebdriverWait(TimeSpan.FromSeconds(44));
            //wait logic ; returns a list of Iwebelements cz inside auto suggest we have more than 1 element.
            IList<IWebElement> destinations = wait.Until(GetAllElement(By.XPath("//div[@id='react-autowhatever-fsc-destination-search']/ul[@role='listbox']/child::li")));
            foreach (var item in destinations)
            {
                if (item.Text.Equals("Osaka (Any)"))
                {
                    item.Click();

                }

            }

            ButtonHelper.ClickButton(By.XPath("//*[@id='flights-search-controls-root']/div/div/form/div[3]/button"));
            wait.Until(waitElement(By.XPath("//*[@id='app-root']/div[2]/div[2]/div[1]/div[2]")));
            Console.WriteLine("Best price is : {0}", ButtonHelper.GetButtonText_alt(By.XPath("//*[@id='app-root']/div[2]/div[2]/div[1]/div[2]/button[1]/div/div/span")));


        }


        //wait logic ; returns a list of Iwebelements cz inside auto suggest we have more than 1 element.
        private Func<IWebDriver, IList<IWebElement>> GetAllElement(By locator)
        {
            //using annonymous func
            return ((x) =>
            {
                return x.FindElements(locator);
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

    }
}
