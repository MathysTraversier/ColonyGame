using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetColonie
{
    internal class Monde
    {
        public List<Personnage> _listPersonnages { get; private set; }
        public List<Batiment> _listBatiments  { get; private set; }
        public string[,] _plateau { get; private set; }
        public ConsoleColor[,] _plateauColor { get; }

        public Monde()
        {
            _plateau = new string[22, 53];
            _plateauColor = new ConsoleColor[22, 53];
            _listPersonnages = new List<Personnage>();
            _listBatiments = new List<Batiment>();
        }

        public void AjouterPersonnage(Personnage P)
        {
            _listPersonnages.Add(P);
        }

        public void SupprimerPersonnage(Personnage P)
        {
            _listPersonnages.Remove(P);
        }

        public void AjouterBatiment(Batiment B)
        {
            _listBatiments.Add(B);
        }
        
        public void SupprimerBatiment(Batiment B)
        {
            _listBatiments.Remove(B);
        }

        public void InitialiserPlateau()
        {
            _plateau = new string[22, 53];
            foreach (Batiment batiment in _listBatiments)
            {
                for(int i = 0; i < batiment._positionsPlateau.Length; i++)
                {
                    _plateau[batiment._positionsPlateau[i][0], batiment._positionsPlateau[i][1]] = batiment._symbole;
                }
            }
            foreach (Batiment batiment in _listBatiments)
            {
                for (int i = 0; i < batiment._positionsPlateau.Length; i++)
                {
                    _plateauColor[batiment._positionsPlateau[i][0], batiment._positionsPlateau[i][1]] = batiment._couleur;
                }
            }
            foreach (Personnage personnage in _listPersonnages)
            {
                if(personnage._PV > 0)
                {
                    _plateau[personnage._positionX, personnage._positionY] = personnage._symbole;
                    _plateauColor[personnage._positionX, personnage._positionY] = personnage._couleur;
                }
            }
        }

        public new void ToString()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣");
            for(int i = 0; i < _plateau.GetLength(0); i++)
            {
                Console.Write("\n♣");
                for(int j = 0; j < _plateau.GetLength(1); j++)
                {
                    if (_plateau[i, j] != null)
                    {
                        Console.ForegroundColor = _plateauColor[i, j];
                        Console.Write(_plateau[i, j]);
                    }
                    else
                        Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("♣");
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣ ♣");
            Console.BackgroundColor= ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool existeCaserne()
        {
            bool existe = false;
            foreach(Batiment batiment in _listBatiments)
            {
                if(batiment is Caserne)
                    existe = true;
            }
            return existe;
        }

        public bool estCaseVide(int positionX, int positionY)
        {
            if (_plateau[positionX, positionY] == null)
                return true;
            else
                return false;
        }

        public void SupprimerMorts()
        {
            List<Personnage> _morts = new List<Personnage>();
            foreach(Personnage personnage in _listPersonnages)
            {
                if (personnage._PV <= 0)
                    _morts.Add(personnage);
            }
            foreach (Personnage personnage in _morts)
            {
                _listPersonnages.Remove(personnage);
            }
        }

        public bool estPleinCamp()
        {
            bool plein = false;
            int compteur = 0;
            int defenseur = 0;
            foreach(Batiment bat in _listBatiments)
            {
                if(bat is CampEntrainement)
                {
                    compteur++;
                    CampEntrainement entrainement = (CampEntrainement)bat;
                    defenseur += entrainement._defenseurs.Count();
                }
            }
            if (defenseur == compteur * 9)
                plein = true;
            return plein;
        }

        public int CompterCapaciteMaxCamp()
        {
            int capaciteMax = 0;
            foreach (Batiment bat in _listBatiments)
            {
                if (bat is CampEntrainement)
                {
                    CampEntrainement entrainement = (CampEntrainement)bat;
                    capaciteMax += entrainement._capaciteMax;
                }
            }
            return capaciteMax;
        }

        public int CompterStockCamp()
        {
            int stock = 0;
            foreach (Batiment bat in _listBatiments)
            {
                if (bat is CampEntrainement)
                {
                    CampEntrainement entrainement = (CampEntrainement)bat;
                    stock += entrainement._defenseurs.Count();
                }
            }
            return stock;
        }

        public int CompterStockReserve()
        {
            int elixir = 0;
            foreach(Batiment bat in _listBatiments)
            {
                if(bat is ReserveElixir)
                {
                    ReserveElixir reserveElixir = (ReserveElixir)bat;
                    elixir += reserveElixir._stock;
                }
            }
            return elixir;
        }

        public int CompterStockExtracteur()
        {
            int elixir = 0;
            foreach (Batiment bat in _listBatiments)
            {
                if (bat is ExtracteurElixir)
                {
                    ExtracteurElixir extracteurElixir = (ExtracteurElixir)bat;
                    elixir += extracteurElixir._stock;
                }
            }
            return elixir;
        }

        public void ModifierDernierBatimentPosition(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.UpArrow)
                _listBatiments.Last().SetPosition(_listBatiments.Last()._positionX - 1, _listBatiments.Last()._positionY);
            else if (consoleKey == ConsoleKey.DownArrow)
                _listBatiments.Last().SetPosition(_listBatiments.Last()._positionX + 1, _listBatiments.Last()._positionY);
            else if (consoleKey == ConsoleKey.LeftArrow)
                _listBatiments.Last().SetPosition(_listBatiments.Last()._positionX, _listBatiments.Last()._positionY - 1);
            else
                _listBatiments.Last().SetPosition(_listBatiments.Last()._positionX, _listBatiments.Last()._positionY + 1); ;
        }

        public void AjouterAleaEnnemis(int nbTours, ref int nbMaxEnnemis)
        {
            int nbEnnemis;
            Random alea = new Random();
            if (alea.Next(1,3) == 2 && nbTours != 1)
            {
                if (nbMaxEnnemis <= 10)
                    nbMaxEnnemis++;
                nbEnnemis = alea.Next(1, nbMaxEnnemis);
                for (int i = 1; i <= nbEnnemis; i++)
                {
                    int positionXEnnemi;
                    int positionYEnnemi;
                    do
                    {
                        positionXEnnemi = alea.Next(0, _plateau.GetLength(0));
                        positionYEnnemi = alea.Next(0, _plateau.GetLength(1));
                    } while (_plateau[positionXEnnemi, positionYEnnemi] != null);
                    AjouterPersonnage(new Ennemi(positionXEnnemi, positionYEnnemi));
                }
            }
        }

        public bool VerifierEnnemi()
        {
            bool presenceEnnemi = false;
            foreach(Personnage perso in _listPersonnages)
            {
                if(perso is Ennemi)
                {
                    presenceEnnemi = true;
                    break;
                }
            }
            return presenceEnnemi;
        }

        public void AfficherRessources()
        {
            string bords = "------------------------------------------------------";
            string reserve = "Réserves d'élixir : " + CompterStockReserve();

            Console.WriteLine(bords);
            Console.WriteLine();
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + (reserve.Length / 2)) + "}", reserve));
            Console.WriteLine();
            Console.WriteLine(bords);
            Console.WriteLine();
        }

        public void AfficherMenuPrincipal()
        {
            string bords = "------------------------------------------------------";
            string reserve = "Réserves d'élixir : " + CompterStockReserve();
            string extracteur = "Extracteurs d'élixir : " + CompterStockExtracteur();

            Console.Clear();
            Console.WriteLine(bords);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Ressources".Length / 2)) + "}", "Ressources"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + (reserve.Length / 2)) + "}", reserve));
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + (extracteur.Length / 2)) + "}", extracteur));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Commandes".Length / 2)) + "}", "Commandes"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Attaquer : Entrer".Length / 2)) + "}", "Attaquer : Entrer"));
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Construire : Espace".Length / 2)) + "}", "Construire : Espace"));
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Former : F".Length / 2)) + "}", "Former : F"));
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Extraire : E".Length / 2)) + "}", "Extraire : E"));
            Console.WriteLine();
            Console.WriteLine(bords);
            Console.WriteLine();
        }

        public void AfficherMenuConstruction()
        {
            string bords = "------------------------------------------------------";
            string reserve = "Réserves d'élixir : " + CompterStockReserve();

            Console.Clear();
            Console.WriteLine(bords);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Ressources".Length / 2)) + "}", "Ressources"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + (reserve.Length / 2)) + "}", reserve));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Que voulez-vous construire ?".Length / 2)) + "}", "Que voulez-vous construire ?"));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Caserne (4) : Entrer".Length / 2)) + "}", "Caserne (4) : Entrer"));
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Camp d'entraînement (7) : Espace".Length / 2)) + "}", "Camp d'entraînement (7) : Espace"));
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Réserve d'élixir (10) : R".Length / 2)) + "}", "Réserve d'élixir (10) : R"));
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Extracteur d'élixir (5) : E".Length / 2)) + "}", "Extracteur d'élixir (5) : E"));
            Console.WriteLine();
            Console.WriteLine(bords);
            Console.WriteLine();
        }

        public void AfficherInstructionsConstruction()
        {
            string bords = "------------------------------------------------------";

            Console.WriteLine(bords);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Instructions".Length / 2)) + "}", "Instructions"));
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Placez le bâtiment à l'aide des flèches directionnelles.".Length / 2)) + "}", "Placez le bâtiment à l'aide des flèches directionnelles."));
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Pressez [Entrer] pour valider la position.".Length / 2)) + "}", "Pressez [Entrer] pour valider la position."));
            Console.WriteLine();
            Console.WriteLine(bords);
            Console.WriteLine();
        }

        public void AfficherInfoPeronnages()
        {
            string bords = "------------------------------------------------------";
            int compteur = 14;

            Console.SetCursorPosition(60, compteur);
            Console.WriteLine(bords);
            Console.SetCursorPosition(60, compteur += 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("État des personnages".Length / 2)) + "}", "État des personnages"));
            Console.SetCursorPosition(60, compteur += 2);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Ouvrier".Length / 2)) + "}", "Ouvrier"));
            Console.SetCursorPosition(60, compteur+=2);
            Console.ForegroundColor = ConsoleColor.White;

            int pointsFatigue = 0;
            foreach(Personnage perso in _listPersonnages)
            {
                if(perso is Ouvrier)
                {
                    Ouvrier ouvrier = (Ouvrier)perso;
                    pointsFatigue = ouvrier._pointsFatigue;
                    break;
                }
            }
            string fatigue = "Points de fatigue : " + pointsFatigue;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + (fatigue.Length / 2)) + "}", fatigue));
            Console.SetCursorPosition(60, compteur+=2);

            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + ("Défenseurs".Length / 2)) + "}", "Défenseurs"));
            Console.SetCursorPosition(60, compteur+=2);
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Personnage perso in _listPersonnages)
            {
                if (perso is Defenseur)
                {
                    Defenseur defenseur = (Defenseur)perso;
                    string PV = "PV défenseur " + defenseur._id + " : " + defenseur._PV;
                    Console.SetCursorPosition(60, compteur++);
                    Console.WriteLine(String.Format("{0," + ((bords.Length / 2) + (PV.Length / 2)) + "}", PV));
                }
            }
            Console.SetCursorPosition(60, compteur+=1);
            Console.WriteLine(bords);
            Console.SetCursorPosition(60, compteur += 2);
        }

        public bool IsGameOver()
        {
            bool isGameOver = false;
            int compteurDefenseur = 0;
            int compteurEnnemi = 0;
            for (int i = 0; i < _listPersonnages.Count(); i++)
            {
                if (_listPersonnages[i] is Defenseur)
                    compteurDefenseur++;
                else if( _listPersonnages[i] is Ennemi)
                    compteurEnnemi++;
            }
            if (compteurEnnemi >= 2 * compteurDefenseur)
                isGameOver = true;
            return isGameOver;
        }
    }
}
