using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.BaseClass;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageObject
{
    public class LoginusingFW : PageBase //inherts from pge base; super class has parametised constr so its the job of child clas to provide tat arguement
    {
        public LoginusingFW(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;//initialsing driver of current class wit the arguement supplied; this keywork points to current class i.e points to method n vars also in this classB
        }

        #region WebElement

        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using ="input#email")]
        private IWebElement UID;

        [FindsBy(How = How.CssSelector, Using = "input#password")]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//button[@data-testid='login-button']")]
        private IWebElement btnLogin;


        #endregion
                
        #region Action

        public HomePageusingFW Login(string Uid, string Pwd)
        {

            UID.SendKeys(Uid);
            Password.SendKeys(Pwd);
            btnLogin.Click();
            return new HomePageusingFW(driver);
            
        }
        #endregion
    }
}
