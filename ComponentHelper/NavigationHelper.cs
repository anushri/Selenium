using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
    //has methods to handle different navigations
    public class NavigationHelper
    {
        public static void NavigateToUrl(string Url)
        {
            //Property gets initialised as soon as the base class gets called when the Driver gets initialsed in the base class.
            //INavigation is an interface
            //    INavigation page = ObjectRepository.Driver.Navigate();
            //    page.GoToUrl(ObjectRepository.Config.GetWebsite());
            ////the above can also be written as
            ObjectRepository.Driver.Navigate().GoToUrl(Url);

        }
    }
}
