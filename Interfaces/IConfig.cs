using SeleniumProject.Configuraton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Interfaces
{
    //initialsing frmework; this will have common methods which we will be using
    public interface IConfig
    {
        //here we get data from app config file or xml file
        //return type is enum hence used browsertpe
        BrowserType GetBrowser();
        //returntype is string
        string GetUserName();
        string GetPassword();
        string GetWebsite();
    }
}
