using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace tetris
{
    class TPiece : Piece
    {
        private int[] _i = new int[] { 1, 2, 2, 2 };
        private int[] _j = new int[] { 2, 1, 2, 3 };
        Game game;
        public Color color = Color.Red;

        private void Adjust()
        {
            for (int i = 0; i < 4; ++i)
                _j[i] += (Game.J_TILES - 1) / 2;
        }
        public TPiece()
        { }

        public TPiece(Game g, Color c)
        {
            game = g;
            color = c;
            Adjust();
            if (CanMove(0, 0) == true)
            {
                for (int i = 0; i < 4; ++i)
                {
                    game.squares[_i[i], _j[i]].SetColor(color);
                }
            }
            else
            {
                game.EndGame();
            }
        }
        public override bool CanMove(int ii, int jj)
        {
            for (int t = 0; t < 4; ++t)
                if (game.squares[_i[t] + ii, _j[t] + jj].Solid == true)
                    return false;
            return true;
        }

        public override void Solidify()
        {
            for (int t = 0; t < 4; ++t)
                game.squares[_i[t], _j[t]].Solid = true;
            game.CheckGame();
        }

        public override void Move(int ii, int jj)
        {
            for (int t = 0; t < 4; ++t)
                game.squares[_i[t], _j[t]].SetColor(Color.LightGray);

            for (int t = 0; t < 4; ++t)
            {
                _i[t] += ii;
                _j[t] += jj;
            }

            for (int t = 0; t < 4; ++t)
                game.squares[_i[t], _j[t]].SetColor(color);
        }


        public override void RotateClockwise()
        {
            int c_i = _i[2];
            int c_j = _j[2];
            int[] bk_i = new int[4];
            int[] bk_j = new int[4];
            for (int i = 0; i < 4; ++i)
            {
                bk_i[i] = _i[i];
                bk_j[i] = _j[i];
                _i[i] = (bk_j[i] - c_j) + c_i;
                _j[i] = -(bk_i[i] - c_i) + c_j;
            }


            if (CanMove(0, 0))
            {
                for (int i = 0; i < 4; ++i)
                {
                    game.squares[bk_i[i], bk_j[i]].SetColor(Color.LightGray);
                }

                for (int i = 0; i < 4; ++i)
                {
                    game.squares[_i[i], _j[i]].SetColor(color);
                }
            }
            else
            {
                for (int i = 0; i < 4; ++i)
                {
                    _i[i] = bk_i[i];
                    _j[i] = bk_j[i];
                }
            }

        }

    }
}
