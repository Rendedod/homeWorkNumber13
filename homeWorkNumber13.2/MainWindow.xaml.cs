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

namespace homeWorkNumber13._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void radioRead_Checked(object sender, RoutedEventArgs e)
        {
            colorBox.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            Grid.SetRow(colorBox, 0);
        }

        private void radioYellow_Checked(object sender, RoutedEventArgs e)
        {
            colorBox.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            Grid.SetRow(colorBox, 1);
        }

        private void radioGreen__Checked(object sender, RoutedEventArgs e)
        {
            colorBox.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            Grid.SetRow(colorBox, 2);
        }
    }
}
