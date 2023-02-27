using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjetColonie
{
    abstract class Personnage
    {
        public int _PV { get; set; }
        public string _symbole { get; protected set; }
        public ConsoleColor _couleur { get; protected set; }
        public int _positionX { get; protected set; }
        public int _positionY { get; protected set; }


        public Personnage(int positionX, int positionY)
        { 
            _positionX = positionX;
            _positionY = positionY;
        }

        public void seDeplacer(Monde monde, int positionXcible, int positionYcible)
        {
            if (positionXcible < _positionX)
            {
                while (_positionX != positionXcible)
                {
                    monde._plateau[_positionX, _positionY] = null;
                    _positionX--;
                    monde._plateau[_positionX, _positionY] = _symbole;
                    Console.Clear();
                    monde.InitialiserPlateau();
                    monde.ToString();
                    Thread.Sleep(200);
                }

                if (positionYcible < _positionY)
                {
                    while (_positionY != positionYcible)
                    {
                        monde._plateau[_positionX, _positionY] = null;
                        _positionY--;
                        monde._plateau[_positionX, _positionY] = _symbole;
                        Console.Clear();
                        monde.InitialiserPlateau();
                        monde.ToString();
                        Thread.Sleep(200);
                    }
                }

                else
                {
                    while (_positionY != positionYcible)
                    {
                        monde._plateau[_positionX, _positionY] = null;
                        _positionY++;
                        monde._plateau[_positionX, _positionY] = _symbole;
                        Console.Clear();
                        monde.InitialiserPlateau();
                        monde.ToString();
                        Thread.Sleep(200);
                    }
                }
            }

            else
            {
                while (_positionX != positionXcible)
                {
                    monde._plateau[_positionX, _positionY] = null;
                    _positionX++;
                    monde._plateau[_positionX, _positionY] = _symbole;
                    Console.Clear();
                    monde.InitialiserPlateau();
                    monde.ToString();
                    Thread.Sleep(200);
                }

                if (positionYcible < _positionY)
                {
                    while (_positionY != positionYcible)
                    {
                        monde._plateau[_positionX, _positionY] = null;
                        _positionY--;
                        monde._plateau[_positionX, _positionY] = _symbole;
                        Console.Clear();
                        monde.InitialiserPlateau();
                        monde.ToString();
                        Thread.Sleep(200);
                    }
                }

                else
                {
                    while (_positionY != positionYcible)
                    {
                        monde._plateau[_positionX, _positionY] = null;
                        _positionY++;
                        monde._plateau[_positionX, _positionY] = _symbole;
                        Console.Clear();
                        monde.InitialiserPlateau();
                        monde.ToString();
                        Thread.Sleep(200);
                    }
                }
            }
        }

    }
}
