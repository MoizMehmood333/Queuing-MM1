using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp1.Models.Cache;
using WpfApp1.Models.Repository;
using WpfApp1.ViewModels;

namespace WpfApp1.Screens
{
    /// <summary>
    /// Interaction logic for AddData.xaml
    /// </summary>
    public partial class AddData : UserControl
    {
        public Cache m_cacheInstance = Cache.GetCache;
        public List<Data> LstData { get; set; }
        
        public AddData()
        {
            InitializeComponent();
            LstData = m_cacheInstance.LstData;
            DataContext = this;



        }

        private void BtnAddData(object sender, RoutedEventArgs e)
        {
            double arrivalTime =  Convert.ToDouble(txtBoxArrival.Text);
            double serviceTime = Convert.ToDouble(txtBoxServiceTime.Text);
            DataLogic.InsertDataInList(arrivalTime, serviceTime);
            txtBoxArrival.Clear();
            txtBoxServiceTime.Clear();

            views.Items.Refresh();

        }
    }
}
