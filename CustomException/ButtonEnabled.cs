using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.CustomException
{
    public class ButtonEnabled : Exception
    {

        public ButtonEnabled(string msg) : base(msg)
        {//calls the base keyword to supply the msg to the superclass

        }
    }
}
