using System;
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
using WpfApp1.ViewModels;

namespace WpfApp1.Screens
{
    /// <summary>
    /// Interaction logic for Simulation.xaml
    /// </summary>
    public partial class Simulation : UserControl
    {
        public Simulation()
        {
            InitializeComponent();

        }

        private void BtnPerformSimulationClicked(object sender, RoutedEventArgs e)
        {
            
            Main.Content = new Screens.PerformSimulation();

        }

        private void BtnCheckSimulationWorkingClicked(object sender, RoutedEventArgs e)
        {

            Working.SimulationWorkingCode();
            Simulating.simultate();
            Main.Content = new Screens.SimulationWorking();
        }
    }
}
