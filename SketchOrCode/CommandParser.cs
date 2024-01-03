using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SketchOrCode
{
    public class CommandParser
    {
        private GraphicsAdapter Graphics;
        private bool isFillOn = false;
        private Color color = Color.Black;
        private int xPos = 0;
        private int yPos = 0;

        private Dictionary<string, string> variableValueDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> methodBodyDictionary = new Dictionary<string, string>();

        /*statement
        *CommandParser  constructor class, which initializes the Graphics field with the provided Graphics object.
        */
        public CommandParser(GraphicsAdapter graphics)
        {
            this.Graphics = graphics;
        }

        /*statement
         *Parsecommand takes two string parameters (singleLineCodeVal and multipleLineCodeVal) and a boolean parameter (isSyntaxCheckOnly). 
         *It processes the command lines and executes commands provided.
        */
        public void ParseCommand(String singleLineCodeVal, String multipleLineCodeVal, Boolean isSyntaxCheckOnly)
        {
            String command = singleLineCodeVal;
            //check command to run
            if (String.IsNullOrEmpty(singleLineCodeVal))
            {
                if (String.IsNullOrEmpty(multipleLineCodeVal))
                {
                    throw new SketchApplicationException("Nothing has been passed to processed. Please write your code.");
                }
                command = multipleLineCodeVal;
            }

            string[] ProcessCMDByLine = command.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );


            for (int executionIndex = 0; executionIndex < ProcessCMDByLine.Length; executionIndex++)
            {
                String cmdByLine = ProcessCMDByLine[executionIndex];
                if (!String.IsNullOrEmpty(cmdByLine))
                {
                    try
                    {
                        executionIndex = runCommand(cmdByLine, isSyntaxCheckOnly, executionIndex);
                    }
                    catch(SketchApplicationException x)
                    {
                        throw new SketchApplicationException(x.Message + ". Error occur at Line " + (executionIndex + 1)+".");
                    }catch (Exception x)
                    {
                        Console.WriteLine(x.StackTrace);
                        throw new SketchApplicationException(x.Message + ". Error occur at Line " + (executionIndex + 1) + ".");
                    }
                }
            }


        }
        /*
         * private method called by ParseCommand.
         * It processes an individual command line, extracts the command and parameters, and executes the corresponding action.
         */
        private int runCommand(string cmdByLine, Boolean isSyntaxCheckOnly, int executionIndex)
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

            List<String> parameterListAfterVariableReplacedWithActualVal = new List<String>();
            //changing variables to actual value if any exist
            foreach (String param in parameterList)
            {
                if (variableValueDictionary.ContainsKey(param))
                {
                    String actualParamVal = variableValueDictionary[param];
                    parameterListAfterVariableReplacedWithActualVal.Add(actualParamVal);
                }else
                {
                    parameterListAfterVariableReplacedWithActualVal.Add(param);
                }

                
            }

            parameterList = parameterListAfterVariableReplacedWithActualVal;

            Shape shapes = null;
            //Executing rectangle . checking for the validation 
            if (cmdPartOnly.StartsWith("rectangle"))
            {
                 

                shapes = new Rectangle(Graphics, isFillOn, color, xPos, yPos, parameterList);
                shapes.Validate();
                if (!isSyntaxCheckOnly) {
                    shapes.Draw();
                }
                    

            }
            //Executing circle. checking for the validation 
            else if (cmdPartOnly.StartsWith("circle"))
            {

                shapes = new Circle(Graphics, isFillOn, color, xPos, yPos, parameterList);
                shapes.Validate();
                if (!isSyntaxCheckOnly)
                {
                    shapes.Draw();
                }

            }
            else if (cmdPartOnly.StartsWith("drawto"))
            {
                shapes = new DrawTo(Graphics, isFillOn, color, xPos, yPos, parameterList);
                shapes.Validate();
                if (!isSyntaxCheckOnly)
                {
                    shapes.Draw();
                }
            }
            //Executing traingle. checking for the validation 
            else if (cmdPartOnly.StartsWith("triangle"))
            {
                shapes = new Triangle(Graphics, isFillOn, color, xPos, yPos, parameterList);
                shapes.Validate();
                if (!isSyntaxCheckOnly)
                {
                    shapes.Draw();
                }
            }
            //Executing Square. checking for the validation 
            else if (cmdPartOnly.StartsWith("square"))
            {
                shapes = new Square(Graphics, isFillOn, color, xPos, yPos, parameterList);
                shapes.Validate();
                if (!isSyntaxCheckOnly)
                {
                    shapes.Draw();
                }
            }
            //Executing moveto . checking for the validation moveto command
            else if (cmdPartOnly.StartsWith("moveto"))
            {
                if (parameterList.Count != 2)
                {
                    throw new SketchApplicationException("Moveto param error");
                }

                Boolean isNumeric1 = int.TryParse(parameterList[0], out _);
                if (!isNumeric1)
                {
                    throw new SketchApplicationException("MoveTo param first value is not a number.");
                }

                Boolean isNumeric2 = int.TryParse(parameterList[1], out _);
                if (!isNumeric2)
                {
                    throw new SketchApplicationException("MoveTo param second value is not a number.");
                }

                if (!isSyntaxCheckOnly)
                {
                    this.xPos = int.Parse(parameterList[0]);
                    this.yPos = int.Parse(parameterList[1]);
                }
                
            }
            else if (cmdPartOnly.StartsWith("clear"))
            {
                if (!isSyntaxCheckOnly)
                {
                    Graphics.Clear(System.Drawing.SystemColors.ButtonShadow);
                }
                
            }
            else if (cmdPartOnly.StartsWith("reset"))
            {
                if (!isSyntaxCheckOnly)
                {
                    this.xPos = 0;
                    this.yPos = 0;
                    this.color = Color.Black;
                    Graphics.Clear(System.Drawing.SystemColors.ButtonShadow);
                }
                


            }
            // working with command line pen
            else if (cmdPartOnly.StartsWith("pen"))
            {
                if (parameterList.Count != 1)
                {
                    throw new SketchApplicationException("Pen param error");
                }

                Boolean isNumeric1 = int.TryParse(parameterList[0], out _);
                if (isNumeric1)
                {
                    throw new SketchApplicationException("Pen param first value is not valid color name.");
                }


                if (!isSyntaxCheckOnly)
                {
                    String colorName = (string)parameterList[0];
                    this.color = Color.FromName(colorName);
                }
                    
            }
            // fill command to fill in the colors.
            else if (cmdPartOnly.StartsWith("fill"))
            {
                if (parameterList.Count != 1)
                {
                    throw new SketchApplicationException("Fill param error");
                }

                Boolean isNumeric1 = int.TryParse(parameterList[0], out _);
                if (isNumeric1)
                {
                    throw new SketchApplicationException("Fill param first value is not a string.");
                }



                String fillOn = (string)parameterList[0];
                if (fillOn.ToLower().Trim().Equals("on"))
                {
                    if (!isSyntaxCheckOnly)
                    {
                        this.isFillOn = true;
                    }
                   
                }
                else if (fillOn.ToLower().Trim().Equals("off"))
                {
                    if (!isSyntaxCheckOnly)
                    {
                        this.isFillOn = false;
                    }
                }
                else
                {
                    throw new SketchApplicationException("Fill param first value is not on/off.");
                }


            }
            else if (cmdByLine.Contains("="))
            {
                
                string[] parts = cmdByLine.Split('=');

                if (parts.Length == 2)
                {
                    string part2Val = expersionEval(parts[1]).ToString();
                    if (variableValueDictionary.ContainsKey(parts[0]))
                    {
                        variableValueDictionary.Remove(parts[0]);
                    }
                    variableValueDictionary.Add(parts[0], part2Val);
                }
                    
            }
            else if (cmdPartOnly.Contains("while"))
            {

                //while loop work

            }
            else if (cmdPartOnly.Contains("if"))
            {

                //if work

            }
            else if (cmdPartOnly.Contains("call"))
            {

                //method call work

            }
            else if (cmdPartOnly.Contains("method"))
            {

                //method work
               // methodBodyDictionary.Add()

            }

            else
            {
                throw new SketchApplicationException(cmdPartOnly + " command error");
            }

            return executionIndex;

        }
        /*
         * This method is intended to return the input command based on the provided parameters single line or multiple line, 
         * with some error checking.
         */

        public String getInputCommand(String singleLineCodeVal, String multipleLineCodeVal)
        {

            if (String.IsNullOrEmpty(singleLineCodeVal))
            {
                if (String.IsNullOrEmpty(multipleLineCodeVal))
                {
                    throw new SketchApplicationException("Nothing has been passed to processed. Please write your code.");
                }
                return multipleLineCodeVal;
            }
            return singleLineCodeVal;
        }

        public void SaveFile(String saveFileLocation, String command)
        {
            File.WriteAllText(saveFileLocation, command);
        }

        public String ReadFile(String saveFileLocation)
        {
            return File.ReadAllText(saveFileLocation);
        }

        public int expersionEval(String expression)
        {
            if (expression.Contains("+"))
            {
                string[] split = expression.Split('+');
                string firstOp = split[0];
                string secondOp = split[1];
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }
                return int.Parse(firstOp) + int.Parse(secondOp);
            }
            else if (expression.Contains("-"))
            {
                string[] split = expression.Split('-');
                string firstOp = split[0];
                string secondOp = split[1];
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }
                return int.Parse(firstOp) - int.Parse(secondOp);
            }
            else if (expression.Contains("/"))
            {
                string[] split = expression.Split('/');
                string firstOp = split[0];
                string secondOp = split[1];
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }
                return int.Parse(firstOp) / int.Parse(secondOp);
            }
            else if (expression.Contains("*"))
            {
                string[] split = expression.Split('*');
                string firstOp = split[0];
                string secondOp = split[1];
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }
                return int.Parse(firstOp) * int.Parse(secondOp);
            }
            return int.Parse(expression);
        }

        }

  
}

