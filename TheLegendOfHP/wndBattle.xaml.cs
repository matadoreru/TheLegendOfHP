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

        Random r = new Random();
        public wndBattle()
        {
            InitializeComponent();
            hero = new Player(5);
            slime = new Enemy(r.Next(1, hero.Level-1));
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {

            if(slime.Velocity > hero.Velocity) {
                //You scratch the enemy, you make a total of 50 damage
                tbLog.Text = "The enemy has tackled, he made you a total of " + hero.substracHealth(slime.Dmg) + "damage";
                if (!hero.IsAlive) PartidaPerduda();
                tbLog.Text = "You scratch the enemy, you make a total of " + slime.substracHealth(hero.Dmg) + "damage";
                if (!slime.IsAlive) PartidaGuanyada();
            }
            else
            {
                tbLog.Text = "You scratch the enemy, you make a total of " + slime.substracHealth(hero.Dmg) + "damage";
                if (!slime.IsAlive) PartidaGuanyada();
                tbLog.Text = "The enemy has tackled, he made you a total of " + hero.substracHealth(slime.Dmg) + "damage";
                if (!hero.IsAlive) PartidaPerduda();
                
            }
        }



        public void PartidaGuanyada()
        {
            MessageBox.Show("You killed the enemy", "Announcement", MessageBoxButton.OK);
            this.Close();

        }

        public void PartidaPerduda()
        {
            MessageBox.Show("You have been killed by the enemy", "Announcement", MessageBoxButton.OK);
            this.Close();

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
