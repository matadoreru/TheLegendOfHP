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
        public wndBattle()
        {
            InitializeComponent();
        }

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
