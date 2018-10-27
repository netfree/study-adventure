using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace tetris
{
    class Game
    {
        Form1 form1;
        Graphics g;
        public const int X_BOARD = 10, Y_BOARD = 10;
        public const int I_TILES = 20, J_TILES = 10;
        public const int T_WIDTH = 24;

        public Graphics G
        {
            get
            {
                return g;
            }
        }

        public Square[,] squares = new Square[10000, 10000];

        private void DrawBoard()
        {
            for (int i = 0; i <= I_TILES + 1; ++i)
                for (int j = 0; j <= J_TILES + 1; ++j)
                {
                    squares[i, j] = new Square(this);
                    squares[i, j].SetPosition(i, j);
                    squares[i, j].Solid = true;
                }

            for (int i = 1; i <= I_TILES; ++i)
                for (int j = 1; j <= J_TILES; ++j)
                {
                    squares[i, j].SetColor(Color.Gray);
                    squares[i, j].Solid = false;
                }
        }

        public void Right()
        {

        }


        public SquarePiece piece;


        public Game(Form1 f)
        {
            form1 = f;
            g = form1.CreateGraphics();
            DrawBoard();
            piece = new SquarePiece(this, Color.Red);
        }

        public void EndGame()
        {
            Debug.WriteLine("AI PIERDUT!");
        }

    }
}
