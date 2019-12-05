using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.Popup
{
    [TestClass]
    public class Popups
    {
        [TestMethod]
        public void TestAlert()
        {
            //giving error in cleartextpart
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.CssSelector("#main>div:nth-of-type(4)>a"));
            BrowserHelper.SwitchToWindow(1);
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.CssSelector("#iframeResult")));//switches to frame
            ButtonHelper.ClickButton(By.CssSelector("button[onclick = 'myFunction()']"));
            IAlert alert = ObjectRepository.Driver.SwitchTo().Alert();
            var text = alert.Text;
            alert.Accept();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            TextboxHelper.ClearTextBody(By.Id("textareaCode"));
            TextboxHelper.TypeInTextbox(By.CssSelector("#textareaCode"),text);

        }

        [TestMethod]
        public void TestAlert_using_Helper()
        {

            //clearbody doesnt work

            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.CssSelector("#main>div:nth-of-type(4)>a"));
            BrowserHelper.SwitchToWindow(1);
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.CssSelector("#iframeResult")));//switches to frame
            ButtonHelper.ClickButton(By.CssSelector("button[onclick = 'myFunction()']"));
            var text = JavascriptPopupHelper.GetPopupText();
            JavascriptPopupHelper.ClickOKOnPopup();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            // TextboxHelper.ClearTextBody(By.XPath("//*[@id='textareawrapper']/div/div[6]/div[1]/div/div/div/div[5]"));
            //TextboxHelper.ClearTextBody(By.Id("textareacontainer"));
            // TextboxHelper.ClearTextBody(By.XPath("//*[@id='textareawrapper']/div/div[6]/div[1]/div/div/div"));
            //TextboxHelper.ClearTextBody(By.XPath("//*[@id='textareawrapper']/div/div[1]"));
            // TextboxHelper.ClearTextBody(By.XPath("//*[@id='textareawrapper']/div/div[6]/div[1]/div/div"));
            Thread.Sleep(200);
            //TextboxHelper.ClearTextBody(By.XPath("//*[@id='textareawrapper']/div/div[6]/div[1]"));
            TextboxHelper.ClearTextBody(By.ClassName("CodeMirror-lines"));
            TextboxHelper.TypeInTextbox(By.CssSelector("#textareaCode"), text);

        }

        [TestMethod]
        public void TestAlert_confirm()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm");
            
            BrowserHelper.SwitchToFrame(By.CssSelector("#iframeResult"));
            ButtonHelper.ClickButton(By.CssSelector("button[onclick = 'myFunction()']"));
            //IAlert confirm = ObjectRepository.Driver.SwitchTo().Alert();
            //confirm.Accept();
            var text = JavascriptPopupHelper.GetPopupText();
            JavascriptPopupHelper.ClickOKOnPopup();
            ButtonHelper.ClickButton(By.CssSelector("button[onclick = 'myFunction()']"));
          //  confirm = ObjectRepository.Driver.SwitchTo().Alert();
            //confirm.Dismiss();
            JavascriptPopupHelper.ClickCancelPopup();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
         //   ButtonHelper.ClickButton(By.XPath("/html/body/div[5]/div/a[5]"));
            ButtonHelper.ClickButton(By.CssSelector("a#menuButton"));



        }

        [TestMethod]
        public void TestPrompt()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_prompt");
            BrowserHelper.SwitchToFrame(By.CssSelector("#iframeResult"));
            Thread.Sleep(200);
            ButtonHelper.ClickButton(By.CssSelector("button[onclick = 'myFunction()']"));
            
            IAlert prompt = ObjectRepository.Driver.SwitchTo().Alert();
            prompt.SendKeys("automation");
            prompt.Accept();

            //otherway using helper class
            ButtonHelper.ClickButton(By.CssSelector("button[onclick = 'myFunction()']"));
            Thread.Sleep(200);
            //prompt = ObjectRepository.Driver.SwitchTo().Alert();
            //prompt.SendKeys("automation");
            JavascriptPopupHelper.SendKeys("Automation");
            JavascriptPopupHelper.ClickCancelPopup();


        }

    }
}
