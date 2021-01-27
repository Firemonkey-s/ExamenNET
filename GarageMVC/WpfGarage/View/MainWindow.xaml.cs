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

namespace WpfGarage.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Liste_Intervention(object sender, RoutedEventArgs e)
        {
            ListeIntervention wnd = new ListeIntervention(0);
            wnd.ShowDialog();
        }

        private void Button_ListeRDV(object sender, RoutedEventArgs e)
        {
            ListeRDV wnd = new ListeRDV();
            wnd.ShowDialog();
        }

        private void Button_Quit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
