using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetColonie
{
    class Ennemi : Personnage 
    {
        public int _pointsDegats { get; }


        public Ennemi(int positionX, int positionY) : base(positionX, positionY)
        {
            _pointsDegats = 2;
            _symbole = "E";
            _couleur = ConsoleColor.DarkRed;
            _PV = 10 ;
        }

        public void attaquer(Monde monde, Defenseur defenseur)
        {
            defenseur._PV -= this._pointsDegats;
        }
    }
}
