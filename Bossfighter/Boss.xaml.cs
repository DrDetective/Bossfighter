﻿using System;
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

namespace Bossfighter
{
    /// <summary>
    /// Interakční logika pro Boss.xaml
    /// </summary>
    public partial class Boss : Window
    {
        Data info = new Data();
        public Boss()
        {
            InitializeComponent();
            //plName.Content = info.Name;
            this.Content = plName;
        }
    }
}
