using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SketchOrCode
{
    public partial class Form1 : Form
    {
        ArrayList shapes= new ArrayList();
        public Form1()
        {
            InitializeComponent();
            shapes.Add(new Circle(Color.Purple, 10, 100, 100));
            shapes.Add(new Circle(Color Red, 100, 10, 50));
            shapes.Add(new Rectangle(Color.Blue, 150, 150, 50, 100));
           ///summary   
           ///starting new project 
        }
        private void Form1_SketchOrCode(object sender, EventArgs e)
        {
            Graphics g = e.Graphics;
            for(int i = 0; i < shapes.Count; i++)
            {
               

                Shape s;
                s=(Shape)shapes[i];
                s.draw(g);
                Console.WriteLine(s.ToString());   
            }
        }
    }
}
