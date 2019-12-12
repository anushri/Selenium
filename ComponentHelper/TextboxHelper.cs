using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
    public class TextboxHelper
    {

        private static IWebElement element;
        public static void TypeInTextbox(By locator, string text)
        {
            element = GenericHelper.GetElement(locator);
            element.SendKeys(text);
        }


        public static void ClearTextBody(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Clear();
        }

        public static void ClearTextBody(IWebElement element)
        {
           // element = GenericHelper.GetElement(locator);
            element.Clear();
        }


    }
}
