using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetColonie
{
    internal class HotelDeVille : Batiment
    {
        public HotelDeVille(int positionX, int positionY) : base(positionX, positionY)
        {
            _symbole = "X";
            _couleur = ConsoleColor.White;
            _surface = 12;
            _positionsPlateau = new int[][]
                {
                    new int[] { _positionX, _positionY },
                    new int[] { _positionX + 1, _positionY },
                    new int[]{ _positionX, _positionY + 1 },
                    new int[]{ _positionX + 1, _positionY + 1 },
                    new int[]{ _positionX, _positionY + 2 },
                    new int[]{ _positionX + 1, _positionY + 2 },
                    new int[]{ _positionX + 2, _positionY + 2 },
                    new int[]{ _positionX + 2, _positionY },
                    new int[]{ _positionX + 2, _positionY + 1 },
                    new int[]{ _positionX, _positionY + 3 },
                    new int[]{ _positionX + 1, _positionY + 3 },
                    new int[]{ _positionX + 2, _positionY + 3 },
                };
        }
    }
}
