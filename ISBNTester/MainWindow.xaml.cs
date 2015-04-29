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

namespace ISBNTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtBox.Focus();
            webBrwser.Visibility = System.Windows.Visibility.Hidden;

        }

        private void TxtBoxKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (txtBox.Text.Count() >= 10)
            {
                txtBox.IsEnabled = false;
                btnVerify.Focus();
            }
        }

        private void BtnHandler(object sender, RoutedEventArgs e)
        {
            txtBox.IsEnabled = true;
            //verify right count
            if (txtBox.Text.Count() != 10)
            {
                resultTxtBlock.Text = "FAIL: Not enough Numbers";
                resultTxtBlock.Foreground = new SolidColorBrush(Colors.Red);
                txtBox.IsEnabled = true;
                return;
            }

            //verify all digits
            int convertedToInt;
            if(!Int32.TryParse(txtBox.Text.Substring(0, 9), out convertedToInt))
            {
                resultTxtBlock.Text = "FAIL: Not all digits.";
                resultTxtBlock.Foreground = new SolidColorBrush(Colors.Red);
                txtBox.IsEnabled = true;
            }

            //verify valid
            int sum = 0;
            int j = 10;
            for(int i = 0; i < 8; i++)
            {
                int num = Int32.Parse(txtBox.Text[i].ToString());
                sum += num * j;
                j--;
            }
            //check if last digit is 'X'
            if(txtBox.Text.Last() == 'x' || txtBox.Text.Last() == 'X')
            {
                int num = Int32.Parse(txtBox.Text[8].ToString());
                sum += 2 * num;
                sum += 10;
            }
            else
            {
                int num = Int32.Parse(txtBox.Text[8].ToString());
                sum += num * 2;
                num = Int32.Parse(txtBox.Text[9].ToString());
                sum += num;
            }
            if(sum % 11 == 0)
            {
                //passed!
                resultTxtBlock.Text = "PASS: Valid ISBN.";
                resultTxtBlock.Foreground = new SolidColorBrush(Colors.Green);
                txtBox.IsEnabled = true;
                webBrwser.Visibility = System.Windows.Visibility.Visible;
                webBrwser.Source = new Uri("http://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=" + txtBox.Text);
            }
            else
            {
                resultTxtBlock.Text = "FAIL: Invalid ISBN";
                resultTxtBlock.Foreground = new SolidColorBrush(Colors.Red);
                txtBox.IsEnabled = true;
                webBrwser.Visibility = System.Windows.Visibility.Hidden;
            }
                

        }

        private void TxtBoxFocusHandler(object sender, RoutedEventArgs e)
        {
            resultTxtBlock.Text = "";
            txtBox.Text = "";
            webBrwser.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
