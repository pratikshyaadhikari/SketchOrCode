using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
private System.Windows.Forms.RichTextBox multipleLineCode;

namespace SketchOrCode
{
    public partial class Form1 : Form
    {
        ArrayList shapes = new ArrayList();
        private object multipleLineCode;
        private readonly object multipleLineCodeVal;

        public Form1()
        {
            InitializeComponent();
        }





        private void runbutton1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            CommandParser commandParser = new CommandParser(graphics);
            commandParser.ParseCommand(textBox1.Text, richTextBox1.Text, false);

        }

        private void scriptbutton2_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            CommandParser commandParser = new CommandParser(graphics);
            commandParser.ParseCommand(textBox1.Text, richTextBox1.Text, true);

        }

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
            CommandParser commandParser = new CommandParser(null);
            File.WriteAllText(saveFileLocation, commandParser.getInputCommand(singleLineCodeVal.Text, multipleLineCodeVal.Text));
        }


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
            string cmdReadFromFile = File.ReadAllText(readFileLocation);
            multipleLineCode.Text= cmdReadFromFile;
        }

        private void multipleLineCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void displayArea_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
  


