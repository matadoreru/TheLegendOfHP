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

        int posXPlayer;
        int posYPlayer;

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

            if (e.Key == Key.S && posXPlayer + 1 < myGrid.RowDefinitions.Count)
            {
                myGrid.Children.Remove(myGrid.Children[myGrid.Children.Count - 1]);
                posXPlayer++;
                Image player = new Image();
                Grid.SetRow(player, posXPlayer);
                Grid.SetColumn(player, posYPlayer);
                player.Source = new BitmapImage(new Uri("/Source/player.png", UriKind.Relative));
                player.Stretch = Stretch.Fill;
                myGrid.Children.Add(player);
            }
            else if (e.Key == Key.W && posXPlayer - 1 >= 0)
            {
                myGrid.Children.Remove(myGrid.Children[myGrid.Children.Count - 1]);
                posXPlayer--;
                Image player = new Image();
                Grid.SetRow(player, posXPlayer);
                Grid.SetColumn(player, posYPlayer);
                player.Source = new BitmapImage(new Uri("/Source/player.png", UriKind.Relative));
                player.Stretch = Stretch.Fill;
                myGrid.Children.Add(player);
            }
            else if (e.Key == Key.A && posYPlayer - 1 >= 0)
            {
                myGrid.Children.Remove(myGrid.Children[myGrid.Children.Count - 1]);
                posYPlayer--;
                Image player = new Image();
                Grid.SetRow(player, posXPlayer);
                Grid.SetColumn(player, posYPlayer);
                player.Source = new BitmapImage(new Uri("/Source/player.png", UriKind.Relative));
                player.Stretch = Stretch.Fill;
                myGrid.Children.Add(player);
            }
            else if (e.Key == Key.D && posYPlayer + 1 < myGrid.ColumnDefinitions.Count)
            {
                myGrid.Children.Remove(myGrid.Children[myGrid.Children.Count - 1]);
                posYPlayer++;
                Image player = new Image();
                Grid.SetRow(player, posXPlayer);
                Grid.SetColumn(player, posYPlayer);
                player.Source = new BitmapImage(new Uri("/Source/player.png", UriKind.Relative));
                player.Stretch = Stretch.Fill;
                myGrid.Children.Add(player);
            }
        }

        private void MakeGrid()
        {
            myGrid.ShowGridLines = true;

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
                    if (!map.MapTiles[i, j].Hostile)
                        tile.Source = new BitmapImage(new Uri("/Source/grass.png", UriKind.Relative));
                    else
                        tile.Source = new BitmapImage(new Uri("/Source/grassHostile.png", UriKind.Relative));
                    tile.Stretch = Stretch.Fill;
                    myGrid.Children.Add(tile);
                }
            }
            Image player = new Image();
            posXPlayer = random.Next(0, Map.DIMENSIONS_X);
            posYPlayer = random.Next(0, Map.DIMENSIONS_Y);

            Grid.SetRow(player, posXPlayer);
            Grid.SetColumn(player, posYPlayer);
            player.Source = new BitmapImage(new Uri("/Source/player.png", UriKind.Relative));
            player.Stretch = Stretch.Fill;
            myGrid.Children.Add(player);

        }
    }
}
