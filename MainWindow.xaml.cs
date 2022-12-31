﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models.Cache;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cache m_cacheInstance = Cache.GetCache;
        public MainWindow()
        {
            InitializeComponent();
            m_cacheInstance.DeSerializeXMLFiles();
            btnAddData.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

        }

        private void BtnAddDataClicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new Screens.AddData();
        }

        private void BtnSimulationClicked(object sender, RoutedEventArgs e)
        {
            Working.SimulationWorkingCode();
            Main.Content = new Screens.Simulation();

        }
    }
}
