using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
    public class CheckboxHelper
    {

        private static IWebElement element;
        public static void CheckedCheckbox(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
        }


        public static bool IsCheckboxchecked(By locator)
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

                return flag.ToLowerInvariant().Equals("true") || flag.Equals("checked");

            }

        }
    }
}
