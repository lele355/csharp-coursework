using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _006
{
    public partial class C3_ClassForm: Form
    {
        public C3_ClassForm()
        {
            InitializeComponent();
        }

        cStockInfo[] strecord;
        int markId = 0;

        public class cStockInfo
        {
            private string tradecode = "";
            private string fullname = "";
            private string tradetype = "";
            private string tradeunit = "";
            private float qty = 0;
            private float price = 0;
            private float upperlimit = 0;
            private float lowerlimit = 0;
            public cStockInfo(int n)     //构造函数
            {
                TradeCode = "MO" + n.ToString();
            }
            public string TradeCode      //商品编号
            {
                get { return tradecode; }
                set { tradecode = value; }
            }
            public string FullName        //商品全称
            {
                get { return fullname; }
                set { fullname = value; }
            }
            public string TradeType        //商品型号
            {
                get { return tradetype; }
                set { tradetype = value; }
            }
            public string Unit              //计量单位
            {
                get { return tradeunit; }
                set { tradeunit = value; }
            }
            public float Qty                //库存数量
            {
                get { return qty; }
                set { qty = value; }
            }
            public float Price               //进货价格
            {
                get { return price; }
                set { price = value; }
            }
            public float UpperLimit           //库存报警上限 
            {
                get { return upperlimit; }
                set { upperlimit = value; }
            }
            public float LowerLimit           //库存报警下限
            {
                get { return lowerlimit; }
                set { lowerlimit = value; }
            }
            public string ShowInfo()
            {
                string tmpstr = "";
                if (Qty > UpperLimit) tmpstr += "商品[" + TradeCode + "]数量[" + Qty + "]超出库存上限[" + UpperLimit + "]\r\n";
                if (Qty < LowerLimit) tmpstr += "商品[" + TradeCode + "]数量[" + Qty + "]低于库存下限[" + LowerLimit + "]\r\n";
                return tmpstr;
            }
        }

        private void C3_ClassForm_Load(object sender, EventArgs e)
        {
            //初始化文本框
            textBox1.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox2.Text = "0";
            textBox4.Text = "0";
            textBox6.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "";
            //初始新增一条库存记录
            Array.Resize(ref strecord, 1);
            strecord[strecord.Length - 1] = new cStockInfo(markId + 1);
            textBox1.Text = strecord[markId].TradeCode;
        }

        private void showRecord(int i)
        {
            textBox1.Text = strecord[i].TradeCode;
            textBox2.Text = strecord[i].FullName;
            textBox3.Text = strecord[i].TradeType;
            textBox4.Text = strecord[i].Unit;
            textBox5.Text = strecord[i].Price.ToString();
            textBox6.Text = strecord[i].Qty.ToString();
            textBox7.Text = strecord[i].UpperLimit.ToString();
            textBox8.Text = strecord[i].LowerLimit.ToString();
            label11.Text = (i + 1) + "/" + (strecord.Length);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            strecord[markId].FullName = textBox2.Text;
            strecord[markId].TradeType = textBox3.Text;
            strecord[markId].Unit = textBox4.Text;
            strecord[markId].Price = float.Parse(textBox5.Text);
            strecord[markId].Qty = float.Parse(textBox6.Text);
            strecord[markId].UpperLimit = float.Parse(textBox7.Text);
            strecord[markId].LowerLimit = float.Parse(textBox8.Text);
            MessageBox.Show("记录保存成功\n——了吗？");
            showRecord(markId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Array.Resize(ref strecord, strecord.Length + 1);
            markId = strecord.Length - 1;
            strecord[markId] = new cStockInfo(markId + 1);
            textBox1.Text = strecord[markId].TradeCode;
            textBox2.Text = ""; 
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "0"; 
            textBox6.Text = "0";
            textBox7.Text = "0"; 
            textBox8.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            markId--;
            if (markId < 0)
            {
                markId = 0;
                MessageBox.Show("已是第一条记录！");
            }
            showRecord(markId);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            markId++;
            if (markId > strecord.Length -1)
            {
                markId = strecord.Length - 1;
                MessageBox.Show("已是最后一条记录！");
            }
            showRecord(markId);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            float fund = 0;
            string reportStr = "";
            for (int i = 0; i < strecord.Length; i++)
            {
                fund += strecord[i].Qty * strecord[i].Price;
                reportStr += strecord[i].ShowInfo();
            }
            textBox9.Text = "库存占压资金为" + fund + "元；\r\n"+reportStr;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
