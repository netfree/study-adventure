using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Piece
    {
        protected int id = 1;
        public void ShowStatus()
        {
            Console.WriteLine(id.ToString());
        }
    }

    class SquarePiece : Piece
    {
        public SquarePiece()
        {
           id = 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sp = new SquarePiece();
            sp.ShowStatus();
            Console.ReadKey();
        }
    }
}
