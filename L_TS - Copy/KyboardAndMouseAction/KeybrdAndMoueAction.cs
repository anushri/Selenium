using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumProject.ComponentHelper;
using SeleniumProject.ComponentHelper.JavaScriptExecutor;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.Mousection
{

    [TestClass]
    public class KeybrdAndMoueAction
    {

        [TestMethod]
        public void TestContextClick()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement ele = ObjectRepository.Driver.FindElement(By.CssSelector("#draggable"));

            // act.ContextClick(ele);
            //IAction iact =  act.Build();
            // iact.Perform();

            //short hand for the above 3 lines as below
            act.ContextClick(ele)//rightclick of mouse
                .Build()
                .Perform();
            Thread.Sleep(3333);

        }

        [TestMethod]
        public void TestDragnDrop()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement src = ObjectRepository.Driver.FindElement(By.CssSelector("#draggable"));
            IWebElement tgt = ObjectRepository.Driver.FindElement(By.CssSelector("#droptarget"));
            act.DragAndDrop(src, tgt)
                .Build()
                .Perform();

            Thread.Sleep(333);

        }

        [TestMethod]
        public void TestClicknHold()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/sortable/index");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement src = ObjectRepository.Driver.FindElement(By.CssSelector("ul#sortable-basic > li:nth-of-type(12)"));
            IWebElement tgt = ObjectRepository.Driver.FindElement(By.CssSelector("ul#sortable-basic > li:nth-of-type(1)"));
            act.ClickAndHold(src)
                .MoveToElement(tgt)
                .Build()
                .Perform();
            Thread.Sleep(12211);
        }


        [TestMethod]
        public void TestClicknRelease()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/sortable/index");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement src = ObjectRepository.Driver.FindElement(By.CssSelector("ul#sortable-basic > li:nth-of-type(12)"));
            IWebElement tgt = ObjectRepository.Driver.FindElement(By.CssSelector("ul#sortable-basic > li:nth-of-type(1)"));
            act.ClickAndHold(src)
                .MoveToElement(tgt,0,30)
                .Release()
                .Build()
                .Perform();
            Thread.Sleep(1221);

            act.ClickAndHold(tgt)
                .MoveToElement(src, 0, 30)
                .Release()
                .Build()
                .Perform();
        }

        //scrolling
        [TestMethod]
        public void scrolling()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
       //     IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);

            IWebElement element = ObjectRepository.Driver.FindElement(By.CssSelector("a#countries"));
            JavaScriptExecutor.ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            element.Click();

        }
        [TestMethod]
        public void TestKeyBoard()
        {
            //compose action then call build method and lastly perform it
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Actions act = new Actions(ObjectRepository.Driver);
            //act.KeyDown(Keys.LeftControl) //control + T addns a new tab to browser; you can check the keys class for other controls 
            //    .SendKeys("O")
            //    .Build()
            //    .Perform();


            //opens add on mnager
            //act.KeyDown(Keys.LeftControl) //control + T addns a new tab to browser; you can check the keys class for other controls 
            //    .KeyDown(Keys.LeftShift)
            //    .SendKeys("a")
            //    .KeyUp(Keys.LeftShift)//release key
            //    .KeyUp(Keys.LeftControl)
            //    .Build()
            //    .Perform();

            IWebElement origin  = ObjectRepository.Driver.FindElement(By.CssSelector("input#fsc-origin-search"));
            IWebElement destination = ObjectRepository.Driver.FindElement(By.CssSelector("input#fsc-destination-search"));
            origin.SendKeys("OS");
            act.KeyDown(destination, Keys.LeftShift)
                .SendKeys(destination, "bris")
                .KeyUp(destination, Keys.LeftShift)
                .Build()
                .Perform();
            Thread.Sleep(2222);

        }
    }

}