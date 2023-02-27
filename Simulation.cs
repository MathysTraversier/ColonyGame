using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjetColonie
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey consoleKey;
            do
            {
                Console.Clear();
                for (int i = 0; i < Console.WindowHeight / 2 - 5; i++)
                {
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("░█████╗░██╗░░░░░░█████╗░░██████╗██╗░░██╗  ░█████╗░███████╗  ███████╗███╗░░██╗░██████╗░█████╗░".Length / 2)) + "}", "░█████╗░██╗░░░░░░█████╗░░██████╗██╗░░██╗  ░█████╗░███████╗  ███████╗███╗░░██╗░██████╗░█████╗░"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("██╔══██╗██║░░░░░██╔══██╗██╔════╝██║░░██║  ██╔══██╗██╔════╝  ██╔════╝████╗░██║██╔════╝██╔══██╗".Length / 2)) + "}", "██╔══██╗██║░░░░░██╔══██╗██╔════╝██║░░██║  ██╔══██╗██╔════╝  ██╔════╝████╗░██║██╔════╝██╔══██╗"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("██║░░╚═╝██║░░░░░███████║╚█████╗░███████║  ██║░░██║█████╗░░  █████╗░░██╔██╗██║╚█████╗░██║░░╚═╝".Length / 2)) + "}", "██║░░╚═╝██║░░░░░███████║╚█████╗░███████║  ██║░░██║█████╗░░  █████╗░░██╔██╗██║╚█████╗░██║░░╚═╝"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("██║░░██╗██║░░░░░██╔══██║░╚═══██╗██╔══██║  ██║░░██║██╔══╝░░  ██╔══╝░░██║╚████║░╚═══██╗██║░░██╗".Length / 2)) + "}", "██║░░██╗██║░░░░░██╔══██║░╚═══██╗██╔══██║  ██║░░██║██╔══╝░░  ██╔══╝░░██║╚████║░╚═══██╗██║░░██╗"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("╚█████╔╝███████╗██║░░██║██████╔╝██║░░██║  ╚█████╔╝██║░░░░░  ███████╗██║░╚███║██████╔╝╚█████╔╝".Length / 2)) + "}", "╚█████╔╝███████╗██║░░██║██████╔╝██║░░██║  ╚█████╔╝██║░░░░░  ███████╗██║░╚███║██████╔╝╚█████╔╝"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("░╚════╝░╚══════╝╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝  ░╚════╝░╚═╝░░░░░  ╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░".Length / 2)) + "}", "░╚════╝░╚══════╝╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝  ░╚════╝░╚═╝░░░░░  ╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░"));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("[Menu]".Length / 2)) + "}", "[Menu]"));
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("[1] : Jouer".Length / 2)) + "}", "[1] : Jouer"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("[2] : Règles du jeu".Length / 2)) + "}", "[2] : Règles du jeu"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("[3] : Quitter".Length / 2)) + "}", "[3] : Quitter"));

                do
                {
                    consoleKey = Console.ReadKey().Key;
                } while (consoleKey != ConsoleKey.D1 && consoleKey != ConsoleKey.D2 && consoleKey != ConsoleKey.D3);

                if (consoleKey == ConsoleKey.D1)
                {
                    Monde M1 = new Monde();
                    HotelDeVille hotel = new HotelDeVille(10, 25);
                    ExtracteurElixir E1 = new ExtracteurElixir(6, 30);
                    ReserveElixir R1 = new ReserveElixir(13, 15);
                    R1.Crediter(25);
                    CampEntrainement camp = new CampEntrainement(13, 35);
                    Ouvrier O1 = new Ouvrier(10, 25);
                    Defenseur D1 = new Defenseur(13, 35);
                    M1.AjouterBatiment(hotel);
                    M1.AjouterBatiment(E1);
                    M1.AjouterBatiment(R1);
                    M1.AjouterBatiment(camp);
                    M1.AjouterPersonnage(O1);
                    M1.AjouterPersonnage(D1);
                    camp.AjouterDefenseur(D1);

                    int nbTours = 0;
                    int nbMaxEnnemis = 1;
                    bool verifEnnemi;

                    bool finDuJeu = false;
                    do
                    {
                        Console.Clear();
                        nbTours++;
                        M1.AjouterAleaEnnemis(nbTours, ref nbMaxEnnemis);
                        verifEnnemi = M1.VerifierEnnemi();
                        M1.AfficherMenuPrincipal();
                        M1.InitialiserPlateau();
                        M1.ToString();
                        M1.AfficherInfoPeronnages();

                        do
                        {
                            consoleKey = Console.ReadKey().Key;
                            if (consoleKey == ConsoleKey.Enter && !verifEnnemi)
                            {
                                Console.SetCursorPosition(60, 30);
                                Console.WriteLine("Il n'y a pas d'ennemi à attaquer...");
                            }
                        } while ((consoleKey != ConsoleKey.Enter || !verifEnnemi) && consoleKey != ConsoleKey.Spacebar && consoleKey != ConsoleKey.F && consoleKey != ConsoleKey.E);

                        Console.Clear();
                        if (consoleKey == ConsoleKey.Enter && verifEnnemi)
                        {
                            foreach (Personnage perso1 in M1._listPersonnages)
                            {
                                if (perso1 is Defenseur && perso1._PV > 0)
                                {
                                    Defenseur defenseur = (Defenseur)perso1;
                                    foreach (Personnage perso2 in M1._listPersonnages)
                                    {
                                        if (perso2 is Ennemi && perso2._PV > 0)
                                        {
                                            Ennemi ennemi = (Ennemi)perso2;
                                            defenseur.Defendre(M1, ennemi);
                                        }
                                    }
                                    if(!defenseur.EstDansCamp(M1))
                                        defenseur.RetourCamp(M1);
                                }
                            }
                            M1.SupprimerMorts();
                        }
                        else if (consoleKey == ConsoleKey.Spacebar)
                        {
                            M1.AfficherMenuConstruction();

                            do
                            {
                                consoleKey = Console.ReadKey().Key;
                            } while (consoleKey != ConsoleKey.Enter && consoleKey != ConsoleKey.Spacebar && consoleKey != ConsoleKey.R && consoleKey != ConsoleKey.E);

                            bool disponibilite = false;

                            foreach (Personnage perso in M1._listPersonnages)
                            {
                                if (perso is Ouvrier)
                                {
                                    Ouvrier O = (Ouvrier)perso;
                                    if (O._disponible)
                                    {
                                        disponibilite = true;
                                        bool placeDisponible = false;
                                        if (consoleKey == ConsoleKey.Enter)
                                            O.Construire(M1, new Caserne(18, 43));
                                        else if (consoleKey == ConsoleKey.Spacebar)
                                            O.Construire(M1, new CampEntrainement(18, 43));
                                        else if (consoleKey == ConsoleKey.R)
                                            O.Construire(M1, new ReserveElixir(18, 43));
                                        else
                                            O.Construire(M1, new ExtracteurElixir(18, 43));
                                        O.FatiguerOuvrier(4);
                                        Console.Clear();
                                        M1.AfficherInstructionsConstruction();
                                        M1.InitialiserPlateau();
                                        M1.ToString();
                                        ConsoleKey direction;
                                        do
                                        {
                                            do
                                            {
                                                direction = Console.ReadKey().Key;
                                            } while (direction != ConsoleKey.DownArrow && direction != ConsoleKey.UpArrow && direction != ConsoleKey.RightArrow && direction != ConsoleKey.LeftArrow && direction != ConsoleKey.Enter);
                                            if(direction != ConsoleKey.Enter)
                                            {
                                                try
                                                {
                                                    M1.ModifierDernierBatimentPosition(direction);
                                                }
                                                catch (InvalidCastException e)
                                                {
                                                    continue;
                                                }
                                            }
                                            placeDisponible = O.VerifierConstruction(M1, M1._listBatiments.Last());
                                            Console.Clear();
                                            M1.AfficherInstructionsConstruction();
                                            M1.InitialiserPlateau();
                                            M1.ToString();
                                        } while (!placeDisponible && direction != ConsoleKey.Enter);
                                        break;
                                    }
                                }
                            }
                            if (!disponibilite)
                                Console.WriteLine("Désolé, mais aucun ouvrier n'est disponible pour le moment.");
                        }
                        else if (consoleKey == ConsoleKey.F)
                        {
                            Console.Clear();
                            if (!M1.existeCaserne())
                            {
                                Console.WriteLine("Vous devez d'abord construire une caserne avant de former.");
                                ConsoleKey passer = Console.ReadKey().Key;
                                continue;
                            }
                            else if (M1.CompterStockReserve() < Defenseur._cout)
                            {
                                Console.WriteLine("Vous n'avez pas assez d'élixir pour former vos défenseurs.");
                                ConsoleKey passer = Console.ReadKey().Key;
                                continue;
                            }
                            else if (M1.estPleinCamp())
                            {
                                Console.WriteLine("Vous n'avez pas assez de place pour former vos défenseurs.");
                                ConsoleKey passer = Console.ReadKey().Key;
                                continue;
                            }
                            else
                            {
                                int nbDefenseurs;
                                do
                                {
                                    M1.AfficherRessources();
                                    Console.Write("Combien de défenseur voulez-vous former ({0} elixirs) : ", Defenseur._cout);
                                    nbDefenseurs = int.Parse(Console.ReadLine());
                                    if (M1.CompterStockReserve() < nbDefenseurs * Defenseur._cout)
                                        Console.WriteLine("Vous n'avez pas assez d'élixir pour former autant de défenseurs.");
                                    else if (M1.CompterStockCamp() + nbDefenseurs > M1.CompterCapaciteMaxCamp())
                                        Console.WriteLine("Vous n'avez pas assez de place pour former vos défenseurs.");
                                } while (M1.CompterStockReserve() < nbDefenseurs * Defenseur._cout || M1.CompterStockCamp() + nbDefenseurs > M1.CompterCapaciteMaxCamp());
                                foreach (Batiment bat in M1._listBatiments)
                                {
                                    if (bat is Caserne)
                                    {
                                        Caserne caserne = (Caserne)bat;
                                        foreach (Batiment campEntrainement in M1._listBatiments)
                                        {
                                            if (campEntrainement is CampEntrainement)
                                            {
                                                CampEntrainement campMilitaire = (CampEntrainement)campEntrainement;
                                                while (campMilitaire._defenseurs.Count() != campMilitaire._capaciteMax && nbDefenseurs != 0)
                                                {
                                                    caserne.Creer(M1, campMilitaire);
                                                    nbDefenseurs--;
                                                    Console.Clear();
                                                    M1.AfficherMenuPrincipal();
                                                    M1.InitialiserPlateau();
                                                    M1.ToString();
                                                    Thread.Sleep(1000);
                                                }
                                                if (nbDefenseurs == 0)
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            Thread.Sleep(2000);
                        }
                        else if (consoleKey == ConsoleKey.E)
                        {
                            if (O1._disponible)
                            {
                                foreach (Batiment bat in M1._listBatiments)
                                {
                                    if (bat is ExtracteurElixir)
                                    {
                                        ExtracteurElixir elixir = (ExtracteurElixir)bat;
                                        O1.seDeplacer(M1, bat._positionX, bat._positionY);
                                        O1.FatiguerOuvrier(2);
                                        elixir.Transferer(R1);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("L'ouvrier est épuisé, il doit dormir !");
                            }
                        }
                        if (consoleKey != ConsoleKey.E)
                        {
                            foreach (Batiment bat in M1._listBatiments)
                            {
                                if (bat is ExtracteurElixir)
                                {
                                    ExtracteurElixir extracteurElixir = (ExtracteurElixir)bat;
                                    extracteurElixir.Extraire();
                                }
                            }
                        }
                        O1.VerifierEtatOuvrir(M1);
                        finDuJeu = M1.IsGameOver();
                        if (finDuJeu)
                        {
                            Console.Clear();
                            Console.WriteLine("Vous n'avez plus assez de défenseur pour protéger votre village. Vous avez perdu !");
                            Console.WriteLine("Pressez un bouton pour passer...");
                            ConsoleKey fin = Console.ReadKey().Key;
                        }
                    }
                    while (!finDuJeu);
                }

                else if (consoleKey == ConsoleKey.D2)
                {
                    for (int i = 0; i < Console.WindowHeight / 2 - 5; i++)
                    {
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("░█████╗░██╗░░░░░░█████╗░░██████╗██╗░░██╗  ░█████╗░███████╗  ███████╗███╗░░██╗░██████╗░█████╗░".Length / 2)) + "}", "░█████╗░██╗░░░░░░█████╗░░██████╗██╗░░██╗  ░█████╗░███████╗  ███████╗███╗░░██╗░██████╗░█████╗░"));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("██╔══██╗██║░░░░░██╔══██╗██╔════╝██║░░██║  ██╔══██╗██╔════╝  ██╔════╝████╗░██║██╔════╝██╔══██╗".Length / 2)) + "}", "██╔══██╗██║░░░░░██╔══██╗██╔════╝██║░░██║  ██╔══██╗██╔════╝  ██╔════╝████╗░██║██╔════╝██╔══██╗"));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("██║░░╚═╝██║░░░░░███████║╚█████╗░███████║  ██║░░██║█████╗░░  █████╗░░██╔██╗██║╚█████╗░██║░░╚═╝".Length / 2)) + "}", "██║░░╚═╝██║░░░░░███████║╚█████╗░███████║  ██║░░██║█████╗░░  █████╗░░██╔██╗██║╚█████╗░██║░░╚═╝"));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("██║░░██╗██║░░░░░██╔══██║░╚═══██╗██╔══██║  ██║░░██║██╔══╝░░  ██╔══╝░░██║╚████║░╚═══██╗██║░░██╗".Length / 2)) + "}", "██║░░██╗██║░░░░░██╔══██║░╚═══██╗██╔══██║  ██║░░██║██╔══╝░░  ██╔══╝░░██║╚████║░╚═══██╗██║░░██╗"));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("╚█████╔╝███████╗██║░░██║██████╔╝██║░░██║  ╚█████╔╝██║░░░░░  ███████╗██║░╚███║██████╔╝╚█████╔╝".Length / 2)) + "}", "╚█████╔╝███████╗██║░░██║██████╔╝██║░░██║  ╚█████╔╝██║░░░░░  ███████╗██║░╚███║██████╔╝╚█████╔╝"));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("░╚════╝░╚══════╝╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝  ░╚════╝░╚═╝░░░░░  ╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░".Length / 2)) + "}", "░╚════╝░╚══════╝╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝  ░╚════╝░╚═╝░░░░░  ╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░"));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Règles du jeu".Length / 2)) + "}", "Règles du jeu"));
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Bienvenue dans Clash of ENSC ! Tu te demandes comment jouer ? Tu es au bon endroit !".Length / 2)) + "}", "Bienvenue dans Clash of ENSC ! Tu te demandes comment jouer ? Tu es au bon endroit !"));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Ton objectif est de développer ta colonie.".Length / 2)) + "}", "Ton objectif est de développer ta colonie."));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Pour cela, tu devras construire des bâtiments grâce à la ressource du jeu: l’élixir.".Length / 2)) + "}", "Pour cela, tu devras construire des bâtiments grâce à la ressource du jeu: l’élixir."));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Tu devras aussi former des défenseurs pour protéger ta colonie.En effet, des ennemis vont apparaître au fil du jeu.".Length / 2)) + "}", "Tu devras aussi former des défenseurs pour protéger ta colonie.En effet, des ennemis vont apparaître au fil du jeu."));
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Si leur nombre excède le double du nombre de colons, la partie est perdue!".Length / 2)) + "}", "Si leur nombre excède le double du nombre de colons, la partie est perdue!"));
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Les bâtiments :".Length / 2)) + "}", "Les bâtiments :"));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("@ Caserne : forme les défenseurs et en construire fait baisser le coût des défenseurs de 2".Length / 2)) + "}", "@ Caserne : forme les défenseurs et en construire fait baisser le coût des défenseurs de 2"));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("# Camp d'entraînement : stocke les défenseurs".Length / 2)) + "}", "# Camp d'entraînement : stocke les défenseurs"));
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("& Extracteur d’élixir : produit l'élixir".Length / 2)) + "}", "& Extracteur d’élixir : produit l'élixir"));
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("$ Réserve d’élixir : stocke l'élixir".Length / 2)) + "}", "$ Réserve d’élixir : stocke l'élixir"));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("X Hôtel de ville: lieu de repos de l’ouvrier".Length / 2)) + "}", "X Hôtel de ville: lieu de repos de l’ouvrier"));
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Les personnages :".Length / 2)) + "}", "Les personnages :"));
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("O L’ouvrier: construit les bâtiments".Length / 2)) + "}", "O L’ouvrier: construit les bâtiments"));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("D Défenseur: Attaque les ennemis".Length / 2)) + "}", "D Défenseur: Attaque les ennemis"));
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("E Ennemi: Menace la colonie".Length / 2)) + "}", "E Ennemi: Menace la colonie"));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("À toi de jouer !".Length / 2)) + "}", "À toi de jouer !"));
                    while (Console.ReadKey().Key != ConsoleKey.Enter && Console.ReadKey().Key != ConsoleKey.Spacebar) { }
                }

            } while (consoleKey != ConsoleKey.D3);
        }
    }
}
