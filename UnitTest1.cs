using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.Configuraton;
using SeleniumProject.Interfaces;

namespace SeleniumProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //Configuration manager helps us to read data(configuration) from the app config file
            //Console.WriteLine(ConfigurationManager.AppSettings.Get("Browser"));
            //Console.WriteLine(ConfigurationManager.AppSettings.Get("Username"));
            //Console.WriteLine(ConfigurationManager.AppSettings.Get("Password"));

            //gives the constant value of the entity present inside the enum
            //Console.WriteLine((int)BrowserType.Chrome);
            //Console.WriteLine((int)BrowserType.Firefox);
            //Console.WriteLine((int)BrowserType.IExplorer);

            //creating a ref var config of the interface which is pointing to the derived class obj
            //we can use the asme var to read data from other file for ex. f we read from xml file we can point to the xml reader 
            //file which will be similar to the appconfigreader
            //IConfig config = new AppConfigReader();
            //Console.WriteLine("Browser:{0}", config.GetBrowser());
            //Console.WriteLine("Username:{0}", config.GetUserName());
            //Console.WriteLine("Password :{0}", config.GetPassword());

            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://google.com");
            //driver.Close();
            //driver.Quit();

            Console.WriteLine("Test");
                

        }
    }
}

//Interface --common methods required for framework;
//currenltly we are having data in app config but we may also have dat in csv/xml file in that case
//all class which are reading data from the files are laid n the interfaces.