using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace SpecUnit
{
    class Class1
    {
        [Test]
        public void testMethod()
        {
            // start reporters
            var htmlReporter = new ExtentHtmlReporter("C:\\Users\\user\\source\\repos2\\SpecSolution\\TestResults\\");

            // create ExtentReports and attach reporter(s)
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            // creates a test 
            var test = extent.CreateTest("MyFirstTest", "Sample description");

            // log(Status, details)
            test.Log(Status.Info, "This step shows usage of log(status, details)");

            // info(details)
            test.Info("This step shows usage of info(details)");

            // log with snapshot
            //test.Fail("details",
            //    MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());

            // test with snapshot
            test.AddScreenCaptureFromPath("screenshot.png");

            // calling flush writes everything to the log file
            extent.Flush();
        }
    }
}
