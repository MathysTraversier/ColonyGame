using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetColonie
{
    abstract class Ressource : Batiment
    {

        public Ressource(int positionX, int positionY) : base(positionX, positionY) { }
    }
}