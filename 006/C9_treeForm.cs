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
    public partial class C9_treeForm: Form
    {
        public C9_treeForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count > 0)
            {
                label4.Text = LDR_Order(treeView1.Nodes[0]); // 调用中序遍历方法
            }
            else
            {
                label4.Text = "树为空";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode nd = new TreeNode(); // 实例化一个新节点
            int LorRy = 0; // 标记左子树为0，右子树为1

            if (radioButton2.Checked)
                LorRy = 1;

            if (treeView1.Nodes.Count == 0) // 若为空树
            {
                nd.Text = textBox1.Text;
                nd.Tag = LorRy; // 存储左右子树区分标记
                treeView1.Nodes.Add(nd);
            }
            else
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show(this, "请选择父节点", "提示", MessageBoxButtons.OK);
                    return;
                }

                if (treeView1.SelectedNode.Nodes.Count >= 2)
                {
                    MessageBox.Show(this, "所选节点的子节点数不能超过2个", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    nd.Text = textBox1.Text;
                    nd.Tag = LorRy;

                    if (LorRy == 0)
                        nd.ForeColor = Color.Blue; // 标记左子树为蓝色
                    else
                        nd.ForeColor = Color.Red; // 标记右子树为红色

                    treeView1.SelectedNode.Nodes.Add(nd);
                    treeView1.SelectedNode.ExpandAll(); // 将树展开
                }
            }
        }

        private string DLR_Order(TreeNode td)
        {
            string rlt = ""; // 初始化

            if (td != null)
            {
                rlt += td.Text; // 先读根节点

                if (td.Nodes.Count == 2) // 有两棵子树
                {
                    if ((int)td.Nodes[0].Tag == 0) // 如果左子树为0
                    {
                        rlt += DLR_Order(td.Nodes[0]); // 读左子树
                        rlt += DLR_Order(td.Nodes[1]); // 读右子树
                    }
                    else // 如果右子树为1
                    {
                        rlt += DLR_Order(td.Nodes[1]); // 读右子树
                        rlt += DLR_Order(td.Nodes[0]); // 读左子树
                    }
                }
                else if (td.Nodes.Count == 1) // 有一棵子树
                {
                    rlt += DLR_Order(td.Nodes[0]); // 读唯一的子树
                }
            }

            return rlt; // 返回结果
        }

        private string LRD_Order(TreeNode td)
        {
            string rlt = ""; // 初始化

            if (td != null)
            {
                if (td.Nodes.Count == 2) // 有两棵子树
                {
                    if ((int)td.Nodes[0].Tag == 0) // 如果左子树为0
                    {
                        rlt += LRD_Order(td.Nodes[0]); // 读左子树
                        rlt += LRD_Order(td.Nodes[1]); // 读右子树
                    }
                    else // 如果右子树为1
                    {
                        rlt += LRD_Order(td.Nodes[1]); // 读右子树
                        rlt += LRD_Order(td.Nodes[0]); // 读左子树
                    }
                }
                else if (td.Nodes.Count == 1) // 有一棵子树
                {
                    rlt += LRD_Order(td.Nodes[0]); // 读唯一的子树
                }

                rlt += td.Text + " "; // 最后读根节点
            }

            return rlt; // 返回结果
        }

        private string LDR_Order(TreeNode td)
        {
            string rlt = ""; // 初始化

            if (td != null)
            {
                if (td.Nodes.Count == 2) // 有两棵子树
                {
                    if ((int)td.Nodes[0].Tag == 0) // 如果左子树为0
                    {
                        rlt += LDR_Order(td.Nodes[0]); // 读左子树
                        rlt += td.Text + " ";           // 读根节点
                        rlt += LDR_Order(td.Nodes[1]); // 读右子树
                    }
                    else // 如果右子树为1
                    {
                        rlt += LDR_Order(td.Nodes[1]); // 读右子树
                        rlt += td.Text + " ";            // 读根节点
                        rlt += LDR_Order(td.Nodes[0]); // 读左子树
                    }
                }
                else if (td.Nodes.Count == 1) // 有一棵子树
                {
                    if ((int)td.Nodes[0].Tag == 0) // 如果左子树为0
                    {
                        rlt += LDR_Order(td.Nodes[0]); // 读左子树
                        rlt += td.Text + " "; // 读根节点
                    }
                    else // 如果右子树为1
                    {
                        rlt += td.Text + " "; // 读根节点
                        rlt += LDR_Order(td.Nodes[0]); // 读右子树
                    }
                }
                else // 无子树
                {
                    rlt += td.Text + " "; // 读根节点
                }
            }

            return rlt; // 返回结果
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count > 0)
            {
                label3.Text = DLR_Order(treeView1.Nodes[0]); // 调用先序遍历方法
            }
            else
            {
                label3.Text = "树为空";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count > 0)
            {
                label5.Text = LRD_Order(treeView1.Nodes[0]); // 调用后序遍历方法
            }
            else
            {
                label5.Text = "树为空";
            }
        }
    }
}
