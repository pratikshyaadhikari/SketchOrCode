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
                command =  multipleLineCodeVal;
            }
            

            // Implement the logic to parse the command
            // You can add more sophisticated parsing logic based on your requirements
            Console.WriteLine($"Parsing command: {command}");

            // Example: Splitting the command into words
            string[] commandWords = command.Split(' ');

            // Example: Displaying each word
            foreach (string word in commandWords)
            {
                Console.WriteLine($"Word: {word}");
            }

            // Add more parsing logic as needed
        }
            if (cmdPartOnly.StartsWith("rectangle"))

        // You can add more methods for different parsing tasks if required
    }

}

