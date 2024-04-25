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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bossfighter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Data info = new Data();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Boss bossWin = new Boss();
            if (info.Name == "") { MessageBox.Show("Zadej svoje jméno"); }
            else { info.Name = PlName.Text; this.Close(); bossWin.Show(); }
        }
        private void btn_KeyDown(object sender, KeyEventArgs e) { if(e.Key == Key.Enter) { btnStart_Click((object)sender, e); } }
    }
}
