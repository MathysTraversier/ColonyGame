using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetColonie
{
    abstract class BatimentEntrainement : Batiment
    {
        public BatimentEntrainement(int positionX, int positionY) : base(positionX, positionY) { }
    }
}