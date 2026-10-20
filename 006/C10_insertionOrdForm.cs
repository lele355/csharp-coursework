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
    public partial class C10_insertionOrdForm: Form
    {

        TextBox[] txtbox = new TextBox[10];

        public C10_insertionOrdForm()
        {
            InitializeComponent();
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

        private void C10_insertionOrdForm_Load(object sender, EventArgs e)
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

        private void insertOrd()
        {
            int n; // 待排元素数目
            int tmp;
            n = txtbox.Length;

            for (int i = 1; i < n; i++) // 从第二个元素开始排序
            {
                tmp = int.Parse(txtbox[i].Text); // 取出待排序记录中的第 i 个元素
                int j = i - 1;

                // 将第 i 个元素插入到前 i-1 个元素中
                while (j >= 0 && tmp < int.Parse(txtbox[j].Text)) // 当待排元素 tmp 小于第 j 个元素时
                {
                    txtbox[j + 1].Text = txtbox[j].Text; // 将第 j 个元素后移一位
                    j--;
                }

                txtbox[j + 1].Text = tmp.ToString(); // 在第 j+1 个位置放置 tmp

                // 显示当前排序步骤
                MessageBox.Show("第 " + i + " 趟：" + tmp + " 插入到位置 " + (j + 1), "排序过程");

                // 标记当前排序的元素
                txtbox[i].BackColor = Color.Green;

                // 输出当前排序步骤到 textBox1
                textBox1.Text += outPutStep(i);
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
            insertOrd();
        }
    }
}
