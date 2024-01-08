using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SketchOrCode
{
    public partial class Form1 : Form
    {

#pragma warning disable CS0169 // The field 'Form1.multipleLineCode' is never used
        private object multipleLineCode;
#pragma warning restore CS0169 // The field 'Form1.multipleLineCode' is never used
#pragma warning disable CS0169 // The field 'Form1.multipleLineCodeVal' is never used
        private readonly object multipleLineCodeVal;
#pragma warning restore CS0169 // The field 'Form1.multipleLineCodeVal' is never used

        public Form1()
        {
            InitializeComponent();
        }



        /*
         *Run Button class creates a Graphics object from a PictureBox and uses a CommandParser to parse and execute the entered commands.
         */

        private void runbutton1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            runGPLThread(graphics, textBox1.Text, richTextBox1.Text, false, 1);

        }

        /*
         *Script button class when clicked does a syntax check (without executing) using the CommandParser and 
         *shows a message box indicating whether there are syntax errors.
         */

        private void scriptbutton2_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            runGPLThread(graphics, textBox1.Text, richTextBox1.Text, true, 1);
            MessageBox.Show("Everything looks good. No error found.");

        }

        /*
         * This method is called when the "Save" button (savebutton1) is clicked. 
         * It opens a SaveFileDialog, gets the selected file location, and saves the entered commands to the selected file.
         */
        private void savebutton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; ;
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string saveFileLocation = saveFileDialog1.FileName;
            CommandParser commandParser = new CommandParser(null);// constructor
            commandParser.SaveFile(saveFileLocation, commandParser.getInputCommand(textBox1.Text, richTextBox1.Text));// It writes the content of the input commands to a file specified by the user during the save operation.
            MessageBox.Show("File saved");
        }

        /*
         * This method is called when the "Import" button (importbutton1) is clicked.
         * It opens an OpenFileDialog, reads the contents of the selected file, and displays them in the richTextBox1.
         */
        private void importbutton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; ;
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string readFileLocation = openFileDialog1.FileName;

            CommandParser commandParser = new CommandParser(null);// constructor
            string cmdReadFromFile = commandParser.ReadFile(readFileLocation);
            richTextBox1.Text= cmdReadFromFile;
            MessageBox.Show("File imported");
        }

        private void multipleLineCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void displayArea_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //run button for second program
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            runGPLThread(graphics, null, richTextBox2.Text, false, 2);
        }

        //syntax check button for second program
        private void syntaxBtn2_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            runGPLThread(graphics, null, richTextBox2.Text, true, 2);
            MessageBox.Show("Everything looks good. No error found.");
        }

        private void runGPLThread(Graphics graphics, String commandLine, String multiline, Boolean isSyntaxCheck, int programNo)
        {
            Thread thread = new Thread(() =>
            {

                Thread t = Thread.CurrentThread;
                CommandParser commandParser = new CommandParser(new GraphicsAdapter(graphics));
                commandParser.ParseCommand(commandLine, multiline, isSyntaxCheck);
            });

            thread.Start();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
  


