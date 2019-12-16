using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.DefaultWait
{
    [TestClass]
    public class DefaultWait
    {
        [TestMethod]
        public void TestDefaultWait()
        {
            
            //use the default wat on the webelement
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
          //  TextboxHelper.TypeInTextbox(By.XPath("//*[@id='fsc-destination-search']"), "OOsaka");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(ObjectRepository.Driver.FindElement(By.XPath("//*[@id='fsc-destination-search']")));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException),typeof(ElementNotVisibleException));
            Console.WriteLine("After wait :{0}",wait.Until(changeOfValue()));           


            //use the webdriver wait on the driver object
            GenericHelper.WaitforWebElement(By.XPath("//*[@id='fsc-destination-search']"),TimeSpan.FromMilliseconds(5000));
            IWebElement ele = GenericHelper.WaitforWebElementInPage(By.XPath("//*[@id='fsc-destination-search']"), TimeSpan.FromMilliseconds(5000));





        }

        private Func<IWebElement, string> changeOfValue()
        {
            return ((x) =>
            {
                Console.WriteLine("value chn");
                SelectElement select = new SelectElement(x);
                if (select.SelectedOption.Text.Equals("Osaka"))//this checks entered text by user is equalto osaka and the wait terminates
                    return select.SelectedOption.Text;
                return null;

            }
                
                
                );
        }
    }
}
