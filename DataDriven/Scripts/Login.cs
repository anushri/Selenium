using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumProject.ComponentHelper;
using SeleniumProject.PageObject;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.DataDriven.Scripts
{
    [TestClass]
   public class Login
    {
        [TestMethod]
        public void TestLogin()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePageusingFW hpage = new HomePageusingFW(ObjectRepository.Driver);
            LoginusingFW lpage = hpage.NavigatetoLoginpopup();
            var ePage = lpage.Login(ObjectRepository.Config.GetUserName(), ObjectRepository.Config.GetPassword());
            hpage.QuickSearch("Chennai", "Brisbane");
            hpage.Logout();
            
        }
    }
}
