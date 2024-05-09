using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bossfighter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (PlName.Text != "") { Data.playerName = PlName.Text.ToString(); }
            else { Data.playerName = "Player"; }
            Boss bossWin = new Boss();
            bossWin.Show();
            this.Close();
        }
        private void btn_KeyDown(object sender, KeyEventArgs e) { if (e.Key == Key.Enter) { btnStart_Click((object)sender, e); } }
    }
}
