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
            if (e.Key == Key.S && posXPlayer + 1 < myGrid.RowDefinitions.Count)
            {
                MovePlayer(true,1);
                CheckTileType();
            }
            else if (e.Key == Key.W && posXPlayer - 1 >= 0)
            {
                MovePlayer(true, -1);
                CheckTileType();
            }
            else if (e.Key == Key.A && posYPlayer - 1 >= 0)
            {
                MovePlayer(false, -1);
                CheckTileType();
            }
            else if (e.Key == Key.D && posYPlayer + 1 < myGrid.ColumnDefinitions.Count)
            {
                MovePlayer(false, 1);
                CheckTileType();
            }
        }

        /// <summary>
        /// Mou el jugador a unes coordenades
        /// </summary>
        /// <param name="coordinateX">True --> X    False --> Y</param>
        /// <param name="move">Caselles que es mou (-/+ si no es posa 1 pot petar per estar fora de grid)</param>
        private void MovePlayer(bool coordinateX, int move)
        {
            if (coordinateX)
                posXPlayer += move;
            else
                posYPlayer += move;
            myGrid.Children.Remove(myGrid.Children[myGrid.Children.Count - 1]);
            PutPlayerOnGrid();
        }

        /// <summary>
        /// Mira si el jugador esta a una casella on pugui ocurrir alguna cosa
        /// </summary>
        private void CheckTileType()
        {
            if (map.MapTiles[posXPlayer, posYPlayer].TileType == TilesTypes.Mountains)
            {
                hero.HealthPoints--;
                playerHP.Value = hero.HealthPoints;
                playerHP.Maximum = hero.MaxHealthPoints;
                if (hero.HealthPoints <= 0)
                {
                    MessageBox.Show("You have been defeated. The land will wait for another hero to rise");
                    this.Close();
                }
            }
            else if (map.MapTiles[posXPlayer, posYPlayer].TileType == TilesTypes.DarkGrass && OccurBattle())
            {
                ThrowBattle();
                playerHP.Value = hero.HealthPoints;
                playerHP.Maximum = hero.MaxHealthPoints;
                if (hero.HealthPoints <= 0)
                {
                    MessageBox.Show("You have been defeated. The land will wait for another hero to rise");
                    this.Close();
                }     
            }
            else if (map.MapTiles[posXPlayer, posYPlayer].TileType == TilesTypes.Chest)
            {
                MessageBox.Show("You found a Potion of HP!");
                hero.NumberOfPotions++;
                tbNumberPotion.Text = "Number of potions: " + hero.NumberOfPotions;
            }
        }

        /// <summary>
        /// Llanca una batalla aleatoria
        /// </summary>
        private void ThrowBattle()
        {
            wndBattle wndBattle = new wndBattle(this);
            wndBattle.ShowDialog();
        }

        /// <summary>
        /// Mira si pot ocurrir una batalla amb un Random
        /// </summary>
        /// <returns>False --> No hi ha batalla True --> Hi ha batalla</returns>
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

        /// <summary>
        /// Coloca el jugador al grid corresponguent
        /// </summary>
        private void PutPlayerOnGrid()
        {
            Image player = new Image();
            Grid.SetRow(player, posXPlayer);
            Grid.SetColumn(player, posYPlayer);
            player.Source = new BitmapImage(new Uri("/Source/player.png", UriKind.Relative));
            player.Stretch = Stretch.Fill;
            myGrid.Children.Add(player);
        }

        /// <summary>
        /// Fa totes les Rows i Columns del grid
        /// </summary>
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

            Grid.SetRow(myGrid, 0);
            Grid.SetColumn(myGrid, 0);
            gridMap.Children.Add(myGrid);
            playerHP.Value = hero.HealthPoints;
            playerHP.Maximum = hero.MaxHealthPoints;
        }

        /// <summary>
        /// Coloca els tiles a les files i columnes aleatoriament
        /// </summary>
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
                    else if (map.MapTiles[i, j].TileType == TilesTypes.Mountains)
                        tile.Source = new BitmapImage(new Uri("/Source/mountain.png", UriKind.Relative));
                    else if (map.MapTiles[i, j].TileType == TilesTypes.Chest)
                        tile.Source = new BitmapImage(new Uri("/Source/chest.png", UriKind.Relative));

                    tile.Stretch = Stretch.Fill;
                    myGrid.Children.Add(tile);
                }
            }
            posXPlayer = random.Next(0, Map.DIMENSIONS_X);
            posYPlayer = random.Next(0, Map.DIMENSIONS_Y);
            PutPlayerOnGrid();
        }

        private void btnPotion_Click(object sender, RoutedEventArgs e)
        {
            if (hero.NumberOfPotions > 0 && hero.HealthPoints != hero.MaxHealthPoints)
            {
                hero.NumberOfPotions--;
                hero.HealthPoints = hero.MaxHealthPoints;
                tbNumberPotion.Text = "Number of potions: " + hero.NumberOfPotions;
                playerHP.Value = hero.HealthPoints;
                playerHP.Maximum = hero.MaxHealthPoints;
            }
            else if (hero.HealthPoints == hero.MaxHealthPoints)
                MessageBox.Show("You have already all of you HP!");
        }
    }
}
