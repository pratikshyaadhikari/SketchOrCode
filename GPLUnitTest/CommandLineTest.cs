using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using SketchOrCode;
using System.Drawing;
using System.Windows.Forms;

namespace GPLUnitTest
{

    public class GPLUnitTest
    {

        CommandParser commandParser;

        [SetUp]
        public void Setup()
        {
            commandParser = new CommandParser(null);
            
        }

        [Test]
        public void clearCmdTest()
        {
            Mock<IGraphics> graphicMock = new Mock<IGraphics>();
            //mocking
            graphicMock.Setup(x => x.Clear(It.IsAny<Color>())).Callback<Color>(color =>
            {
                // Do nothing - empty action
            });

            String command = "clear";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void penCmdTest()
        {
            String command = "pen white";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void penWithCaseInsensativeCmdTest()
        {
            String command = "PEN black";
            commandParser.ParseCommand(command, null, true);
        }

        [Test]
        public void triangleCmdTest()
        {
            String command = "triangle 20,40";
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