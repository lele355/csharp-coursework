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
    public partial class C3_gameForm: Form
    {
        public C3_gameForm()
        {
            InitializeComponent();
        }

        private robot rbt1 = new robot("乐乐");

        private void C3_gameForm_Load(object sender, EventArgs e)
        {

        }

        public class robot
        {
            private string robotname = "";
            private string[] fingers = new string[3] { "石头", "剪刀", "布" };
            private string dofinger = "";
            public robot(string name)
            {
                RobotName = name;
            }
            public string DoFinger
            {
                get
                {
                    Random rdm = new Random();
                    dofinger = fingers[rdm.Next(0, 3)];
                    return dofinger;
                }
            }
            public string RobotName
            {
                get { return robotname; }
                set { robotname = value; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string youRlt = comboBox1.Text;
            string rbtRlt = rbt1.DoFinger;
            string judgeRlt = "";
            label2.Text = rbtRlt;
            label4.Text = rbt1.RobotName;
            if (youRlt =="石头"&& rbtRlt == "剪刀") 
                judgeRlt = "Byd再来";
            else if (youRlt =="剪刀"&& rbtRlt =="布")
                judgeRlt = "Byd再来";
            else if (youRlt == "布" && rbtRlt == "石头")
                judgeRlt = "Byd再来";
            else
                judgeRlt = "垃圾";
            if (youRlt == rbtRlt)
                judgeRlt = "有点实力";
            label1.Text = judgeRlt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
