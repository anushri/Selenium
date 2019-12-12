using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.BaseClass
{
   public class PageBase
    {
        private IWebElement driver;

        [FindsBy (How = How.CssSelector,Using = "#identity")]
        private IWebElement HomeLink;
        public PageBase(IWebDriver _driver)
        {

            //this keyword points to the current class
            PageFactory.InitElements(_driver,this);

        }

        protected void NavigateToHomePage()//can be accessed only by inhertitance
        {
            HomeLink.Click();
        }



        protected void Logout()//can be accessed only by inhertitance
        {
            if (GenericHelper.IsElementPresent(By.CssSelector("span#authentication-link")))
                ButtonHelper.ClickButton(By.CssSelector("span#authentication-link"));
                    
            if (GenericHelper.IsElementPresent(By.CssSelector(".bpk-button--secondary-2tacU.bpk-button-2Gtiu"))) 
                ButtonHelper.ClickButton(By.CssSelector(".bpk-button--secondary-2tacU.bpk-button-2Gtiu"));

            if (GenericHelper.IsElementPresent(By.XPath("//*[@id='delete - dialog']/div/button[2]")))
                ButtonHelper.ClickButton(By.XPath("//*[@id='delete - dialog']/div/button[2]"));



        }
    }
}
