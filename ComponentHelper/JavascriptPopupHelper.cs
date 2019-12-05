using OpenQA.Selenium;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
   public class JavascriptPopupHelper
    {
        public static bool IsPopUpPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {

                return false;
            }
        }

        public static string GetPopupText()
        {
            if (!IsPopUpPresent())//popup not present
            {
                return "";

            }
            return ObjectRepository.Driver.SwitchTo().Alert().Text;

        }

        public static void ClickOKOnPopup()
        {
            if (IsPopUpPresent())//popup  present
            {
                ObjectRepository.Driver.SwitchTo().Alert().Accept();

            }
            return;

        }


        public static void ClickCancelPopup()
        {
            if (IsPopUpPresent())//popup  present
            {
                ObjectRepository.Driver.SwitchTo().Alert().Dismiss();

            }
            return;

        }

        public static void SendKeys(string text)
        {
            if (IsPopUpPresent())//popup  present
            {
                ObjectRepository.Driver.SwitchTo().Alert().SendKeys(text);

            }
            return;

        }
    }
}
