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
    public partial class C9_linerListForm: Form
    {
        public C9_linerListForm()
        {
            InitializeComponent();
        }

        private void C9_linerListForm_Load(object sender, EventArgs e)
        {

        }

        private string[] LinerList = new string[1];

        public bool Insert(ref string[] L, int i, string x)
        {
            if (i >= L.Length)
            {
                L[L.Length - 1] = x;
                Array.Resize(ref L, L.Length + 1);
                return true;
            }
            else if (i < 0)
            {
                return false;
            }
            else
            {
                for (int j = L.Length - 1; j > i; j--)
                {
                    L[j] = L[j - 1];
                }
                L[i] = x;
                Array.Resize(ref L, L.Length + 1);
                return true;
            }
        }

        public bool Delete(ref string[] L, int i)
        {
            if (i >= 0 && i < L.Length)
            {
                for (int j = i; j < L.Length - 1; j++)
                {
                    L[j] = L[j + 1];
                }
                if (L.Length > 1)
                {
                    Array.Resize(ref L, L.Length - 1);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Get(string[] L, int i)
        {
            if (i >= 0 && i < L.Length)
            {
                return L[i];
            }
            else
            {
                return null;
            }
        }

        public void showList(string[] L)
        {
            listBox1.Items.Clear();
            for (int j = 0; j < L.Length; j++)
            {
                listBox1.Items.Add(j + "--" + L[j]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Insert(ref LinerList, int.Parse(textBox1.Text), textBox2.Text))
            {
                MessageBox.Show(this, "元素添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showList(LinerList);
            }
            else
            {
                MessageBox.Show(this, "元素添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Delete(ref LinerList, int.Parse(textBox1.Text)))
            {
                MessageBox.Show(this, "元素删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showList(LinerList);
            }
            else
            {
                MessageBox.Show(this, "元素删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "获取元素为：" + Get(LinerList, int.Parse(textBox1.Text)), "提示", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
