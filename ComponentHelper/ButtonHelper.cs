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


        // to check if the button is disbaled if not throw an exception Button enabled 

        public static void GetButton_Disabled(By locator)
        {
            element = GenericHelper.GetElement(locator);
            try
            {
                if (element.Enabled == false) ;


            }

            catch (Exception)

            {
                throw new ButtonEnabled("Button Enabled  :  " + locator + "    Element Name: " + element.Text);
            }
        }

        public static bool IsButonEnabled(By locator)
        {
            element = GenericHelper.GetElement(locator);
            return element.Enabled;
        }



        public static void GetButton_Enabled(By locator)
        {
            element = GenericHelper.GetElement(locator);
       
      
            try
            {
                if (element.Enabled == true) ;
            }
            catch (Exception)
            {

                throw new ButtonNotEnabled("Button NotEnabled  :  " + locator + "    Element Name: " + element.Text);

            }

       
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
