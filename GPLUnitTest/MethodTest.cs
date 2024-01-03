using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode.nUnitTests
{
    internal class MethodTest
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
            String command = "method test\r\n " +
                "circle 90\r\n  " +
                "rectangle 90,10\r\n" +
                "endmethod\r\n" +
                "\n"+
                "clear\r\n" +
                "call test";
            commandParser.ParseCommand(command, null, true);
        }
    }
}
