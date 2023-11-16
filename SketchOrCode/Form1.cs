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
            shapes.Add(new Circle(Color.Purple, 10, 100, 100));
            shapes.Add(new Circle(Color Red, 100, 10, 50));
            shapes.Add(new Rectangle(Color.Blue, 150, 150, 50, 100));
            ///summary   
            ///starting new project 
        }

      

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //excute run call the method


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
