using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
    public class RadioButtonHelper
    {
        private static IWebElement element;

        public static void ClickRadioButton(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();

        }

        public static bool IsRadioButtonchecked(By locator)
        {
            element = GenericHelper.GetElement(locator);
            //here you give the attritube from the elemets desc by inspecting which tell syouthe value
            string flag = element.GetAttribute("checked");

            if (flag == null)
            {
                return false;
            }
            else
            {
                return flag.Equals("true") || flag.Equals("checked");

            }

        }


        public static string GetRadioButtonText(By locator)
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
