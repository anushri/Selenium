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

namespace SeleniumProject.TestScripts.AutoSuggest
{
    [TestClass]
    public class TestAutoSuggest
    {
        [TestMethod]
        public void TestAutoSuggest_()
        {
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
    }
}
