using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace tetris
{
    class SquarePiece : Piece
    {
        private int[] _i = new int[] {1, 1, 2, 2};
        private int[] _j = new int[] {1, 2, 1, 2};
        Game game;
        public Color color = Color.Red;

        private void Adjust()
        {
            for (int i = 0; i < 4; ++i)
                _j[i] += (Game.J_TILES-1) / 2;
        }

        public SquarePiece(Game g, Color c)
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

        public bool CanMove(int ii, int jj)
        {
            for (int t = 0; t < 4; ++t)
                if (game.squares[_i[t] + ii, _j[t] + jj].Solid == true)
                    return false;
            return true;
        }

        public void Move(int ii, int jj)
        {
            for (int t = 0; t < 4; ++t)
                game.squares[_i[t], _j[t]].SetColor(Color.Gray);

            for (int t = 0; t < 4; ++t)
            {
                _i[t] += ii;
                _j[t] += jj;
            }

            for (int t = 0; t < 4; ++t)
                game.squares[_i[t], _j[t]].SetColor(color);
        }

        public void Solidify()
        {
            for (int t = 0; t < 4; ++t)
                game.squares[_i[t], _j[t]].Solid = true;
        }
    }
}
