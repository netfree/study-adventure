using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Game game = new Game();
            var g = this.CreateGraphics();

            Square[,] square = new Square[100,100];

            for(int i = 1; i<=20; ++i)
                for(int j = 1; j<=10; ++j)
                {
                    square[i,j] = new Square(i, j, g, Color.Black);
                }

            square[3, 5].ChangeColor(Color.White);
            

            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
