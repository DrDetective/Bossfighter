using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Schema;

namespace Bossfighter
{
    /// <summary>
    /// Interakční logika pro Boss.xaml
    /// </summary>
    public partial class Boss : Window
    {
        Data info = new Data();
        Random rng = new Random();
        public Boss()
        {
            InitializeComponent();
            EnName.Content = info.EnNames[0];
            plName.Content = Data.playerName;
            plHealth.Content = $"HP: {info.HP}";
            plDamage.Content = $"DMG: {info.Damage}";
            plDefence.Content = $"DEF: {info.Def}";
            enHealth.Content = $"HP: {info.HP_ENEMY}";
            enDamage.Content = $"DMG: {info.Damage_ENEMY}";
            enDefence.Content = $"DEF: {info.Def_Enemy}";
        }
        private void plATT_Click(object sender, RoutedEventArgs e) //50% chance attack from enemy
        {
            if (info.HP_ENEMY == 0) { return; }
            else if (info.HP_ENEMY < info.Damage) { info.HP_ENEMY = 0; autoUpdate(); return; }
            int RNG = rng.Next(0, 100);
            if (RNG >= 50)
            {
                info.HP -= info.Damage_ENEMY;
                info.HP_ENEMY -= info.Damage;
            }
            else { info.HP_ENEMY -= info.Damage; }
            autoUpdate();
        }

        private void plDEF_Click(object sender, RoutedEventArgs e) //80% chance of success / 20% chance of fail
        {
            int RNG = rng.Next(0, 100);
            if (RNG >= 20)
            {
                info.HP += info.Heal;
            } //success + heal/parry
            else { info.HP -= info.Damage_ENEMY; } //fail
            autoUpdate();
        }

        private void plHEAL_Click(object sender, RoutedEventArgs e) //90% chance of success / 10% chance of fail
        {
            int RNG = rng.Next(0, 100);
            if (RNG >= 90)
            {
                info.HP += info.Heal;
            } //success
            else { info.HP -= info.Damage_ENEMY; } //fail
            autoUpdate();
        }

        private void NextBoss_Click(object sender, RoutedEventArgs e)
        {
            if (info.HP_ENEMY > 0) { MessageBox.Show("Ještě jsi nezabil enemáka"); }
            else if (info.HP_ENEMY == 0)
            {
                info.round++;
                switch (info.round)
                {
                    case 1:
                        jelly.Visibility = Visibility.Hidden;
                        svab.Visibility = Visibility.Visible;
                        EnName.Content = info.EnNames[1];
                        info.HP_ENEMY = 125;
                        info.Damage_ENEMY = 15;
                        //PLayer
                        info.Damage = 15;
                        info.Heal = 15;
                        break;
                    case 2:
                        svab.Visibility = Visibility.Hidden;
                        scoobs.Visibility = Visibility.Visible;
                        EnName.Content = info.EnNames[2];
                        EnName.Foreground = new SolidColorBrush(Colors.Orange);
                        info.HP_ENEMY = 135;
                        info.Damage_ENEMY = 20;
                        //Player
                        info.Damage = 20;
                        info.Heal = 20;
                        break;
                    case 3:
                        scoobs.Visibility = Visibility.Hidden;
                        boss.Visibility = Visibility.Visible;
                        EnName.Content = info.EnNames[3];
                        EnName.Foreground = new SolidColorBrush(Colors.Red);
                        info.HP_ENEMY = 170;
                        info.Damage_ENEMY = 25;
                        //Player
                        info.Damage = 25;
                        break;
                    case 4:
                        MessageBox.Show("Dostal jses přes bosse a mohl jsi utéct z dungeonu");
                        this.Close();
                        break;
                }
                autoUpdate();
            }
        }
        private void autoUpdate()
        {
            plHealth.Content = $"HP: {info.HP}";
            plDamage.Content = $"DMG: {info.Damage}";
            plDefence.Content = $"DEF: {info.Def}";
            enHealth.Content = $"HP: {info.HP_ENEMY}";
            enDamage.Content = $"DMG: {info.Damage_ENEMY}";
            enDefence.Content = $"DEF: {info.Def_Enemy}";
            if (info.HP <= 0) { MessageBox.Show($"Bohužel {info.EnNames[info.round]} tě zabil"); this.Close(); }
            else if (info.HP_ENEMY == 0) { MessageBox.Show($"Zabil jsi {info.EnNames[info.round]}, můžeš pokračovat dál"); }
        }
    }
}
