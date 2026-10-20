using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _006
{
    public partial class C2_工程计算Form: Form
    {
        public C2_工程计算Form()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            long sum = 1;
            for (int i = 1; i <= n; i++)
                sum = sum * i;
            label4.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            label4.Text = recursion(n).ToString();
        }

        private long recursion(long n)//递归函数
        {
            if(n >= 2)
                return n * recursion(n - 1);
            else
                return 1;
        }
    }
}
