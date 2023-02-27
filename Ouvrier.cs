using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjetColonie
{
    class Ouvrier : Personnage
    {
        public bool _disponible { get; private set; }
        public int _pointsFatigue { get; private set; }

        public Ouvrier (int positionX, int positionY) : base (positionX, positionY) 
        {
            _symbole = "O";
            _couleur = ConsoleColor.DarkYellow;
            _PV = 30;
            _pointsFatigue = 0;
            _disponible = true;
        }

        public void FatiguerOuvrier(int fatigue)
        {
            _pointsFatigue += fatigue;
        }

        public void VerifierEtatOuvrir(Monde monde)
        {
            if (!_disponible)
            {
                if (_pointsFatigue < 10)
                {
                    string reveil;
                    do
                    {
                        Console.Write("Voulez-vous réveiller l'ouvrier (oui ou non) : ");
                        reveil = Console.ReadLine().ToLower();
                        if (reveil != "oui" && reveil != "non")
                            Console.WriteLine("Je n'ai pas compris.");
                    } while (reveil != "oui" && reveil != "non");
                    if (reveil == "oui")
                        _disponible = true;
                }
                _pointsFatigue -= 3;
            }
            else
            {
                if(_pointsFatigue >= 10) 
                {
                    int X = 0;
                    int Y = 0;
                    foreach(Batiment bat in monde._listBatiments)
                    {
                        if(bat is HotelDeVille)
                        {
                            X = bat._positionX;
                            Y = bat._positionY;
                            break;
                        }
                    }
                    this.seDeplacer(monde, X, Y);
                    _disponible = false;
                }
            }
        }
        public bool VerifierConstruction(Monde monde, Batiment batiment)
        {
            bool verification = true;
            if (batiment._surface == 4)
            {
                if(monde._plateau[batiment._positionX, batiment._positionY] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX, batiment._positionY + 1] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX + 1, batiment._positionY] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX + 1, batiment._positionY + 1] != null)
                    verification = false;
            }
            else
            {
                if (monde._plateau[batiment._positionX, batiment._positionY] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX, batiment._positionY + 1] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX + 1, batiment._positionY] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX + 1, batiment._positionY + 1] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX, batiment._positionY + 2] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX + 2, batiment._positionY] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX + 1, batiment._positionY + 2] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX + 2, batiment._positionY + 1] != null)
                    verification = false;
                if (monde._plateau[batiment._positionX + 2, batiment._positionY + 2] != null)
                    verification = false;
            }
            if (!verification)
                Console.WriteLine("Il n'y a pas assez de place pour construire ce bâtiment à cet endroit !");
            return verification;
        }

        public void Construire(Monde monde, Batiment batiment)
        {
            if (batiment is Caserne && Defenseur._cout > 2)
                Defenseur._cout -= 2;
            if (monde.CompterStockReserve() > batiment._cout)
            {
                monde.AjouterBatiment(batiment);
                foreach(Batiment bat in monde._listBatiments)
                {
                    int compteur = batiment._cout;
                    if(bat is ReserveElixir)
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
            }
            else
                Console.WriteLine("Vous n'avez pas assez d'élixir pour construire cette ressource");  
        }



    }
}
