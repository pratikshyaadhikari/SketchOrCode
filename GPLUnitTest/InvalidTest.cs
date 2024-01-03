using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode.nUnitTests
{
    internal class InvalidTest
    {
        CommandParser commandParser;

        [SetUp]
        public void Setup()
        {
            commandParser = new CommandParser(null);

        }

        [Test]
        public void invalidCmdTest()
        {
            String command = "invalidCmd";
            var ex = Assert.Throws<SketchApplicationException>(() => commandParser.ParseCommand(command, null, true));
            // Assert specific details about the exception if needed
            Assert.AreEqual("invalidcmd command error. Error occur at Line 1.", ex.Message);
            commandParser.ParseCommand(command, null, false);
        }

        [Test]
        public void invalidParamTest()
        {
            String command = "circle x \n" +
                "moveto 100,100 \n" +
                "drawto 100,100,100";
            var ex = Assert.Throws<SketchApplicationException>(() => commandParser.ParseCommand(command, null, true));
            // Assert specific details about the exception if needed
            Assert.AreEqual("Circle param value is not a number.. Error occur at Line 1.", ex.Message);
        }

        [Test]
        public void invalidParamTest2()
        {
            String command = "circle 50 \n" +
                "moveto 100,100 \n" +
                "drawto 100,100,100";
            var ex = Assert.Throws<SketchApplicationException>(() => commandParser.ParseCommand(command, null, true));
            // Assert specific details about the exception if needed
            Assert.AreEqual("Circle param value is not a number.. Error occur at Line 1.", ex.Message);
        }

        
    }
}
