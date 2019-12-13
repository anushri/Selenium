using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumProject.ComponentHelper;
using SeleniumProject.PageObject;
using SeleniumProject.Settings;

namespace SeleniumProject.DataDriven.Scripts
{
    [TestClass]
    public class TestLogin_excel
    {
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestMethod]
        [DataSource("System.Data.Odbc", @"Dsn=Excel Files;dbq=C:\Users\anushri.mundada\source\repos\SeleniumProject\TestData\FlightSearch.xlsx;", "Search$", DataAccessMethod.Sequential)]
        public void TestBug()
        {

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePageusingFW hpage = new HomePageusingFW(ObjectRepository.Driver);
            LoginusingFW lpage = hpage.NavigatetoLoginpopup();
            var ePage = lpage.Login(ObjectRepository.Config.GetUserName(), ObjectRepository.Config.GetPassword());
            hpage.QuickSearch(TestContext.DataRow["Origin"].ToString(), TestContext.DataRow["Destination"].ToString());
            hpage.Logout();
        }
    }
}
