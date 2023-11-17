using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SketchOrCode
{
    public partial class Form1 : Form
    {
        ArrayList shapes = new ArrayList();
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


        }

        private void importbutton1_Click(object sender, EventArgs e)
        {


        }
    }
}
