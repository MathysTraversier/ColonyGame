using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetColonie
{
    class Caserne : BatimentEntrainement
    {
        public Caserne(int positionX, int positionY) : base(positionX, positionY)
        {
            _couleur = ConsoleColor.Red;
            _surface = 4;
            _symbole = "@";
            _cout = 4;
            _positionsPlateau = new int[][]
            {
                new int[] { _positionX, _positionY },
                new int[] { _positionX + 1, _positionY },
                new int[]{ _positionX, _positionY + 1 },
                new int[]{ _positionX + 1, _positionY + 1 },
            };
        }

        public void Creer(Monde monde, CampEntrainement camp)
        {
            foreach (Batiment bat in monde._listBatiments)
            {
                int compteur = Defenseur._cout;
                if (bat is ReserveElixir)
                {
                    ReserveElixir reserveElixir = (ReserveElixir)bat;
                    if (reserveElixir._stock >= compteur)
                    {
                        reserveElixir.Depenser(compteur);
                        break;
                    }
                    else
                    {
                        compteur -= reserveElixir._stock;
                        reserveElixir.Depenser(reserveElixir._stock);
                    }
                }
            }
            Defenseur defenseur = new Defenseur(_positionX, _positionY);
            monde.AjouterPersonnage(defenseur);
            Console.Clear();
            monde.InitialiserPlateau();
            monde.ToString();
            if (monde._plateau[camp._positionX, camp._positionY] == camp._symbole)
                defenseur.seDeplacer(monde, camp._positionX, camp._positionY);
            else if (monde._plateau[camp._positionX, camp._positionY + 1] == camp._symbole)
                defenseur.seDeplacer(monde, camp._positionX, camp._positionY + 1);
            else if (monde._plateau[camp._positionX, camp._positionY + 2] == camp._symbole)
                defenseur.seDeplacer(monde, camp._positionX, camp._positionY + 2);
            else if (monde._plateau[camp._positionX + 1, camp._positionY] == camp._symbole)
                defenseur.seDeplacer(monde, camp._positionX + 1, camp._positionY);
            else if (monde._plateau[camp._positionX + 1, camp._positionY + 1] == camp._symbole)
                defenseur.seDeplacer(monde, camp._positionX + 1, camp._positionY + 1);
            else if (monde._plateau[camp._positionX + 1, camp._positionY + 2] == camp._symbole)
                defenseur.seDeplacer(monde, camp._positionX + 1, camp._positionY + 2);
            else if (monde._plateau[camp._positionX + 2, camp._positionY] == camp._symbole)
                defenseur.seDeplacer(monde, camp._positionX + 2, camp._positionY);
            else if (monde._plateau[camp._positionX + 2, camp._positionY + 1] == camp._symbole)
                defenseur.seDeplacer(monde, camp._positionX + 2, camp._positionY + 1);
            else
                defenseur.seDeplacer(monde, camp._positionX + 2, camp._positionY + 2);
            camp.AjouterDefenseur(defenseur);
        }
    }
}