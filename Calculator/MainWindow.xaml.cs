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
        bool flag = false;
        StringEvaluater strEval = new StringEvaluater();
        string num1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Equal_Click(object sender, RoutedEventArgs e)
        {
            string s;
            if (flag)
            {
                s = TextBox1.Text;
                strEval = new StringEvaluater(s);
                label1.Content = TextBox1.Text + " = " + strEval.Eval();

                flag = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string operation = (string)((Button)e.OriginalSource).Content;

            if (flag)
            {
                TextBox1.Text = strEval.Operation(num1, operation, TextBox1.Text);
                //flag = true;
            }

            num1 = TextBox1.Text;
            flag = true;
            TextBox1.Text="";
        }

    }
}