using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfixToPrefix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string ConvertInfixToPrefix(string infix)
        {
            Stack<char> operators = new Stack<char>();
            Stack<string> operands = new Stack<string>();

            for (int i = infix.Length - 1; i >= 0; i--)
            {
                char ch = infix[i];

                if (IsOperator(ch))
                {
                    while (operators.Count > 0 && Priority(operators.Peek()) > Priority(ch))
                    {
                        string op1 = operands.Pop();
                        string op2 = operands.Pop();
                        char op = operators.Pop();
                        string tmp = op + op1 + op2;
                        operands.Push(tmp);
                    }
                    operators.Push(ch);
                }
                else if (ch == ')')
                {
                    operators.Push(ch);
                }
                else if (ch == '(')
                {
                    while (operators.Peek() != ')')
                    {
                        string op1 = operands.Pop();
                        string op2 = operands.Pop();
                        char op = operators.Pop();
                        string tmp = op + op1 + op2;
                        operands.Push(tmp);
                    }
                    operators.Pop();
                }
                else
                {
                    operands.Push(ch.ToString());
                }
            }

            while (operators.Count > 0)
            {
                string op1 = operands.Pop();
                string op2 = operands.Pop();
                char op = operators.Pop();
                string tmp = op + op1 + op2;
                operands.Push(tmp);
            }

            return operands.Peek();
        }

        private bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/';
        }

        private int Priority(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
            }
            return 0;
        }

        private void buttonConvert_Click_1(object sender, EventArgs e)
        {
            string infix = textBoxInfix.Text;
            string prefix = ConvertInfixToPrefix(infix);
            textBoxPrefix.Text = prefix;
        }
    }
}

