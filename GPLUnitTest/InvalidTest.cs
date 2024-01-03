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
            commandParser.ParseCommand(command, null, false);
        }

        [Test]
        public void invalidParamTest()
        {
            String command = "circle x \n" +
                "moveto 100,100 \n" +
                "drawto 100,100,100";
            commandParser.ParseCommand(command, null, false);
        }

        [Test]
        public void invalidParamTest2()
        {
            String command = "circle 50 \n" +
                "moveto 100,100 \n" +
                "drawto 100,100,100";
            commandParser.ParseCommand(command, null, false);
        }

        
    }
}
