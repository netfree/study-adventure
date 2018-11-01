using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    abstract class Piece
    {
        public abstract bool CanMove(int ii, int jj);
        public abstract void Move(int ii, int jj);
        public abstract void Solidify();
        public abstract void RotateClockwise();
    }
}
