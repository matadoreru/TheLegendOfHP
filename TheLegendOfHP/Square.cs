using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHP
{
    public class Square
    {
        private bool hostile;

        public Square(bool hostile)
        {
            this.Hostile = hostile;
        }

        public bool Hostile { get => hostile; set => hostile = value; }
    }
}
