using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        public Square[,] squares = new Square[I_TILES + 5, J_TILES + 5];

        private void DrawBoard()
        {
            for(int i = 1; i<=I_TILES; ++i)
                for(int j = 1; j<=J_TILES; ++j)
                {
                    squares[i, j] = new Square(this);
                    squares[i, j].SetPosition(i, j);
                    squares[i, j].SetColor(Color.Black);
                }
        }

        public void EndGame()
        {

        }

        public Game(Form1 f)
        {
            form1 = f;
            g = form1.CreateGraphics();
            DrawBoard();
            var piece = new Piece(this);
            piece.Action();
        }

    }
}
