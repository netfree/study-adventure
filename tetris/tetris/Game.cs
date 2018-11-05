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
        public int Score = 0; 
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
                    squares[i, j].SetColor(Color.LightGray);
                    squares[i, j].Solid = false;
                }
        }

        public void Right()
        {

        }


        public Piece piece;
       


        public Game(Form1 f)
        {
            form1 = f;
            g = form1.CreateGraphics();
            DrawBoard();
            //piece = new SquarePiece(this, Color.Red);
            NewPiece();
        }

        public bool ended = false;

        public void EndGame()
        {
            if (ended == false)
            {
                form1.END();
                ended = true;
            }
        }

        public void NewPiece()
        {
            Random rnd = new Random();
            int rand = rnd.Next(1, 6);
            
            Color[] clr = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };
            int rand_color = rnd.Next(0, clr.Length);

            if(piece != null)
                piece.Solidify();

            if (rand == 1)
                piece = new ZPiece(this, clr[rand_color]);
            else if (rand == 2)
                piece = new IPiece(this, clr[rand_color]);
            else if (rand == 3)
                piece = new SquarePiece(this, clr[rand_color]);
            else if (rand == 4)
                piece = new LPiece(this, clr[rand_color]);
            else
                piece = new TPiece(this, clr[rand_color]);

        }

        public void CheckGame()
        {
            for (int i = 1; i <= I_TILES; ++i)
            {
                bool full = true;
                for (int j = 1; j <= J_TILES; ++j)
                    if (squares[i, j].Solid == false)
                        full = false;
                if (full)
                {
                    Score++; 

                    for (int ii = i; ii > 1; --ii)
                        for (int jj = 1; jj <= J_TILES; ++jj)
                        {
                            squares[ii, jj].SetColor(squares[ii - 1, jj].c);
                            squares[ii, jj].Solid = squares[ii - 1, jj].Solid;
                        }
                    
                }
            }
        }
    }
}
