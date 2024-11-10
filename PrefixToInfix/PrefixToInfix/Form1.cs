using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrefixToInfix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            string prefix = textBoxPrefix.Text;
            string infix = ConvertPrefixToInfix(prefix);
            textBoxInfix.Text = infix;
        }

        private string ConvertPrefixToInfix(string prefix)
        {
            Stack<string> stack = new Stack<string>();

            for (int i = prefix.Length - 1; i >= 0; i--)
            {
                char ch = prefix[i];

                if (IsOperator(ch))
                {
                    string op1 = stack.Pop();
                    string op2 = stack.Pop();
                    string tmp = "(" + op1 + ch + op2 + ")";
                    stack.Push(tmp);
                }
                else
                {
                    stack.Push(ch.ToString());
                }
            }

            return stack.Peek();
        }

        private bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


