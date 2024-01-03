using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode.nUnitTests
{
    internal class ifStatementTest
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
            String command = "clear\r\n" +
                "a=50\r\n" +
                "if a<10\r\n" +
                "circle 80\r\n" +
                "rectangle 80,100\r\n" +
                "endif\r\n" +
                "pen red\r\n" +
                "circle 90";
            commandParser.ParseCommand(command, null, true);
        }
    }
}
