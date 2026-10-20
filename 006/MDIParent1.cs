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
    public partial class MDIParent1 : Form
    {

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }

        private void 窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 引用类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C1_引用类型 refForm1 = new C1_引用类型();
            refForm1.MdiParent = this;
            refForm1.Show();
        }

        private void oLE的使用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C2_OLEForm oleForm = new C2_OLEForm();
            oleForm.MdiParent = this;
            oleForm.Show();
        }

        private void 工程计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C2_工程计算Form oleForm = new C2_工程计算Form();
            oleForm.MdiParent = this;
            oleForm.Show();
        }

        private void 国际棋盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C2_chessForm oleForm = new C2_chessForm();
            oleForm.MdiParent = this;
            oleForm.Show();
        }

        private void 库存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C3_ClassForm oleForm = new C3_ClassForm();
            oleForm.MdiParent = this;
            oleForm.Show();
        }

        private void 猜拳游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C3_gameForm oleForm = new C3_gameForm();
            oleForm.MdiParent = this;
            oleForm.Show();
        }

        private void sQLServer记录维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQL_student sql_student = new SQL_student();
            sql_student.MdiParent = this;
            sql_student.Show();
        }

        private void sQL语句练习ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C6_dataSqlList dataSqlform = new C6_dataSqlList();
            dataSqlform.MdiParent = this;
            dataSqlform.Show();
        }

        private void 数据记录维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C6_dataSQLAdd dataSqlform = new C6_dataSQLAdd();
            dataSqlform.MdiParent = this;
            dataSqlform.Show();
        }

        private void 线性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C9_linerListForm dataSqlform = new C9_linerListForm();
            dataSqlform.MdiParent = this;
            dataSqlform.Show();
        }

        private void 堆栈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C9_stackForm dataSqlform = new C9_stackForm();
            dataSqlform.MdiParent = this;
            dataSqlform.Show();
        }

        private void 二叉树ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C9_treeForm  dataSqlform = new C9_treeForm();
            dataSqlform.MdiParent = this;
            dataSqlform.Show();
        }

        private void 二叉排序树ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C10_binaryTreeForm dataSqlform = new C10_binaryTreeForm();
            dataSqlform.MdiParent = this;
            dataSqlform.Show();
        }

        private void 直接插入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C10_insertionOrdForm dataSqlform = new C10_insertionOrdForm();
            dataSqlform.MdiParent = this;
            dataSqlform.Show();
        }

        private void 直接选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C10_selectOrdForm dataSqlform = new C10_selectOrdForm();
            dataSqlform.MdiParent = this;
            dataSqlform.Show();
        }

        private void 冒泡排序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C10_bubbleOrdForm dataSqlform = new C10_bubbleOrdForm();
            dataSqlform.MdiParent = this;
            dataSqlform.Show();
        }
    }
}
