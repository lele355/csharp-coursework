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
    public partial class C9_stackForm: Form
    {
        private string[] StackList;
        private int StackTop; 
        private int StackLength; 

        public void Inistack(ref string[] S, int length)
        {
            StackTop = -1; // 将栈顶置为-1
            StackLength = length; // 定义栈长
            S = new string[length]; // 初始化数组
        }

        public C9_stackForm()
        {
            InitializeComponent();
            Inistack(ref StackList, 10); // 调用栈初始化过程，定义栈StackList长度为10
        }

        public void showList(string[] L)
        {
            textBox1.Text = "";
            for (int j = 0; j < L.Length; j++)
            {
                textBox1.Text += j + "--" + L[j] + "\r\n";
            }
        }
        public void Push(ref string[] L, string x) 
        {
            if (StackTop == StackLength - 1)
            {
                // 栈满溢出
                MessageBox.Show(this, "栈满溢出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                StackTop++;
                L[StackTop] = x;
            }
        }

        public string Pop(ref string[] L) // 若栈S不是空栈，则删除栈顶元素
        {
            string tmp = "";
            if (StackTop == -1)
            {
                return "栈空溢出";
            }
            else
            {
                tmp = L[StackTop];
                L[StackTop] = null;
                StackTop--;
                return tmp;
            }
        }

        private void C9_stackForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Push(ref StackList, textBox2.Text);
            showList(StackList);
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, Pop(ref StackList), "出栈元素", MessageBoxButtons.OK);
            showList(StackList);
        }
    }


}
