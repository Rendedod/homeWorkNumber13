using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace homeWorkNumber13._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numberConvert;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void myText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char text = e.Text[0];
            if (!Char.IsDigit(text) && text != '-')
                e.Handled = true;
        }

        private void myText_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                numberConvert = Convert.ToInt32(myText.Text);
                myText.Text = numberConvert.ToString();
            }
            catch
            {
                myText.Text = myText.Text.Replace("--", "-");
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            decision.Content = Convert.ToString(numberConvert, 2) ?? "0";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            decision.Content = Convert.ToString(numberConvert, 8) ?? "0";
        }
    }
}
