using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.CustomException
{
    class NoSuitableDriverFound : Exception
    {
        //create constr for userdefined class
        public NoSuitableDriverFound(string msg) : base(msg)
        {


        }

    }
}
