using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode.nUnitTests
{
    internal class ProgramSaveAndReadTest
    {

        CommandParser commandParser;

        String command = "clear\n" +
               "pen white\n" +
               "fill on\n" +
               "rectangle 90,40\n" +
               "circle 80";

        String filesavepath = "C:\\Users\\prati\\OneDrive\\Desktop\\leeds beckett university\\2nd sem\\ASE\\sampleSaveProgram.txt";
        String filereadpath = "C:\\Users\\prati\\OneDrive\\Desktop\\leeds beckett university\\2nd sem\\ASE\\sampleReadProgram.txt";

        [SetUp]
        public void Setup()
        {
            commandParser = new CommandParser(null);

        }

        [Test]
        public void saveFileTest()
        {
            
            commandParser.SaveFile(filesavepath, command);
        }


        [Test]
        public void readFileTest()
        {

           String savedCmd = commandParser.ReadFile(filereadpath);
            savedCmd= savedCmd.Replace("\r", "");
            Assert.AreEqual(command, savedCmd);
        }

    }
}
