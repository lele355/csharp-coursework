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
    public partial class C2_chessForm: Form
    {
        public C2_chessForm()
        {
            InitializeComponent();
        }

        Label[] lb = new Label[64];

        private void C2_chessForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 63; i++)
            {
                lb[i] = new Label();
                lb[i].Name = "Lb" + i;
                lb[i].Text = ""+ i;
                lb[i].TextAlign=ContentAlignment.MiddleLeft;
                lb[i].Visible = true;
                pictureBox1.Controls.Add(lb[i]);
                lb[i].Click += new System.EventHandler(this.Labels_Click);
            }
            this.Resize += new System.EventHandler(this.C2_chessForm_Resize);
            C2_chessForm_Resize(sender, e);
        }

        private void Labels_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 63; i++)
            {
                lb[i].BackColor = (lb[i].BackColor == Color. Green ? Color.Yellow : Color.Green);
            }               
        }

        private void C2_chessForm_Resize(object sender, EventArgs e)
        {
            pictureBox1.Height = this.Size.Height - 60;
            pictureBox1.Width = pictureBox1.Height;
            pictureBox1.Left = (this.Size.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = 10;
            for (int m = 0; m <= 7; m++)
            {
                for (int n = 0; n <= 7; n++)
                {
                    Label lb1 = lb[8 * m + n];
                    if (m % 2 == 0)
                    {
                        if (n % 2 == 0)
                            lb1.BackColor = Color.Green;
                        else
                            lb1.BackColor = Color.Yellow;
                    }
                    else
                    {
                        if (n % 2 == 0)
                            lb1.BackColor = Color.Yellow;
                        else
                            lb1.BackColor = Color.Green;
                    }
                    lb1.Width = pictureBox1.Width / 8;
                    lb1.Height = pictureBox1.Height / 8;
                    lb1.Left = pictureBox1.Width / 8 * n;
                    lb1.Top = pictureBox1.Height / 8 * m;
                }
            }
        }



    }
}
