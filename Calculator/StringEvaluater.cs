using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class StringEvaluater
    {
        private string Equation;

        public  StringEvaluater(string Equation)
        {
            this.Equation = Equation.Replace(" ",string.Empty);
        }

        public string[] StringToArray()
        {
            string[] mas = new string[Equation.Length ];
            int k = 0;
            foreach (char ch in Equation)
            {
                switch (ch)
                {
                    case '/':
                        k++;
                        mas[k] = ch.ToString();
                        k++;
                        break;
                    case '*':
                        k++;
                        mas[k] = ch.ToString();
                        k++;
                        break;
                    case '-':
                        k++;
                        mas[k] = ch.ToString();
                        k++;
                        break;
                    case '+':
                        k++;
                        mas[k] = ch.ToString();
                        k++;
                        break;
                    default:
                        mas[k] += ch.ToString();
                        break;
                }
            }            
            Array.Resize(ref mas, ++k);
            return mas;
        }

        private string OperationEvalSumSub (string num1, string operation, string num2)
        {
            switch (operation)
            {
                case "-":
                    return (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString();
                case "+":
                    return (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();               
                default:
                    return "";
            }
        }

        private string OperationEvalMultDiv(string num1, string operation, string num2)
        {
            switch (operation)
            {               
                case "/":
                    return (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString();
                case "*":
                    return (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString();
                default:
                    return "";
            }          
        }      

        private void Resize(ref string[]mas , int index)
        {
            if (index == mas.Length - 2)
                Array.Resize(ref mas, mas.Length - 2);
            else
            {
                for (int i = index ; i < mas.Length  - 2; i++)                
                    mas[i] = mas[i + 2];
                Array.Resize(ref mas, mas.Length - 2);

            }
        }

        public string Eval()
        {
            string[] mas = StringToArray();
            int[] operations = new int[0];

            for(int i = mas.Length -2 ; i > 0; i-=2)
            {
                if (mas[i ] == "/" || mas[i ] == "*")
                {
                    Array.Resize(ref operations, operations.Length + 1);
                    operations[operations.Length - 1] = i ;
                }
            }

            if (operations.Length != 0)
                for (int i = 0; i < operations.Length; i++)
                {
                    mas[operations[i] - 1] = OperationEvalMultDiv(mas[operations[i] -1], mas[operations[i]], mas[operations[i] + 1]);
                    Resize(ref mas, operations[i]);
                }
            Array.Resize(ref operations, 0);

            for(int i = mas.Length - 2; i > 0 ; i-= 2)
            {
                mas[i - 1] = OperationEvalSumSub(mas[i - 1], mas[i], mas[i + 1]);
                Array.Resize(ref mas, mas.Length - 2);
            }

            return mas[0];
        }


    }
}
