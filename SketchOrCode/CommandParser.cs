using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode
{
    public class CommandParser
    {
        private Graphics Graphics;
        private bool isFillOn = false;
        private Color color = Color.Black;
        private int xPos = 0;
        private int yPos = 0;

        public CommandParser(Graphics graphics)
        {
            this.Graphics = graphics;
        }

        public void ParseCommand(String singleLineCodeVal, String multipleLineCodeVal, Boolean isSyntaxCheckOnly)

        {

            String command = singleLineCodeVal;
            //check command to run
            if (String.IsNullOrEmpty(singleLineCodeVal))
            {
                if (String.IsNullOrEmpty(multipleLineCodeVal))
                {
                    throw new SketchApplicationException("no command pass");
                }
                command = multipleLineCodeVal;
            }

            string[] ProcessCMDByLine = command.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            foreach (string cmdByLine in ProcessCMDByLine)
            {
                if (!String.IsNullOrEmpty(cmdByLine))
                {
                    runCommand(cmdByLine);
                }

            }



        }

        private void runCommand(string cmdByLine)
        {
            //splitting whole command into command and parameter section
            int firstSpaceIndex = cmdByLine.Trim().IndexOf(" ");
            string cmdPartOnly;
            List<String> parameterList = new List<String>();
            if (firstSpaceIndex > 0)
            {
                cmdPartOnly = cmdByLine.Substring(0, firstSpaceIndex);
                //splitting paramater into arraylist
                string parameterPartOnly = cmdByLine.Substring(firstSpaceIndex + 1);
                if (!String.IsNullOrEmpty(parameterPartOnly))
                {
                    string[] parameterSplits = parameterPartOnly.Split(',');
                    foreach (string parameterSplit in parameterSplits)
                    {
                        if (!String.IsNullOrEmpty(parameterSplit.Trim()))
                        {
                            parameterList.Add(parameterSplit);
                        }

                    }
                }
            }
            else
            {
                cmdPartOnly = cmdByLine;
            }
            cmdPartOnly = cmdPartOnly.ToLower().Trim();

            Shape shape = null;

            if (cmdPartOnly.StartsWith("rectangle"))
            {

                shape = new Rectangle(Graphics, isFillOn, color, xPos, yPos, parameterList);
                shape.Validate();
                shape.Draw();

            }
            else
            {
                throw new SketchApplicationException("Command error");
            }

        }
    }
}

