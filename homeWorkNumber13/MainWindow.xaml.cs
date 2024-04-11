using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace homeWorkNumber13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char? mathematicalAction;
        double? firstNumberComputing, secendNumberComputing;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void firstNumber_TextChanged(object sender, TextChangedEventArgs e)
        {   firstNumber.Text = deliteText(firstNumber.Text);

            if (firstNumber.Text != string.Empty && !firstNumber.Text.Contains('-'))
                firstNumberComputing = Convert.ToDouble(firstNumber.Text);
            else if(firstNumber.Text.Length > 1 && firstNumber.Text != string.Empty)
                firstNumberComputing = Convert.ToDouble(firstNumber.Text);
            else
                firstNumberComputing = null;

            decision();

            firstNumber.SelectionStart = firstNumber.Text.Length;
            firstNumber.SelectionLength = 0;
        }

        private void secendNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            secendNumber.Text = deliteText(secendNumber.Text);

            if (secendNumber.Text != string.Empty && !secendNumber.Text.Contains('-'))
                secendNumberComputing = Convert.ToDouble(secendNumber.Text);
            else if (secendNumber.Text.Length > 1 && secendNumber.Text != string.Empty)
                secendNumberComputing = Convert.ToDouble(secendNumber.Text);
            else
                secendNumberComputing = null;

            decision();

            secendNumber.SelectionStart = secendNumber.Text.Length;
            secendNumber.SelectionLength = 0;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mathematicalAction = '+';
            decision();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            mathematicalAction = '-';
            decision();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            mathematicalAction = '*';
            decision();
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            mathematicalAction = '/';
            decision();
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            mathematicalAction = '%';
            decision();
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            mathematicalAction = '^';
            decision();
        }

        private string deliteText(string text)
        {
            if(text != string.Empty)
            {
                text = text.Replace('.', ',');

                text = text[0] + text.Substring(1).Replace("-", "");

                // Запрещает ставить в начало более одного 0 и одной ','
                while (text[0] == '0' && text.Length > 1)
                    text = text.Substring(1);

                if (text[0] == ',')
                    text = 0 + text;
                else if (text.Length > 2 && text[0] == '-' && text[1] == '0')
                    text = "-" + text.Substring(2);

                // Запрещает ставить более одной ',' в любом месте ткста
                if (text.Contains(","))
                {
                    string textSupport = text.Substring(0, text.Length - 1);
                    if (textSupport.Contains(',') && text[text.Length - 1] == ',')
                        text = textSupport;
                }

                if(text.Replace("-", "").Replace(",", "").Length >= 27)
                {
                    if (text.Contains(',') && text.Contains('-'))
                        text = text[0] + text.Substring(1, 27);
                    else if (text.Contains(',') || text.Contains('-'))
                        text = text.Substring(0, 28);
                    else
                        text = text.Substring(0, 27);
                }

                return Regex.Replace(text, "[^0-9,.-]", "").Replace("-,", "-0,");

            }
            else 
                return string.Empty;
        }

        private void decision()
        {
            if (firstNumberComputing != null && secendNumberComputing != null && mathematicalAction != null)
            {
                switch (mathematicalAction)
                {
                    case '+':
                        ansvered.Content = Convert.ToString(firstNumberComputing + secendNumberComputing);
                        break;

                    case '-':
                        ansvered.Content = Convert.ToString(firstNumberComputing - secendNumberComputing);
                        break;

                    case '*':
                        ansvered.Content = Convert.ToString(firstNumberComputing * secendNumberComputing);
                        break;

                    case '/':
                        ansvered.Content = Convert.ToString(firstNumberComputing / secendNumberComputing);
                        break;

                    case '%':
                        ansvered.Content = Convert.ToString(firstNumberComputing % secendNumberComputing);
                        break;

                    case '^':
                        ansvered.Content = Convert.ToString(Math.Pow(firstNumberComputing ?? 0,secendNumberComputing ?? 0));
                        break;
                }
            }
            else ansvered.Content = "***";
        }

    }
}


