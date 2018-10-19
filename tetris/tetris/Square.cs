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
        int _x, _y;

        int _dim = 20;
        
        public int X
        {
            set
            {
                if(value > 0)
                    _x = _dim + _dim * (value - 1);
            }
            get
            {
                return _x;
            }
        }

        public int Y
        {
            set
            {
                if (value > 0)
                    _y = _dim + _dim * (value - 1);
            }
            get
            {
                return _y;
            }
        }

        Graphics my;

        public void Draw(Graphics g, Color c)
        {
            my = g;
            Pen p = new Pen(c);
            g.DrawRectangle(p, _x + 1, _y + 1, _dim - 2 , _dim - 2);
        }

        public void ChangeColor (Color c)
        {
            Pen p = new Pen(c);
            my.DrawRectangle(p, _x + 1, _y + 1, _dim - 2, _dim - 2);
        }

        public Square(int i, int j, Graphics g, Color c)
        {
            X = j;
            Y = i;
            this.Draw(g, c);
        }

        public Square(int i, int j)
        {
            X = j;
            Y = i;
        }
    }
}
