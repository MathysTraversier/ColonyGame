using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetColonie
{
    class Defenseur : Personnage
    {
        public int _id { get; private set; }

        public static int _cout = 10;
        public int _pointsDegats { get; }
        private static int _compteur = 0;

        public Defenseur(int positionX, int positionY) : base(positionX, positionY) 
        {
            _compteur++;
            _id = _compteur;
            _pointsDegats = 3;
            _symbole = "D";
            _couleur = ConsoleColor.DarkCyan;
            _PV = 20;
        }

        public void Defendre(Monde monde, Ennemi ennemi)
        {
            if (ennemi._positionX==0)
            {
                this.seDeplacer(monde, ennemi._positionX+1, ennemi._positionY);
                do
                {
                    ennemi._PV -= _pointsDegats;
                    ennemi.attaquer(monde, this);
                }
                while (ennemi._PV > 0 && this._PV > 0);
            }
            else
            {
                this.seDeplacer(monde, ennemi._positionX - 1, ennemi._positionY);
                do
                {
                    ennemi._PV -= _pointsDegats;
                    ennemi.attaquer(monde, this);
                }
                while (ennemi._PV > 0 && _PV > 0);
            }
        }

        public bool EstDansCamp(Monde monde)
        {
            bool estDansCamp = false;
            foreach (Batiment bat in monde._listBatiments)
            {
                if (bat is CampEntrainement)
                {
                    for (int i = 0; i < bat._positionsPlateau.Length; i++)
                    {
                        if (bat._positionsPlateau[i][0] == _positionX && bat._positionsPlateau[i][1] == _positionY)
                        {
                            estDansCamp = true;
                        }
                    }
                }
            }
            return estDansCamp;
        }

        public void RetourCamp(Monde monde)
        {
            bool retourCamp = false;
            foreach (Batiment bat in monde._listBatiments)
            {
                if (bat is CampEntrainement)
                {
                    for(int i = 0; i < bat._positionsPlateau.Length; i++)
                    {
                        if (monde._plateau[bat._positionsPlateau[i][0], bat._positionsPlateau[i][1]] == "#")
                        {
                            this.seDeplacer(monde, bat._positionsPlateau[i][0], bat._positionsPlateau[i][1]);
                            retourCamp = true;
                            break;
                        }
                    }
                    if (retourCamp)
                        break;
                }
            }
        }



    }
}
