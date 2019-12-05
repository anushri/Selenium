using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.Screenshots
{
    [TestClass]
   public class TakeScreenshots
    {
        [TestMethod]
        public void Screenshot()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.XPath("//*[@id='authentication-link' and @class='login']"));
            LinkHelper.ClickLink(By.XPath("//div[@class='Qk3sp3k23b-uqHOY6J1-E']"));
            //the method takescreenshot returns an object of type screendhot class
            //Screenshot screen = ObjectRepository.Driver.TakeScreenshot();
            //screen.SaveAsFile("screen.jpeg", ScreenshotImageFormat.Jpeg);
            GenericHelper.TakeScreenshot();
            GenericHelper.TakeScreenshot("Test.Jpeg");


        }
    }
}
