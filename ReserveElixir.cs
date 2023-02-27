using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetColonie
{
    class ReserveElixir : Ressource
    {
        public int _stock { get; private set; }
        private int _capaciteMax;

        public ReserveElixir(int positionX, int positionY) : base(positionX, positionY)
        {
            _couleur = ConsoleColor.Magenta;
            _symbole = "$";
            _surface = 9;
            _stock = 0;
            _capaciteMax = 100;
            _cout = 10;
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
            };
        }

        public void Depenser(int cout)
        {
            if (_stock < cout)
                Console.WriteLine("Désolé, vous n'avez pas assez d'élixir pour effectuer cette dépense.");
            else
            {
                _stock -= cout;
                Console.WriteLine("Vous avez dépensé {0} elixirs.", cout);
            }
        }

        public void Crediter(int credit)
        {
            if (_capaciteMax - _stock >= credit)
                _stock += credit;
            else
                _stock = _capaciteMax;
        }
    }
}