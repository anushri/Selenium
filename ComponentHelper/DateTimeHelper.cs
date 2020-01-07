using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.CustomException;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
    public class DateTimeHelper
    {

        private static IWebElement element;

        public static void DateCompare_ToToday(By locator)
        {

           
            try
            {
                element = GenericHelper.GetElement(locator);

                string from_sys = element.GetAttribute("value");

                DateTime today = DateTime.Now;

                string today_date = today.ToString("dd-MMM-yyyy");

                Assert.AreEqual(today_date, from_sys);
            }

            catch (Exception)
            {
                throw new NoMatchFound("\nComparison failed for locator: " + locator + "   is not displaying today's date");
            }

        }



         


    }
}
