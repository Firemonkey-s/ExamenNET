using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfGarage.ViewModel;

namespace WpfGarage.View
{
    /// <summary>
    /// Logique d'interaction pour ListeRDV.xaml
    /// </summary>
    public partial class ListeRDV : Window
    {
        public ListeRDV()
        {
            InitializeComponent();
            DataContext = new InterventionsViewModel(1);
        }

        private void Button_Add_Work(object sender, RoutedEventArgs e)
        {

        }

        private void Button_VisualiserTravaux(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
