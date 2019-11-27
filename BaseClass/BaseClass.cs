using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumProject.Settings;
using SeleniumProject.Configuraton;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumProject.CustomException;

namespace SeleniumProject.BaseClass
{
    [TestClass]
    public class BaseClass
    {
        //returns the obj of chromeoption
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            return option;
        }

        private static InternetExplorerOptions GetInternetExplorerOptions()
        {
            InternetExplorerOptions option = new InternetExplorerOptions();
            option.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            option.EnsureCleanSession = true;
            return option;
        }

        //launching the browser which we specified in app.comfig file
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(GetInternetExplorerOptions());
            return driver;

        }

        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;

        }

        //runs first
        [AssemblyInitialize]
        public static void InitWebDriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();

            switch(ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;

                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;

                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    break;

                default:
                    throw new NoSuitableDriverFound("Driver not found  : "+ ObjectRepository.Config.GetBrowser().ToString());



            }
        }
        [AssemblyCleanup]
        public static void TearDown()
        {
            if(ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
