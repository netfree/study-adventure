using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace tetris
{
    public partial class Form1 : Form
    {
        Game game;

        public Form1()
        {
            InitializeComponent();
            
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            game = new Game(this);
            timer1.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //game.piece.color = Color.Black;
            game.piece.Move(0, 0);
            game.piece.Solidify();
            game.piece = new SquarePiece(game, Color.Red);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (game.piece.CanMove(1, 0))
                game.piece.Move(1, 0);
            else
            { 
                game.NewPiece();    
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (game.piece.CanMove(-1, 0))
                game.piece.Move(-1, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (game.piece.CanMove(1, 0))
                game.piece.Move(1, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (game.piece.CanMove(0, -1))
                game.piece.Move(0, -1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (game.piece.CanMove(0, 1))
                game.piece.Move(0, 1);
          

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine(e.KeyChar.ToString());

            if (e.KeyChar == 'w' && game.piece.CanMove(1, 0))
                game.piece.Move(1, 0);

            if (e.KeyChar == 's' && game.piece.CanMove(-1, 0))
                game.piece.Move(-1, 0);

            if (e.KeyChar == 'd' && game.piece.CanMove(0, 1))
                game.piece.Move(0, 1);

            if (e.KeyChar == 'a' && game.piece.CanMove(0, -1))
                game.piece.Move(0, -1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine(e.KeyChar.ToString());

            if (e.KeyChar == 's' && game.piece.CanMove(1, 0))
                game.piece.Move(1, 0);

            if (e.KeyChar == 'w' && game.piece.CanMove(-1, 0))
                game.piece.Move(-1, 0);

            if (e.KeyChar == 'd' && game.piece.CanMove(0, 1))
                game.piece.Move(0, 1);

            if (e.KeyChar == 'a' && game.piece.CanMove(0, -1))
                game.piece.Move(0, -1);

            if (e.KeyChar == 'q')
            {
                game.NewPiece();
            }
        }

   
    }
}
