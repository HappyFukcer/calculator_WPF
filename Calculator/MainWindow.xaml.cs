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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        StringEvaluater strEval = new StringEvaluater();

        string num1;
        bool number_click = false;
        bool operation_click = false;
        string operation;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Equal_Click(object sender, RoutedEventArgs e)
        {
            //string s;
            //s = TextBox1.Text;
            //strEval = new StringEvaluater(s);
            //label1.Content = TextBox1.Text + " = " + strEval.Eval();
            if ((bool)checkBox1.IsChecked)
            {
                strEval = new StringEvaluater(TextBox1.Text);
                label1.Content += TextBox1.Text;
                TextBox1.Text = strEval.Eval();
                label1.Content += " = " + TextBox1.Text;
            }
            else
            {
                num1 = strEval.Operation(num1, operation, TextBox1.Text);
                label1.Content += " " + TextBox1.Text + " = " + num1;
                TextBox1.Text = num1;
                number_click = false;
                operation_click = false;
            }       
        }

        private void Button_Click_Number(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBox1.IsChecked)
            {
                TextBox1.Text += (string)((Button)e.OriginalSource).Content;
            }
            else
            {
                //string operation = (string)((Button)e.OriginalSource).Content;
                if (operation_click)
                {
                    TextBox1.Text = "";
                    operation_click = false;
                }
                TextBox1.Text += (string)((Button)e.OriginalSource).Content;
            }
        }

        private void Button_Click_Operation(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBox1.IsChecked)
            {
                TextBox1.Text += (string)((Button)e.OriginalSource).Content;
            }
            else
            {
                operation = (string)((Button)e.OriginalSource).Content;
                if (number_click)
                {
                    label1.Content += " " + TextBox1.Text + " " + operation;
                    TextBox1.Text = num1 = strEval.Operation(num1, operation, TextBox1.Text);
                }
                else
                {
                    num1 = TextBox1.Text;
                    label1.Content += TextBox1.Text + " " + operation;
                    number_click = true;
                }
                operation_click = true;
            }
        }

        private void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {
            if( Char.IsNumber((char)e.Key) || (char)e.Key == ',')
            {
                e.Handled = true;
            }
            else
            {
                //e.Handled = e.Key != Key.Back;
            }
        }

    }
}