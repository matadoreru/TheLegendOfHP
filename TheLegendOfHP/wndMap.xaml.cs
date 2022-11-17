using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TheLegendOfHP
{
    /// <summary>
    /// Interaction logic for wndMap.xaml
    /// </summary>
    public partial class wndMap : Window
    {
        Grid myGrid = new Grid();
        Map map = new Map();
        Random random = new Random();
        Player hero = new Player(5);

        // Emprar class player .pos
        int posXPlayer;
        int posYPlayer;

        public Player Hero { get => hero; set => hero = value; }

        public wndMap()
        {
            InitializeComponent();
            MakeGrid();
            PutTiles();

            this.KeyDown += WndMap_KeyDown;
        }

        /// <summary>
        /// Moviment del jugador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WndMap_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.S && posXPlayer + 1 < myGrid.RowDefinitions.Count && map.MapTiles[posXPlayer + 1,posYPlayer].TileType != TilesTypes.Mountains)
            {
                myGrid.Children.Remove(myGrid.Children[myGrid.Children.Count - 1]);
                posXPlayer++;
                PutPlayer();
                if(OccurBattle())
                    ThrowBattle();
            }
            else if (e.Key == Key.W && posXPlayer - 1 >= 0 && map.MapTiles[posXPlayer - 1, posYPlayer].TileType != TilesTypes.Mountains)
            {
                myGrid.Children.Remove(myGrid.Children[myGrid.Children.Count - 1]);
                posXPlayer--;
                PutPlayer();
                if (OccurBattle())
                    ThrowBattle();
            }
            else if (e.Key == Key.A && posYPlayer - 1 >= 0 && map.MapTiles[posXPlayer, posYPlayer - 1].TileType != TilesTypes.Mountains)
            {
                myGrid.Children.Remove(myGrid.Children[myGrid.Children.Count - 1]);
                posYPlayer--;
                PutPlayer();
                if (OccurBattle())
                    ThrowBattle();
            }
            else if (e.Key == Key.D && posYPlayer + 1 < myGrid.ColumnDefinitions.Count && map.MapTiles[posXPlayer, posYPlayer + 1].TileType != TilesTypes.Mountains)
            {
                myGrid.Children.Remove(myGrid.Children[myGrid.Children.Count - 1]);
                posYPlayer++;
                PutPlayer();
                if (OccurBattle())
                    ThrowBattle();
            }
        }

        private void ThrowBattle()
        {
            wndBattle wndBattle = new wndBattle(this);
            wndBattle.ShowDialog();
        }

        private bool OccurBattle()
        {
            bool battle = false;
            if(map.MapTiles[posXPlayer,posYPlayer].TileType == TilesTypes.DarkGrass)
            {
                if (random.Next(0, 6) == 5)
                    battle = true;
            }
            return battle;
        }

        private void PutPlayer()
        {
            Image player = new Image();
            Grid.SetRow(player, posXPlayer);
            Grid.SetColumn(player, posYPlayer);
            player.Source = new BitmapImage(new Uri("/Source/player.png", UriKind.Relative));
            player.Stretch = Stretch.Fill;
            myGrid.Children.Add(player);
        }

        private void MakeGrid()
        {
            // Color columns
            for (int i = 0; i < Map.DIMENSIONS_Y; i++)
            {
                ColumnDefinition colTemp = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colTemp);
            }

            // Color rows
            for (int i = 0; i < Map.DIMENSIONS_X; i++)
            {
                RowDefinition rowTemp = new RowDefinition();
                myGrid.RowDefinitions.Add(rowTemp);
            }
            this.Content = myGrid;
        }

        private void PutTiles()
        {
            for (int i = 0; i < Map.DIMENSIONS_X; i++)
            {
                for (int j = 0; j < Map.DIMENSIONS_Y; j++)
                {
                    Image tile = new Image();
                    Grid.SetRow(tile, i);
                    Grid.SetColumn(tile, j);
                    if (map.MapTiles[i, j].TileType == TilesTypes.Grass)
                        tile.Source = new BitmapImage(new Uri("/Source/grass.png", UriKind.Relative));
                    else if (map.MapTiles[i, j].TileType == TilesTypes.DarkGrass)
                        tile.Source = new BitmapImage(new Uri("/Source/grassHostile.png", UriKind.Relative));
                    else
                        tile.Source = new BitmapImage(new Uri("/Source/mountain.png", UriKind.Relative));

                    tile.Stretch = Stretch.Fill;
                    myGrid.Children.Add(tile);
                }
            }
            posXPlayer = random.Next(0, Map.DIMENSIONS_X);
            posYPlayer = random.Next(0, Map.DIMENSIONS_Y);
            PutPlayer();
        }
    }
}
