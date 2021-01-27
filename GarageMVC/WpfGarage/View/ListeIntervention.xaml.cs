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
    /// Logique d'interaction pour ListeIntervention.xaml
    /// </summary>
    public partial class ListeIntervention : Window
    {   
        public ListeIntervention(int id)
        {
            InitializeComponent();
            DataContext = new InterventionsViewModel(0);
        }


        private void Button_Close(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Ajout(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Modifier(object sender, RoutedEventArgs e)
        {

        }
    }
}
