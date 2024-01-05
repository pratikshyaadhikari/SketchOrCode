using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode.nUnitTests
{
    internal class MultilineTest
    {
        CommandParser commandParser;

        [SetUp]
        public void Setup()
        {
            commandParser = new CommandParser(null);

        }

        [Test]
        public void validCmdTest()
        {
            String command = "clear\n" +
                "pen white\n" +
                "fill on\n" +
                "rectangle 90,40\n" +
                "circle 80";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void invalidCmdTest()
        {
            String command = "clear\n" +
                "pen white\n" +
                "fill on\n" +
                "rectangl 90,40\n" +
                "circle 80";
           ;

            var ex = Assert.Throws<SketchApplicationException>(() => commandParser.ParseCommand(command, null, true));
            // Assert specific details about the exception if needed
            Assert.AreEqual("rectangl command error. Error occur at Line 4.", ex.Message);
        }


    }
}
