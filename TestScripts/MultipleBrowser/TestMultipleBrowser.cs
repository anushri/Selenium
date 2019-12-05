using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.MultipleBrowser
{
    [TestClass]
    public class TestMultipleBrowser
    {
        [TestMethod]
        public void TestMultipleBrowserWindow()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.CssSelector("#main>div:nth-of-type(4)>a"));
            //readonly collection of string which are window ids
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;
            //switching to child browser window [0]- parenst, [1]- child
            ObjectRepository.Driver.SwitchTo().Window(windows[1]);
            ButtonHelper.ClickButton(By.XPath("//div[@class='w3-bar']/descendant::button"));
            
        
        
        }

        [TestMethod]
        public void TestMultipleBrowserWindow_multipleswitches()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.CssSelector("#main>div:nth-of-type(4)>a"));
            //readonly collection of string which are window ids
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;
            //switching to child browser window [0]- parenst, [1]- child
            ObjectRepository.Driver.SwitchTo().Window(windows[1]);
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.CssSelector("#main>div:nth-of-type(4)>a"));
            //readonly collection of string which are window ids
            windows = ObjectRepository.Driver.WindowHandles;
            //[0]-parent;[1]-childd,parent after switching; [2]-child
            ObjectRepository.Driver.SwitchTo().Window(windows[2]);
            ButtonHelper.ClickButton(By.XPath("//div[@class='w3-bar']/descendant::button"));
            ObjectRepository.Driver.Close();//closes the current browser
            ObjectRepository.Driver.SwitchTo().Window(windows[1]);//good practice to switch back to parent in our case its at the 1 index as we have switched twice
            ObjectRepository.Driver.Quit();

        }


      
        [TestMethod]
        public void TestMultipleBrowserWindow_multipleswitches_using2componentclassmethods()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.CssSelector("#main>div:nth-of-type(4)>a"));
            BrowserHelper.SwitchToWindow(1);
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.CssSelector("#main>div:nth-of-type(4)>a"));
            BrowserHelper.SwitchToWindow(2);
            ButtonHelper.ClickButton(By.XPath("//div[@class='w3-bar']/descendant::button"));
            BrowserHelper.SwitchToParent();

        }

        [TestMethod]
        public void TestFrame()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.CssSelector("#main>div:nth-of-type(4)>a"));
            BrowserHelper.SwitchToWindow(1);
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.CssSelector("#iframeResult")));//switches to frame
            //    ButtonHelper.ClickButton(By.CssSelector("button:contains(^Try it$)"));
            ButtonHelper.ClickButton(By.CssSelector("button[onclick = 'myFunction()']"));
            ObjectRepository.Driver.SwitchTo().DefaultContent();//comes out of the frame context and we can work on the other eleements outside that frame.
        }

    }
}
