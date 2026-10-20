using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace _006
{
    public partial class SQL_student: Form
    {
        public SQL_student()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Text ="新增";
            button2.Text = "修改";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            studentTableAdapter.Fill(stud_学号DataSet.student);
        }

        private void SQL_student_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“stud_学号DataSet.student"中。您可以根据需要移动或移除它。
            this.studentTableAdapter.Fill(this.stud_学号DataSet.student);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = !button2.Enabled;//修改按钮
            button3.Enabled = !button3.Enabled;//删除按钮
            button4.Enabled = !button4.Enabled;//放弃按钮
            if (button1.Text == "新增")
            {
                button1.Text = "确认";
                bindingSource1.AddNew();
                textBox1.Focus();
            }
            else
            {
                button1.Text = "新增";
                bindingSource1.EndEdit();
                studentTableAdapter.Update(stud_学号DataSet);
                studentTableAdapter.Fill(stud_学号DataSet.student);
                bindingSource1.MoveLast();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = !button1.Enabled;//新增按钮
            button3.Enabled = !button3.Enabled;//删除按钮
            button4.Enabled = !button4.Enabled;//放弃按钮
            if (button2.Text == "修改")
            {
                button2.Text = "确认";
                textBox1.Focus();
            }
            //else
            {
                button2.Text = "修改";
                bindingSource1.EndEdit();
                studentTableAdapter.Update(stud_学号DataSet);
                studentTableAdapter.Fill(stud_学号DataSet.student);
                bindingSource1.MoveLast(); 
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult rlt = MessageBox.Show("确定要删除所选记录？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (rlt == DialogResult.Yes)
            {
                bindingSource1.RemoveCurrent();
                studentTableAdapter.Update(stud_学号DataSet);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Text = "学生信息（"+(bindingSource1.Position +1)+ "/"+ bindingSource1.Count +")";
        }
    }
}
