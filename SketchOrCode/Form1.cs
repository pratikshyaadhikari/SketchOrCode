using System;
using System.Collections;
using System.Drawing;
using System.IO;
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
            File.WriteAllText(saveFileLocation, commandParser.getInputCommand(singleLineCode.Text, multipleLineCode.Text));
        }

    }

        private void importbutton1_Click(object sender, EventArgs e)
        {


        }
    }
}
