using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace tetris
{
    class Square
    {
        Game game; int _x, _y, _width = Game.T_WIDTH;
        Graphics g; Color c;
        private bool _active = false;
        private bool _drawn = false;

        public Square(Game b)
        {
            game = b;
            g = game.G;
            c = Color.Black;
        }

        public void SetPosition(int i, int j)
        {
            if (i * j > 0)
            {
                _x = Game.X_BOARD + _width * (j - 1);
                _y = Game.Y_BOARD + _width * (i - 1);
            }
        }

        public void Draw()
        { 
            Pen p = new Pen(c);
            g.DrawRectangle(p, _x + 1, _y + 1, _width - 2 , _width - 2);
        }

        public bool Drawn
        {
            set
            {
                if (value == true)
                    Draw();
                else
                {
                    c = Color.White;
                    Draw();
                }
            }
            get
            {
                return _drawn;
            }
        }


        public void SetColor(Color color)
        {
            c = color;
            Draw();
        }
    }
}
