using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace tetris
{
    class Piece
    {
        Game game;

        int[] ICoords = new int[5];       
        int[] JCoords = new int[5];       

        public Piece(Game g)
        {
            game = g;
            ICoords[1] = 1; JCoords[1] = 10;
            ICoords[2] = 2; JCoords[2] = 10;
            ICoords[3] = 3; JCoords[3] = 10;
            ICoords[4] = 4; JCoords[4] = 10;

        }

        int _i = 1, _j = 1;

        public void Drop()
        {
            for(int i = 1; i<=4; ++i)
            {
                game.squares[ICoords[i], JCoords[i]].SetColor(Color.Red);
                game.squares[ICoords[i] - 1, JCoords[i]].SetColor(Color.Black);
            }
     
            System.Threading.Thread.Sleep(500);
        }

        public void Action()
        {
            while (_i < Game.I_TILES)
            {
                Drop();
                Console.WriteLine(_i.ToString());
            }
            return;
        }
    }
}
