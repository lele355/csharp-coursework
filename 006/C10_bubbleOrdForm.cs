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
    public partial class C10_bubbleOrdForm : Form
    {
        TextBox[] txtbox = new TextBox[10];

        public C10_bubbleOrdForm()
        {
            InitializeComponent();
        }

        private void C10_bubbleOrdForm_Load(object sender, EventArgs e)
        {
            Random rd = new Random();
            for (int i = 0; i <= 9; i++)
            {
                txtbox[i] = new TextBox(); // 创建新的 TextBox
                txtbox[i].Name = "tbx" + i; // 设置名称
                txtbox[i].Text = rd.Next(1, 100).ToString(); // 设置随机值
                txtbox[i].Width = 50; // 设置宽度
                txtbox[i].Top = 30; // 设置顶部位置
                txtbox[i].Left = 20 + 60 * i; // 设置左侧位置
                txtbox[i].Visible = true; // 设置为可见
                this.Controls.Add(txtbox[i]); // 添加到窗体控件中
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            for (int i = 0; i < txtbox.Length; i++) // 遍历所有 TextBox
            {
                txtbox[i].Text = rd.Next(1, 100).ToString(); // 设置随机值
                txtbox[i].BackColor = Color.White; // 重置背景颜色为白色
            }
            textBox1.Text = ""; // 清空 textBox1 的内容
        }

        private void bubbleOrder()
        {
            int n = txtbox.Length - 1; // 待排序表中元素的上界
            string tmp;
            int lastExchangeIndex;
            int step = 0; // 记录执行趟数

            while (n > 0)
            {
                step++;
                lastExchangeIndex = 0;

                for (int j = 0; j < n; j++)
                {
                    if (int.Parse(txtbox[j + 1].Text) < int.Parse(txtbox[j].Text))
                    {
                        // 交换两个元素
                        tmp = txtbox[j].Text;
                        txtbox[j].Text = txtbox[j + 1].Text;
                        txtbox[j + 1].Text = tmp;

                        // 更新最后交换的位置
                        lastExchangeIndex = j;

                        // 显示当前交换的状态
                        MessageBox.Show($"第 {step} 趟：将 {txtbox[j + 1].Text} 与 {txtbox[j].Text} 交换位置", "排序过程");

                        // 强制刷新界面，显示实时变化
                        Application.DoEvents();
                    }
                }

                // 更新 n 为最后交换的位置
                n = lastExchangeIndex;

                // 输出当前排序步骤到 textBox1
                textBox1.Text += outPutStep(step);
            }
        }



        private string outPutStep(int n)
        {
            string stepStr = "";
            for (int i = 0; i < txtbox.Length; i++)
            {
                stepStr += txtbox[i].Text + " "; // 拼接当前数组状态
            }
            return "第 " + n + " 趟：" + stepStr + "\r\n"; // 返回当前步骤的字符串
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 清空 textBox1 的内容
            textBox1.Text = "";

            // 调用插入排序方法
            bubbleOrder();
        }
    }
}
