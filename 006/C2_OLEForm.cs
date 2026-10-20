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
    public partial class C2_OLEForm: Form
    {
        public C2_OLEForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_DragOver(object sender, DragEventArgs e)
        {
            //判断是否为允许的拖放操作
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] items =(object)e.Data.GetData("FileNameW") as string[];
            if (items.Length == 1)
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(items[0]);
                this.pictureBox1.Image = img;
                listBox1.Items.Add(items[0]);
            }
        }

        private void C2_OLEForm_Load(object sender, EventArgs e)
        {
            this.pictureBox1.AllowDrop = true;
        }
    }
}
