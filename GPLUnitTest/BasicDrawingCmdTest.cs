using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode.nUnitTests
{
    internal class BasicDrawingCmdTest
    {
        CommandParser commandParser;

        [SetUp]
        public void Setup()
        {
            commandParser = new CommandParser(null);

        }

        [Test]
        public void moveToCmdTest()
        {
            String command = "moveto 30,60";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void drawtoCmdTest()
        {
            String command = "drawto 40,20";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void clearCmdTest()
        {
            String command = "clear";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void resetCmdTest()
        {
            String command = "reset";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void rectangleCmdTest()
        {
            String command = "rectangle 50,80";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void circleCmdTest()
        {
            String command = "circle 50";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void triangleCmdTest()
        {
            String command = "triangle 50,80";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void colorCmdTest()
        {
            String command = "pen blue";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void fillOnCmdTest()
        {
            String command = "fill on";
            commandParser.ParseCommand(command, null, true);
        }


        [Test]
        public void fillOffCmdTest()
        {
            String command = "fill off";
            commandParser.ParseCommand(command, null, true);
        }
    }
}
