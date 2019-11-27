using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.Button
{
    [TestClass]
    public class TestButton
    {
        [TestMethod]
        public void Button()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.XPath("//*[@id='authentication-link' and @class='login']"));
            LinkHelper.ClickLink(By.XPath("//div[@class='Qk3sp3k23b-uqHOY6J1-E']"));
            TextboxHelper.TypeInTextbox(By.XPath("//*[@id='email']"), ObjectRepository.Config.GetUserName());
            TextboxHelper.TypeInTextbox(By.XPath("//*[@id='password']"), ObjectRepository.Config.GetPassword());
            //IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//*[@class='bpk-button-IZE-J ProgressionButton__button-3U-H6']"));
            //ele.Click();
            Console.WriteLine("Enabled : {0}", ButtonHelper.IsButonEnabled(By.XPath("//*[@class='bpk-button-IZE-J ProgressionButton__button-3U-H6']")));
            
            //Console.WriteLine("Label : {0}", ButtonHelper.GetButtonText(By.XPath("//*[@class='bpk-button-IZE-J ProgressionButton__button-3U-H6']")));
            
            ButtonHelper.ClickButton(By.XPath("//*[@class='bpk-button-IZE-J ProgressionButton__button-3U-H6']"));
          

        }

    }
}
