using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetColonie
{
    class CampEntrainement : BatimentEntrainement
    {
        public int _capaciteMax { get; private set; }
        public List<Defenseur> _defenseurs { get; private set; }
        public CampEntrainement(int positionX, int positionY) : base(positionX, positionY)
        {
            _couleur = ConsoleColor.Green;
            _symbole = "#";
            _surface = 9;
            _capaciteMax = 9;
            _defenseurs = new List<Defenseur>();
            _cout = 7;
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

        public void AjouterDefenseur(Defenseur defenseur)
        {
            if(_defenseurs.Count() < _capaciteMax)
            {
                _defenseurs.Add(defenseur);
            }
            else
            {
                Console.WriteLine("Le camp est déjà plein. Vous ne pouvez pas y ajouter de défenseur.");
            }
        }

        public void RetirerDefenseur(Defenseur defenseur)
        {
            _defenseurs.Remove(defenseur);
        }
    }
}