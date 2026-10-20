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
    public partial class C10_selectOrdForm : Form
    {
        TextBox[] txtbox = new TextBox[10];

        public C10_selectOrdForm()
        {
            InitializeComponent();
        }

        private void C10_selectOrdForm_Load(object sender, EventArgs e)
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


        private void selectOrd()
        {
            int n = txtbox.Length; // 待排元素数目
            string tmp;
            int k; // 标记最小值元素下标

            for (int i = 0; i < n - 1; i++) // 遍历所有元素
            {
                k = i; // 假设当前元素为最小值

                for (int j = i + 1; j < n; j++) // 找到剩余元素中的最小值
                {
                    if (int.Parse(txtbox[j].Text) < int.Parse(txtbox[k].Text))
                    {
                        k = j; // 更新最小值下标
                    }
                }

                if (k != i) // 如果最小值不是当前元素，则交换
                {
                    tmp = txtbox[i].Text;
                    txtbox[i].Text = txtbox[k].Text;
                    txtbox[k].Text = tmp;

                    // 显示当前交换的状态
                    MessageBox.Show($"第 {i + 1} 趟：将 {txtbox[k].Text} 与 {txtbox[i].Text} 交换", "排序过程");

                    // 强制刷新界面，显示实时变化
                    Application.DoEvents();
                }

                // 标记当前排序的元素
                txtbox[i].BackColor = Color.Green;

                // 输出当前排序步骤到 textBox1
                textBox1.Text += outPutStep(i + 1);
            }

            // 标记最后一个元素为已排序
            txtbox[n - 1].BackColor = Color.Green;
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
            selectOrd();
        }
    }
}
