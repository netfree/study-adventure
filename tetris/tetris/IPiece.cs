﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace tetris
{
    class IPiece : Piece
    {
        private int[] _i = new int[] { 1, 2, 3, 4 };
        private int[] _j = new int[] { 1, 1, 1, 1 };
        Game game;
        public Color color = Color.Red;
        public IPiece()
        { }
        private void Adjust()
        {
            for (int i = 0; i < 4; ++i)
                _j[i] += (Game.J_TILES - 1) / 2;
        }

        public IPiece(Game g, Color c)
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

        public override void Solidify()
        {
            for (int t = 0; t < 4; ++t)
                game.squares[_i[t], _j[t]].Solid = true;
            game.CheckGame();
        }
    }
}

