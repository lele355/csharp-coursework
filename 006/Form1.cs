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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MDIParent1 mainForm;

        private void button1_Click(object sender, EventArgs e)
        {
            string admin = textBox1.Text;
            string mima = textBox2.Text;
            if (admin == "an" && mima == "88888888")
            {
                MessageBox.Show("网络连接失败，请稍后重试");
                mainForm = new MDIParent1();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //希望实现输入用户名时检测到enter输入直接进入输入密码操作
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // 阻止系统处理Enter键（避免发出提示音）
                textBox2.Focus();
            }
        }

        //希望实现输入密码时检测到enter输入直接进行登录操作
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // 阻止系统处理Enter键（避免发出提示音）
                button1.PerformClick(); // 模拟按钮点击
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
