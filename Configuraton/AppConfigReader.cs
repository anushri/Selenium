using SeleniumProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumProject.Configuraton;
using System.Configuration;
using SeleniumProject.Settings;

namespace SeleniumProject.Configuraton
{
    //this class will impement Iconfig interface
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            //returns a strng hence typecasting
            string browser =   ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            
            //typcasting browser to ennum type 
            //we have written browsertpe in method declaration and also used typeof and wrote browsertpe after return statement as it returns an object
            return (BrowserType)Enum.Parse(typeof(BrowserType),browser);
        }

        public string GetPassword()
        {
            //Configuration manager helps us to read data(configuration) from the app config file/appsettings
            //returns a string
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.password);
        }

        public string GetUserName()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);
        }

        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Website);
        }

        public int GetElementLoadTimeOut()//implicit wait for elements
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (timeout == null)
                return 30;//default value if not provided n app  config
            return Convert.ToInt32(timeout);
        }

        public int GetPageLoadTimeOut()//explicit wait
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }
    }
}
