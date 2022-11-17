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
    /// Interaction logic for wndBattle.xaml
    /// </summary>
    public partial class wndBattle : Window 
    {
        Random random = new Random();
        Player hero;
        Enemy slime;
        public wndBattle()
        {
            InitializeComponent();
            Hero = new Player(5);
            slime = new Enemy(Hero.Level - 2);
        }

        public Player Hero { get => hero; set => hero = value; }
        public Enemy Slime { get => slime; set => slime = value; }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            int res = random.Next(0, 11);

            if (res == 10)
                tbLog.Text = "The enemy grabs you, you could'nt escape";
            else
                this.Close();
        }
    }
}
