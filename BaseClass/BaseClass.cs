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
using SeleniumProject.ComponentHelper;

namespace SeleniumProject.BaseClass
{
    [TestClass]
    public class BaseClass
    {

        //private static IWebDriver GetFirefoxDriver()
        //{
        //    IWebDriver driver = new FirefoxDriver();
        //    return driver;

        //}

        //creating fiefox driver service; returns an instance of default service
        //we use this cresting s driver service as an alternative to adding athe driverpath in the system variable in my props and then adding the path to the path SV
        // if we are taking this approach then use the below otherwise we just need need to add the above commented code and add data to the SVs.
        private static FirefoxDriverService GetFirefoxDriverService()
        {
            var service = FirefoxDriverService.CreateDefaultService(@"C:\Drivers", "geckodriver.exe"); //returns an instance of FF driver service
            service.HideCommandPromptWindow = true;
            return service;
        }
        
        //creating the driver service

        private static FirefoxDriver GetFirefoxDriver()
        {
          
            var driver = new FirefoxDriver(GetFirefoxDriverService());
            return driver;
        }


        
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
            option.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
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

            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());//explicit wait for urls
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());//implicit wait for elements
            BrowserHelper.BroswerMaximise(); 
        }
        [AssemblyCleanup]
        public static void TearDown()
        {
            if(ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();//closes the browser currently pointed by the driver
                ObjectRepository.Driver.Quit();//closes all browser windows and stops the webbrowser
            }
        }
    }
}
