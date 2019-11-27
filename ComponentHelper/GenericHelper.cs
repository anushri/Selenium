using OpenQA.Selenium;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
    public class GenericHelper
    {
        //to check whether element present, we need to supply the location startegy
        public static bool IsElementPresent(By Locator)
        {
            //returns true if element present (only unique element)
            try
            {
                return ObjectRepository.Driver.FindElements(Locator).Count == 1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static IWebElement GetElement(By Locator)
        {
            //returns element if present
            if (IsElementPresent(Locator))
            {
                return ObjectRepository.Driver.FindElement(Locator);

            }
            else
            {
                throw new NoSuchElementException("Element not found :" + Locator.ToString());
            }

        }


    }
}
