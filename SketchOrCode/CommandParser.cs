﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.LinkLabel;

namespace SketchOrCode
{
    /// <summary>
    /// Represents a class for parsing commands and executing corresponding actions.
    /// </summary>
    public class CommandParser
    {
        private GraphicsAdapter Graphics;
        private bool isFillOn = false;
        private Color color = Color.Black;
        private int xPos = 0;
        private int yPos = 0;

        //* using singleton pattern where we use this dictionary instant variable to use globally within the program 
        private Dictionary<string, string> variableValueDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> methodBodyDictionary = new Dictionary<string, string>();
       
        
        /// <statement>
        /// CommandParser  constructor class, which initializes the Graphics field with the provided Graphics object.
        /// </statement>
        public CommandParser(GraphicsAdapter graphics)
        {
            this.Graphics = graphics;
        }

        /// <statement>
        /// Parsecommand takes two string parameters (singleLineCodeVal and multipleLineCodeVal) and a boolean parameter (isSyntaxCheckOnly). 
        ///  It processes the command lines and executes commands provided.
        /// </statement> 
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
                        executionIndex = runCommand(cmdByLine, isSyntaxCheckOnly, executionIndex, ProcessCMDByLine);
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
       
        /// <statement>
        ///private method called by ParseCommand.
        ///It processes an individual command line, extracts the command and parameters, and executes the corresponding action.. 
        /// </statement>
        private int runCommand(string cmdByLine, Boolean isSyntaxCheckOnly, int executionIndex, string[] ProcessCMDByLine)
        {
            Thread.Sleep(1000);
            cmdByLine = cmdByLine.Trim();
            //splitting whole command into command and parameter section
            int firstSpaceIndex = cmdByLine.IndexOf(" ");
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
            else if (cmdPartOnly.Contains("while") || cmdPartOnly.Contains("endwhile"))
            {

                

                if (cmdPartOnly.Equals("endWhile"))
                {
                    return executionIndex; // no need to work
                }else
                {
                    if (parameterList.Count != 1)
                    {
                        throw new SketchApplicationException("While statement condition part not exist.");
                    }
                }

                Console.WriteLine("hello");
                String evalCondtion = parameterList[0];
                int endWhileIndex = 0;
                Boolean isEndWhileStatementExist = false;
                if (evaluateCondtion(evalCondtion))
                {
                    Console.WriteLine("while true");
                    
                    for (int executionIndexForLoopCont = executionIndex + 1; executionIndexForLoopCont < ProcessCMDByLine.Length; executionIndexForLoopCont++)
                    {

                        if (executionIndexForLoopCont == ProcessCMDByLine.Length)
                        {
                            break;
                        }

                        String loopCmd = ProcessCMDByLine[executionIndexForLoopCont];

                        if (loopCmd.Equals("endwhile"))
                        {
                            endWhileIndex = executionIndexForLoopCont;
                            executionIndexForLoopCont = executionIndex;
                            isEndWhileStatementExist = true;
                            continue;
                        }

                        if (evaluateCondtion(evalCondtion))
                        {
                            executionIndexForLoopCont = runCommand(loopCmd, isSyntaxCheckOnly, executionIndexForLoopCont, ProcessCMDByLine);
                        }
                        else
                        {
                            return endWhileIndex;
                        }

                        continue;
                    }

                    
                }
                else
                {
                    for (int executionIndexForSkip = executionIndex + 1; executionIndexForSkip < ProcessCMDByLine.Length; executionIndexForSkip++)
                    {
                        if (executionIndexForSkip == ProcessCMDByLine.Length)
                        {
                            break;
                        }

                        String skipCmd = ProcessCMDByLine[executionIndexForSkip];
                        if (skipCmd.Equals("endwhile"))
                        {

                            isEndWhileStatementExist = true;
                            return executionIndexForSkip; // no need to work
                        }

                        continue;
                    }
                    Console.WriteLine("if false");
                }

                if (!isEndWhileStatementExist)
                {
                    throw new SketchApplicationException("Loop end statement endwhile does not found.");
                }

            }
            else if (cmdPartOnly.Contains("if") || cmdPartOnly.Equals("endif"))
            {
                

               
                if (cmdPartOnly.Equals("endif"))
                {
                    return executionIndex; // no need to work
                }else
                {
                    Boolean isEndIfStatementExist = false;
                    if (parameterList.Count != 1)
                    {
                        throw new SketchApplicationException("if statement condition part not exist.");
                    }

                    //validation end if block
                    for (int executionIndexForSkip = executionIndex + 1; executionIndexForSkip < ProcessCMDByLine.Length; executionIndexForSkip++)
                    {

                        if (executionIndexForSkip == ProcessCMDByLine.Length)
                        {
                            break;
                        }

                        String skipCmd = ProcessCMDByLine[executionIndexForSkip];
                        if (skipCmd.Contains("endif"))
                        {
                            isEndIfStatementExist = true;
                        }
                    }

                    Console.WriteLine("hello");
                    String evalCondtion = parameterList[0];
                    
                    if (evaluateCondtion(evalCondtion))
                    {
                        //ignore true the basic flow will handle this one
                        Console.WriteLine("if true");
                    }
                    else
                    {
                        for (int executionIndexForSkip = executionIndex + 1; executionIndexForSkip < ProcessCMDByLine.Length; executionIndexForSkip++)
                        {

                            if (executionIndexForSkip == ProcessCMDByLine.Length)
                            {
                                break;
                            }

                            String skipCmd = ProcessCMDByLine[executionIndexForSkip];
                            if (skipCmd.Contains("endif"))
                            {
                                return executionIndexForSkip; // no need to work
                            }

                            continue;
                        }
                    }
                    if (!isEndIfStatementExist)
                    {
                        throw new SketchApplicationException("If statement endif does not found.");
                    }
                }

                
               


            }
            else if (cmdPartOnly.Contains("call")) // method call
            {
                if (parameterList.Count != 1)
                {
                    throw new SketchApplicationException("method statement method name param not defined.");
                }

                Console.WriteLine("method def part started");
                String methodName = parameterList[0].Trim();
                if (!methodBodyDictionary.ContainsKey(methodName))
                {
                    throw new SketchApplicationException(methodName + " does not defined yet. ");
                }

                String methodBody = methodBodyDictionary[methodName];


                string[] methodProcessCMDByLine = methodBody.Split(
               new string[] { "\r\n", "\r", "\n" },
               StringSplitOptions.None
           );


                for (int methodExecutionIndex = 0; methodExecutionIndex < methodProcessCMDByLine.Length; methodExecutionIndex++)
                {
                   

                    String methodcmdByLine = methodProcessCMDByLine[methodExecutionIndex];
                    if (!String.IsNullOrEmpty(methodcmdByLine))
                    {
                        runCommand(methodcmdByLine, isSyntaxCheckOnly, methodExecutionIndex, methodProcessCMDByLine);
                    }
                }


            }
            else if (cmdPartOnly.Contains("method")) // method defination
            {

                if (parameterList.Count != 1)
                {
                    throw new SketchApplicationException("method statement method name param not defined.");
                }

                //method work
                //methodBodyDictionary.Add()

                Console.WriteLine("method def part started");
                String methodName = parameterList[0].Trim();

                Boolean isMethodDefExist = false;
                String methodBody = "";
                for (int executionIndexForSkip = executionIndex + 1; executionIndexForSkip < ProcessCMDByLine.Length; executionIndexForSkip++)
                {

                    if(executionIndexForSkip == ProcessCMDByLine.Length)
                    {
                        break;
                    }

                    String methodCMD = ProcessCMDByLine[executionIndexForSkip];
                    if (methodCMD.Contains("endmethod"))
                    {
                        methodBodyDictionary.Add(methodName, methodBody);
                        return executionIndexForSkip;
                    }
                    methodBody = methodBody + methodCMD + "\n";
                }

                if (methodBodyDictionary.ContainsKey(methodName))
                {
                    throw new SketchApplicationException(methodName + " already defined. Duplication method def found. ");
                }
                if (!isMethodDefExist)
                {
                    throw new SketchApplicationException("method statement endmethod statement not defined.");
                }
            }
            else if (cmdByLine.Contains("=")) //variables declaration
            {

                string[] parts = cmdByLine.Split('=');

                if (parts.Length == 2)
                {
                    string part2Val = ArithmeticOperation(parts[1]).ToString();
                    if (variableValueDictionary.ContainsKey(parts[0].Trim()))
                    {
                        variableValueDictionary.Remove(parts[0].Trim());
                    }
                    variableValueDictionary.Add(parts[0].Trim(), part2Val);
                }

            }
            //variables declaration bkock end
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
        /// <summary>
        /// save file to the desired location
        /// </summary>
        /// <param name="saveFileLocation"></param>
        /// <param name="command"></param>
        public void SaveFile(String saveFileLocation, String command)
        {
            File.WriteAllText(saveFileLocation, command);
        }

        public String ReadFile(String saveFileLocation)
        {
            return File.ReadAllText(saveFileLocation);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="SketchApplicationException"></exception>
        public int ArithmeticOperation(String expression)
        {
            if (expression.Contains("+"))
            {
                string[] split = expression.Split('+');
                string firstOp = split[0].Trim();
                string secondOp = split[1].Trim();
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }

                if(!int.TryParse(firstOp, out _))
                {
                    throw new SketchApplicationException(firstOp + " is invalid value.");
                }

                if (!int.TryParse(secondOp, out _))
                {
                    throw new SketchApplicationException(secondOp + " is invalid value.");
                }

                return int.Parse(firstOp) + int.Parse(secondOp);
            }
            else if (expression.Contains("-"))
            {
                string[] split = expression.Split('-');
                string firstOp = split[0].Trim();
                string secondOp = split[1].Trim();
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }

                if (!int.TryParse(firstOp, out _))
                {
                    throw new SketchApplicationException(firstOp + " is invalid value.");
                }

                if (!int.TryParse(secondOp, out _))
                {
                    throw new SketchApplicationException(secondOp + " is invalid value.");
                }

                return int.Parse(firstOp) - int.Parse(secondOp);
            }
            else if (expression.Contains("/"))
            {
                string[] split = expression.Split('/');
                string firstOp = split[0].Trim();
                string secondOp = split[1].Trim();
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }

                if (!int.TryParse(firstOp, out _))
                {
                    throw new SketchApplicationException(firstOp + " is invalid value.");
                }

                if (!int.TryParse(secondOp, out _))
                {
                    throw new SketchApplicationException(secondOp + " is invalid value.");
                }

                return int.Parse(firstOp) / int.Parse(secondOp);
            }
            else if (expression.Contains("*"))
            {
                string[] split = expression.Split('*');
                string firstOp = split[0].Trim();
                string secondOp = split[1].Trim();
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }

                if (!int.TryParse(firstOp, out _))
                {
                    throw new SketchApplicationException(firstOp + " is invalid value.");
                }

                if (!int.TryParse(secondOp, out _))
                {
                    throw new SketchApplicationException(secondOp + " is invalid value.");
                }

                return int.Parse(firstOp) * int.Parse(secondOp);
            }
            return int.Parse(expression);
        }

        public Boolean evaluateCondtion(String expression) // loop  work with variabl 
        {
            if (expression.Contains(">"))
            {
                string[] split = expression.Split('>');
                string firstOp = split[0].Trim();
                string secondOp = split[1].Trim();
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }

                if (!int.TryParse(firstOp, out _))
                {
                    throw new SketchApplicationException(firstOp + " is invalid value.");
                }

                if (!int.TryParse(secondOp, out _))
                {
                    throw new SketchApplicationException(secondOp + " is invalid value.");
                }

                return int.Parse(firstOp) > int.Parse(secondOp);
            }else if (expression.Contains("<"))
            {
                string[] split = expression.Split('<');
                string firstOp = split[0].Trim();
                string secondOp = split[1].Trim();
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }

                if (!int.TryParse(firstOp, out _))
                {
                    throw new SketchApplicationException(firstOp + " is invalid value.");
                }

                if (!int.TryParse(secondOp, out _))
                {
                    throw new SketchApplicationException(secondOp + " is invalid value.");
                }

                return int.Parse(firstOp) < int.Parse(secondOp);
            }
            else if (expression.Contains(">="))
            {
                string[] split = expression.Split(new[] { ">=" }, StringSplitOptions.None);
                string firstOp = split[0].Trim();
                string secondOp = split[1].Trim();
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }

                if (!int.TryParse(firstOp, out _))
                {
                    throw new SketchApplicationException(firstOp + " is invalid value.");
                }

                if (!int.TryParse(secondOp, out _))
                {
                    throw new SketchApplicationException(secondOp + " is invalid value.");
                }

                return int.Parse(firstOp) >= int.Parse(secondOp);
            }
            else if (expression.Contains("<="))
            {
                string[] split = expression.Split(new[] { "<=" }, StringSplitOptions.None);
                string firstOp = split[0].Trim();
                string secondOp = split[1].Trim();
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }

                if (!int.TryParse(firstOp, out _))
                {
                    throw new SketchApplicationException(firstOp + " is invalid value.");
                }

                if (!int.TryParse(secondOp, out _))
                {
                    throw new SketchApplicationException(secondOp + " is invalid value.");
                }

                return int.Parse(firstOp) <= int.Parse(secondOp);
            }
            else if (expression.Contains("=="))
            {
                string[] split = expression.Split(new[] { "==" }, StringSplitOptions.None);
                string firstOp = split[0].Trim();
                string secondOp = split[1].Trim();
                if (variableValueDictionary.ContainsKey(firstOp))
                {
                    firstOp = variableValueDictionary[firstOp];
                }
                if (variableValueDictionary.ContainsKey(secondOp))
                {
                    secondOp = variableValueDictionary[secondOp];
                }

                if (!int.TryParse(firstOp, out _))
                {
                    throw new SketchApplicationException(firstOp + " is invalid value.");
                }

                if (!int.TryParse(secondOp, out _))
                {
                    throw new SketchApplicationException(secondOp + " is invalid value.");
                }

                return int.Parse(firstOp) == int.Parse(secondOp);
            }
            return false;
            
        }

      

    }


}

