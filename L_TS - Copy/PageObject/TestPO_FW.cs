using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using SeleniumProject.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumProject.BaseClass;

namespace SeleniumProject.TestScripts.PageObject
{
    [TestClass]

   public class TestPO_FW
    {
        [TestMethod]
        public void TestLogin()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePageusingFW homePage = new HomePageusingFW(ObjectRepository.Driver);
            LoginusingFW loginPage = homePage.NavigatetoLoginpopup();
            homePage = loginPage.Login(ObjectRepository.Config.GetUserName(), ObjectRepository.Config.GetPassword());
            homePage.QuickSearch("Sydney", "Tokyo");
         

        }

    }
}
