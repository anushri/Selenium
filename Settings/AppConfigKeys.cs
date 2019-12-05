using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Settings
{
    public class AppConfigKeys
    {
        //use is if we chang ethe key in the app.config class we jsut have to change thevalue of teh same 
        //key in here and it will apply to whole project who are using the below keys for reading configuration
        //you cannot modify the value of the const during runtime and compile time

        public const string Browser = "BrowserSelect";
        public const string Username = "Username";
        public const string password = "password";
        public const string Website = "Website";
        public const string PageLoadTimeout = "PageLoadTimeout";
        public const string ElementLoadTimeout = "ElementLoadTimeout";
    }
}
