using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode.nUnitTests
{
    internal class VariableTest
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
                "a= 80\r\n" +
                "circle a";
            commandParser.ParseCommand(command, null, true);
        }


        [Test]
        public void validCmdTest2()
        {
            String command = "a= 10\r\n" +
                "a= a*5\r\n" +
                "circle a";
            commandParser.ParseCommand(command, null, true);
        }
    }
}