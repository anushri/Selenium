using OpenQA.Selenium;
using SeleniumProject.Settings;
using System;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumProject.BaseClass;

namespace SeleniumProject.PageObject
{

    //mapping class for homepage
    public class HomePageusingFW :PageBase
    {
        //inorder to intilise these elemenst we need to call methos-- init elements
        #region Webelement

        private IWebDriver driver;

        [FindsBy(How = How.Id,Using = "fsc-origin-search")]
        private IWebElement Origin;

        [FindsBy(How = How.Id, Using = "fsc-destination-search")]
        private IWebElement Destination;

        [FindsBy(How = How.XPath, Using = "//*[@id='flights-search-controls-root']/div/div/form/div[3]/button")]
        private IWebElement SearchButton;

        [FindsBy(How = How.LinkText, Using = "Map")]
        private IWebElement MapLink;



        [FindsBy(How = How.CssSelector, Using = "span#authentication-link")]
        private IWebElement Login_homepage;

        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(3) > .Qk3sp3k23b-uqHOY6J1-E")]
        private IWebElement envelope_login;

        #endregion

        public HomePageusingFW(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;//initialsing driver of current class wit the arguement supplied; this keywork points to current class i.e points to method n vars also in this classB
        }

        #region Action

        public void QuickSearch(string origin=null, string destination=null)
        {
            if (origin != null)
                Origin.SendKeys(origin);

            if (destination != null)
                Destination.SendKeys(destination);
            
            SearchButton.Click();
        }

        public new HomePageusingFW Logout()
        {
            base.Logout();
            return new HomePageusingFW(driver);
        }
        #endregion

        #region Navigation



        public LoginusingFW NavigatetoLoginpopup()
        {

            Login_homepage.Click();
            envelope_login.Click();
            return new LoginusingFW(driver); //the navigate to map takes us to the mappage i.e it returns a type of object of the mappage

        }
        #endregion
    }
}
