
using log4net.Appender;
using log4net.Core;
using log4net.Config;
using log4net.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SeleniumProject.ComponentHelper;

namespace SeleniumProject.L_TS.Log4Net
{
    [TestClass]
    public class TestLogin
    {
        [TestMethod]
        public void TestLog4Net()
        {

            //1.create layout --- creates format of the information
            //2.use this layout in appender --- gives th eoutput of the log
            //3.initialise the configuration
            //4.get the instance of the logger -- genertes the logging information

            //var patternLayout = new PatternLayout();
            //patternLayout.ConversionPattern = "%d{dd MMM yyyy HH:mm} - [%class] [%method] -[%level] - %L - %message - %rEx{short}  %newline";
            //patternLayout.ActivateOptions();//initiase the configuration

            //var consoleAppender = new ConsoleAppender()
            //{
            //    //properties from ConsoleAppender class
            //    Name = "ConsoleAppender",
            //    Layout = patternLayout,
            //    Threshold = Level.Error
            //};
            //consoleAppender.ActivateOptions();//first 2 steps done


            ////another type appender
            //var fileAppender = new FileAppender()
            //{

            //    Name = "fileAppender",
            //    Layout = patternLayout,
            //    Threshold = Level.All,
            //    AppendToFile = false,//ccreates fresh log entry
            //    File = "FileLogger.log"
            //};
            //fileAppender.ActivateOptions();//first 2 steps done

            ////which takes backup anoter appender
            //var rollingAppender = new RollingFileAppender()
            //{

            //    Name = "rollingAppender",
            //    Layout = patternLayout,
            //    Threshold = Level.All,
            //    AppendToFile = true,//ccreates fresh log entry
            //    MaximumFileSize ="1MB",
            //    MaxSizeRollBackups = 15,
            //    File = "rollingFile.log"
            //};
            //rollingAppender.ActivateOptions();//first 2 steps done


            ////intialise config
            //BasicConfigurator.Configure(consoleAppender, fileAppender,rollingAppender);


            ////step4
            //ILog Logger = LogManager.GetLogger(typeof(TestLogin));
            ILog Logger = Log4NetHelper.GetLogger(typeof(TestLogin));

            Logger.Debug("This is Debug Information");
            Logger.Info("This is Info Information");
            Logger.Warn("This is Warn Information");
            Logger.Error("This is Error Information");
            Logger.Fatal("This is Fatal Information");
            
        }

        [TestMethod]
        public void TestLog4Layout()
        {
            Log4NetHelper.Layout = "%message%newline";
            ILog Logger = Log4NetHelper.GetLogger(typeof(TestLogin));

            Logger.Debug("This is Debug Information");
            Logger.Info("This is Info Information");
            Logger.Warn("This is Warn Information");
            Logger.Error("This is Error Information");
            Logger.Fatal("This is Fatal Information");

        }


        [TestMethod]

        public void TestLog4XMLLoggerAppConfig()
        {
            //Log4NetHelper.Layout = "%message%newline";
            ILog Logger = Log4NetHelper.GetXmlLogger(typeof(TestLogin));

            Logger.Debug("This is Debug Information");
            Logger.Info("This is Info Information");
            Logger.Warn("This is Warn Information");
            Logger.Error("This is Error Information");
            Logger.Fatal("This is Fatal Information");

        }



    }
}


