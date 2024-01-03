using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode.nUnitTests
{
    internal class LoopTest
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
                "a= 0\r\n" +
                "while a<500\r\n   " +
                "a= a+5\r\n " +
                "circle a\r\n" +
                "endwhile";
            commandParser.ParseCommand(command, null, true);
        }

    }
}
