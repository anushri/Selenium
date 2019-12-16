using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;

namespace SeleniumProject.L_TS
{
    [TestClass]
   public class Class1
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

       // Actions act = new Actions(ObjectRepository.Driver);

        //[SetUp]
        //public void SetUp()
        //{
        //    driver = new ChromeDriver();
        //    js = (IJavaScriptExecutor)driver;
        //    vars = new Dictionary<string, object>();
        //}
        //[TearDown]
        //protected void TearDown()
        //{
        //    driver.Quit();
        //}
        [TestMethod]
        public void wlll()
        {

           
            // Test name: wlll
            // Step # | name | target | value | comment
            // 1 | open | /login?returnUrl=%2F |  | 
            NavigationHelper.NavigateToUrl("http://support.charmhealth.com.au:492/login?returnUrl=%2F");
            // 2 | setWindowSize | 1720x934 |  | 
            // driver.Manage().Window.Size = new System.Drawing.Size(1720, 934);
            // 3 | click | css=.form-group:nth-child(1) > .form-control |  | 
            ButtonHelper.ClickButton(By.CssSelector(".form-group:nth-child(1) > .form-control"));
            // 4 | type | css=.ng-valid | chadmin | 
            TextboxHelper.TypeInTextbox(By.CssSelector(".ng-valid"),"chadmin");
            // 5 | type | css=.ng-untouched | j06 | 
            TextboxHelper.TypeInTextbox(By.CssSelector(".ng-untouched"),"j06");
            // 6 | click | css=.btn-outline-primary |  | 
            ButtonHelper.ClickButton(By.CssSelector(".btn-outline-primary"));
            // 7 | click | name=search |  | 
            ButtonHelper.ClickButton(By.Name("search"));
            // 8 | type | name=search | smith | 
            TextboxHelper.TypeInTextbox(By.Name("search"),"smith");
            // 9 | click | css=.iconic-magnifying-glass |  | 
            ButtonHelper.ClickButton(By.CssSelector(".iconic-magnifying-glass"));
            // 10 | click | css=.ng-star-inserted:nth-child(1) > .ng-star-inserted > .inline .ng-star-inserted:nth-child(2) > .ng-star-inserted |  | 
            ButtonHelper.ClickButton(By.CssSelector(".ng-star-inserted:nth-child(1) > .ng-star-inserted > .inline .ng-star-inserted:nth-child(2) > .ng-star-inserted"));
            // 11 | click | css=.active .ng-star-inserted:nth-child(2) > .ng-star-inserted |  | 
            ButtonHelper.ClickButton(By.CssSelector(".active .ng-star-inserted:nth-child(2) > .ng-star-inserted"));
            // 12 | click | css=.col-3 > .form-control-plaintext |  | 
            ButtonHelper.ClickButton(By.CssSelector(".col-3 > .form-control-plaintext"));
            // 13 | mouseOver | css=#bannerBtnLv1MedLists > .iconic-list |  | 
            {
                var element = driver.FindElement(By.CssSelector("#bannerBtnLv1MedLists > .iconic-list"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            // 14 | mouseOut | css=#bannerBtnLv1MedLists > .iconic-list |  | 
            {
                var element = ObjectRepository.Driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            // 15 | mouseOver | id=bannerBtnLv1MedLists |  | 
            {
                var element = ObjectRepository.Driver.FindElement(By.Id("bannerBtnLv1MedLists"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            // 16 | mouseOut | id=bannerBtnLv1MedLists |  | 
            {
                var element = ObjectRepository.Driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            // 17 | click | name=search |  | 
            ButtonHelper.ClickButton(By.Name("search"));
            // 18 | type | name=search | smith | 
            TextboxHelper.TypeInTextbox(By.Name("search"),"smith");
            // 19 | click | css=.btn-primary:nth-child(4) |  | 
            ButtonHelper.ClickButton(By.CssSelector(".btn-primary:nth-child(4)"));
            // 20 | click | css=.list-group-item:nth-child(1) .list-view-pf-main-info:nth-child(3) |  | 
            ButtonHelper.ClickButton(By.CssSelector(".list-group-item:nth-child(1) .list-view-pf-main-info:nth-child(3)"));
            // 21 | click | css=.iconic-people |  | 
            ButtonHelper.ClickButton(By.CssSelector(".iconic-people"));
            // 22 | click | css=.list-group-item:nth-child(2) .flex-1 |  | 
            ButtonHelper.ClickButton(By.CssSelector(".list-group-item:nth-child(2) .flex-1"));
            // 23 | click | css=.navbar-brand > .ng-tns-c1-0 |  | 
            ButtonHelper.ClickButton(By.CssSelector(".navbar-brand > .ng-tns-c1-0"));
            // 24 | click | css=.navbar-brand > .ng-tns-c1-0 |  | 
            ButtonHelper.ClickButton(By.CssSelector(".navbar-brand > .ng-tns-c1-0"));
            // 25 | click | css=.iconic-home |  | 
            ButtonHelper.ClickButton(By.CssSelector(".iconic-home"));
            // 26 | click | css=.iconic-share |  | 
            ButtonHelper.ClickButton(By.CssSelector(".iconic-share"));
            // 27 | click | name=search |  | 
            ButtonHelper.ClickButton(By.Name("search"));
            // 28 | type | name=search | smith | 
            TextboxHelper.TypeInTextbox(By.Name("search"),"smith");
            // 29 | sendKeys | name=search | ${KEY_ENTER} | 
            TextboxHelper.TypeInTextbox(By.Name("search"),Keys.Enter);
            // 30 | close |  |  | 
           }
    }

}

