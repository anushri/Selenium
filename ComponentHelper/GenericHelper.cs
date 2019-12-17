using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Settings;
using SeleniumProject.CustomException;
using System;

namespace SeleniumProject.ComponentHelper
{
    public class GenericHelper
    {
        private static IWebElement element;
        //to check whether element present, we need to supply the location startegy
        public static bool IsElementPresent(By Locator)
        {
            //returns true if element present (only unique element)--- for page base


            try
            {
                return ObjectRepository.Driver.FindElements(Locator).Count == 1;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return false;
            }
        }


        public static IWebElement GetElement(By Locator)
        {


            try
            {

                IsElementPresent(Locator).Equals(true);
                return ObjectRepository.Driver.FindElement(Locator);

            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found :" + Locator.ToString() + e.StackTrace);
                throw new Exception(Locator.ToString());
            }

        }







        public static void TakeScreenshot(string filename = "Screen")
        {
            Screenshot screen = ObjectRepository.Driver.TakeScreenshot();

            if (filename.Equals("Screen"))//user hs not supplied the filename prefix
            {
                string name = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                return;
            }
            else
            {
                screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);

            }

        }


        //returns whether the element is visibe on page

        public static bool WaitforWebElement(By locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            bool flag = wait.Until(WaitForWebElementFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            return flag;
        }

        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;

            }

            );
        }

        //dynamic wait
        public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            //  Logger.Info(" Wait Object Created ");
            return wait;
        }


        //returns webelement
        public static IWebElement WaitforWebElementInPage(By locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            IWebElement flag = wait.Until(WaitForWebElementInPageFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            return flag;
        }

        internal static void WaitforWebElement(Func<IWebDriver, IWebElement> func, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {

            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;

            }

            );
        }

        public static void GetTextAndCompare(By locator, string data)
        {

            element = GenericHelper.GetElement(locator);

            Assert.AreEqual(data, element.Text, ignoreCase: true, "Match failed for  : " + locator);


        }

    }
}
