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
        public wndBattle(wndMap wnMap)
        {
            InitializeComponent();
            hero = wnMap.Hero;
            slime = new Enemy(r.Next(1, hero.Level - 1));
            enemyHP.Value = slime.HealthPoints;
            enemyHP.Maximum = slime.MaxHealthPoints;
            playerHP.Value = hero.HealthPoints;
            playerHP.Maximum = hero.MaxHealthPoints;
        }

        public Player Hero { get => hero; set => hero = value; }
        public Enemy Slime { get => slime; set => slime = value; }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            if (slime.Velocity > hero.Velocity) {
                tbLog.Text = "The enemy has tackled, he made you a total of " + hero.substracHealth(slime.Dmg) + "damage";
                if (!hero.IsAlive)
                {
                    enemyHP.Value = slime.HealthPoints;
                    enemyHP.Maximum = slime.MaxHealthPoints;
                    playerHP.Value = hero.HealthPoints;
                    playerHP.Maximum = hero.MaxHealthPoints;
                    PartidaPerduda();
                }
                else
                {
                    tbLog.Text = "You scratch the enemy, you make a total of " + slime.substracHealth(hero.Dmg) + "damage";
                    if (!slime.IsAlive)
                    {
                        enemyHP.Value = slime.HealthPoints;
                        enemyHP.Maximum = slime.MaxHealthPoints;
                        playerHP.Value = hero.HealthPoints;
                        playerHP.Maximum = hero.MaxHealthPoints;
                        PartidaGuanyada();
                        hero.NEnemysDefeat++;
                        if (hero.NEnemysDefeat == 5)
                            MessageBox.Show("You have defeated the Demon King's minions.\n" +
                                "You Win!\n" +
                                "You can keep playing as long as you want!");
                    }
                    else
                    {
                        enemyHP.Value = slime.HealthPoints;
                        enemyHP.Maximum = slime.MaxHealthPoints;
                        playerHP.Value = hero.HealthPoints;
                        playerHP.Maximum = hero.MaxHealthPoints;
                    }
                }
            }
            else
            {
                tbLog.Text = "You scratch the enemy, you make a total of " + slime.substracHealth(hero.Dmg) + "damage";
                if (!slime.IsAlive) 
                {
                    enemyHP.Value = slime.HealthPoints;
                    enemyHP.Maximum = slime.MaxHealthPoints;
                    playerHP.Value = hero.HealthPoints;
                    playerHP.Maximum = hero.MaxHealthPoints;
                    PartidaGuanyada();
                    hero.NEnemysDefeat++;
                    if (hero.NEnemysDefeat == 5)
                        MessageBox.Show("You have defeated the Demon King's minions.\n" +
                            "You Win!\n" +
                            "You can keep playing as long as you want!");
                }
                else
                {
                    tbLog.Text = "The enemy has tackled, he made you a total of " + hero.substracHealth(slime.Dmg) + "damage";
                    if (!hero.IsAlive)
                    {
                        enemyHP.Value = slime.HealthPoints;
                        enemyHP.Maximum = slime.MaxHealthPoints;
                        playerHP.Value = hero.HealthPoints;
                        playerHP.Maximum = hero.MaxHealthPoints;
                        PartidaPerduda();
                    }
                    else
                    {
                        enemyHP.Value = slime.HealthPoints;
                        enemyHP.Maximum = slime.MaxHealthPoints;
                        playerHP.Value = hero.HealthPoints;
                        playerHP.Maximum = hero.MaxHealthPoints;
                    }
                }          
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
