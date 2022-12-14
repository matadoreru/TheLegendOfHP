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
            TilesTypes tileType = TilesTypes.Grass;
            for(int i = 0; i < DIMENSIONS_X; i++)
            {
                for(int j = 0; j < DIMENSIONS_Y; j++)
                {
                    resultat = random.Next(0, 101);
                    if(resultat >= 51 && resultat <= 85)
                        tileType = TilesTypes.DarkGrass;
                    else if(resultat >= 86 && resultat <= 98)
                        tileType = TilesTypes.Mountains;
                    else if(resultat == 100)
                        tileType = TilesTypes.Chest;
                    Square tempSquare = new Square(tileType);
                    MapTiles[i, j] = tempSquare;
                    tileType = TilesTypes.Grass;
                }
            }
        }

        public Square[,] MapTiles { get => mapTiles; set => mapTiles = value; }
    }
}
