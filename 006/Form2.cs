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
    public partial class C1_引用类型 : Form
    {
        public C1_引用类型()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public class man
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private void C1_引用类型_Load(object sender, EventArgs e)
        {
            textMan1nm.Text = "张三"; textMan1age.Text = "25";
            textMan2nm.Text = "李四"; textMan2age.Text = "47";
            textMan3nm.Text = ""; textMan3age.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            man man_1 = new man { Name = "张三", Age = 25 };
            man man_2 = new man { Name = "李四", Age = 47 };
            int age = man_1.Age;
            man_1.Age = 22;
            man man_3 = man_2;
            textMan3nm.Text = man_3.Name;
            textMan3age.Text = man_3.Age.ToString();
            man_2.Name = "王五";
            textMan2nm.Text = man_2.Name;
            textBox7.Text = "";
            textBox7.Text += "man_1's age:" + man_1.Age.ToString() + "\r\n";
            textBox7.Text += "age's value:" + age.ToString() + "\r\n";
            textBox7.Text += "man_2's name:" + man_2.Name + "\r\n";
            textBox7.Text += "man_3's name:" + man_3.Name + "\r\n";
        }
    }
}
