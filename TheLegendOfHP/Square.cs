using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHP
{
    public enum TilesTypes { Grass, DarkGrass, Mountains, Chest}
    public class Square
    {
        private TilesTypes tileType;
        private bool collected;

        public Square(TilesTypes tileType)
        {
            this.tileType = tileType;
        }

        public TilesTypes TileType { get => tileType; set => tileType = value; }
        public bool Collected { get => collected; set => collected = value; }
    }
}
