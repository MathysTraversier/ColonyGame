using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetColonie
{
    abstract class Batiment
    {
        public ConsoleColor _couleur { get; protected set; }
        public string _symbole { get; protected set; }
        public int _surface { get; protected set; }
        public int[][] _positionsPlateau { get; protected set; }
        public int _positionX { get; private set; }
        public int _positionY { get; private set; }

        public int _cout { get; protected set; }
        public Batiment(int positionX, int positionY)
        { 
            _positionX = positionX;
            _positionY = positionY;
        }

        public void SetPosition(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
            if (_surface == 4)
            {
                _positionsPlateau[0] = new int[] {_positionX, _positionY};
                _positionsPlateau[1] = new int[] {_positionX + 1, _positionY};
                _positionsPlateau[2] = new int[] {_positionX, _positionY + 1};
                _positionsPlateau[3] = new int[] { _positionX + 1, _positionY + 1};
            }
            else if(_surface == 9)
            {
                _positionsPlateau[0] = new int[] { _positionX, _positionY };
                _positionsPlateau[1] = new int[] { _positionX + 1, _positionY };
                _positionsPlateau[2] = new int[] { _positionX, _positionY + 1 };
                _positionsPlateau[3] = new int[] { _positionX + 1, _positionY + 1 };
                _positionsPlateau[4] = new int[] { _positionX, _positionY + 2 };
                _positionsPlateau[5] = new int[] { _positionX + 1, _positionY + 2 };
                _positionsPlateau[6] = new int[] { _positionX + 2, _positionY + 2 };
                _positionsPlateau[7] = new int[] { _positionX + 2, _positionY };
                _positionsPlateau[8] = new int[] { _positionX + 2, _positionY + 1 };
            }
            else
            {
                _positionsPlateau[0] = new int[] { _positionX, _positionY };
                _positionsPlateau[1] = new int[] { _positionX + 1, _positionY };
                _positionsPlateau[2] = new int[] { _positionX, _positionY + 1 };
                _positionsPlateau[3] = new int[] { _positionX + 1, _positionY + 1 };
                _positionsPlateau[4] = new int[] { _positionX, _positionY + 2 };
                _positionsPlateau[5] = new int[] { _positionX + 1, _positionY + 2 };
                _positionsPlateau[6] = new int[] { _positionX + 2, _positionY + 2 };
                _positionsPlateau[7] = new int[] { _positionX + 2, _positionY };
                _positionsPlateau[8] = new int[] { _positionX + 2, _positionY + 1 };
                _positionsPlateau[9] = new int[] { _positionX, _positionY + 3 };
                _positionsPlateau[10] = new int[] { _positionX + 1, _positionY + 3 };
                _positionsPlateau[11] = new int[] { _positionX + 2, _positionY + 3 };
            }
        }

    }
}
