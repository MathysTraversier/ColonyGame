using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetColonie
{
    class ExtracteurElixir : Ressource
    {
        public int _stock { get; private set; }
        private int _capaciteMax;

        public ExtracteurElixir(int positionX, int positionY) : base(positionX, positionY)
        {
            _couleur = ConsoleColor.DarkMagenta;
            _symbole = "&";
            _surface = 4;
            _stock = 0;
            _capaciteMax = 25;
            _cout = 5;
            _positionsPlateau = new int[][]
            {
                new int[] { _positionX, _positionY },
                new int[] { _positionX + 1, _positionY },
                new int[]{ _positionX, _positionY + 1 },
                new int[]{ _positionX + 1, _positionY + 1 },
            };
        }

        public void Transferer(ReserveElixir R)
        {
            R.Crediter(this._stock);
            this._stock = 0;
        }

        public void Extraire()
        {
            if (this._stock <= this._capaciteMax - 2)
                _stock += 2;
            else if (this._stock == this._capaciteMax - 1)
                _stock++;
        }
    }
}