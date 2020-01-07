using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
   public class ComboboxHelper
    {
        private static SelectElement select;
        
        public static void SelectElement(By locator, int index)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByIndex(index);
        }

        //the above method is overloaded to select the opion by providing the value
        public static void SelectElement(By locator, string visible_text)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByValue(visible_text);
        }

        public static void SelectElement(IWebElement element, string visibletext)
        {
            select = new SelectElement(element);
            select.SelectByValue(visibletext);
        }

        public static void SelectElement(IWebElement element, int index)
        {
            select = new SelectElement(element);
            select.SelectByIndex(index);
        }


        public static IList<string> GetAllItem(By locator)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            return select.Options.Select((x) => x.Text).ToList();
        }
    }
}
