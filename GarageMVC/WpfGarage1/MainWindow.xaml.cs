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
using GarageMVC;
//using 

namespace WpfGarage1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Liste_Intervention(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ListeRDV(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Quit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
