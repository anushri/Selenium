using OpenQA.Selenium;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
    
    public class ButtonHelper
    {
        private static IWebElement element;
        public static void ClickButton(By locator)
        {
            try
            {
                element = GenericHelper.GetElement(locator);
                element.Click();
            } catch(ElementNotVisibleException e)
            {
                System.Console.WriteLine("Couldn't find button at location: " + locator.ToString() + "\n\n" + e.ToString());
            }
        }

        public static bool IsButonEnabled(By locator)
        {
            element = GenericHelper.GetElement(locator);
            return element.Enabled;
        }

        public static string GetButtonText(By locator)
        {
            element = GenericHelper.GetElement(locator);
            //we are checking the html tag which has the value saved 
            if (element.GetAttribute("value") == null)
                return String.Empty;
            else
                return element.GetAttribute("value");
        }

        public static string GetButtonText_alt(By locator)
        {
            element = GenericHelper.GetElement(locator);
            //we are checking the html tag which has the value saved 
            if (element.Text == null)
                return String.Empty;
            else
                return element.Text;
        }
    }
}
