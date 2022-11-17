using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHP
{
    public class Map
    {
        public const int DIMENSIONS_X = 10;
        public const int DIMENSIONS_Y = 10;

        Square[,] mapTiles = new Square[DIMENSIONS_X, DIMENSIONS_Y];
        Random random = new Random();

        public Map()
        {
            int resultat;
            bool hostile = false;
            for(int i = 0; i < DIMENSIONS_X; i++)
            {
                for(int j = 0; j < DIMENSIONS_Y; j++)
                {
                    resultat = random.Next(0, 10);
                    if(resultat >= 7)
                        hostile = true;
                    Square tempSquare = new Square(hostile);
                    MapTiles[i, j] = tempSquare;
                    hostile = false;
                }
            }
        }

        public Square[,] MapTiles { get => mapTiles; set => mapTiles = value; }
    }
}
