using OpenQA.Selenium;
using SeleniumProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Settings
{
    //contains objects and propertoes which can be used by other classes and framweork
    //making public so all can use and static as well to access this easily using the classname.
    public static class ObjectRepository
    {
        // we need property of IConfig to read the data from config file
        public static IConfig Config { get; set; }

        // we need property of Iwebdriver to launch the browseras the appconfig(configuration) selection
        public static IWebDriver Driver { get; set; }

    }
}
  