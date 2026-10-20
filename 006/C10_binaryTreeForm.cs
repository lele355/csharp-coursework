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
    public partial class C10_binaryTreeForm : Form
    {
        private binaryTreeNode binTree;

        public C10_binaryTreeForm()
        {
            InitializeComponent();
        }

        private void C10_binaryTreeForm_Load(object sender, EventArgs e)
        {

        }

        private void insertNode(ref binaryTreeNode tree, int num)
        {
            if (tree == null) // 如果当前树为空，创建新节点
            {
                tree = new binaryTreeNode(num);
                return;
            }

            if (num < tree.number) // 所给节点值小于当前节点值，则放到左边
            {
                if (tree.leftChild == null)
                {
                    binaryTreeNode nd = new binaryTreeNode(num);
                    tree.leftChild = nd;
                }
                else
                {
                    insertNode(ref tree.leftChild, num);
                }
            }
            else // 所给节点值大于或等于当前节点值，则放到右边
            {
                if (tree.rightChild == null)
                {
                    binaryTreeNode nd = new binaryTreeNode(num);
                    tree.rightChild = nd;
                }
                else
                {
                    insertNode(ref tree.rightChild, num);
                }
            }
        }

        private string DLR_Order(binaryTreeNode td) // 先序遍历
        {
            string rlt = ""; // 初始化结果字符串

            if (td != null)
            {
                rlt += td.number + " "; // 先访问根节点
                rlt += DLR_Order(td.leftChild); // 递归访问左子树
                rlt += DLR_Order(td.rightChild); // 递归访问右子树
            }

            return rlt; // 返回结果
        }

        private string LDR_Order(binaryTreeNode td) // 中序遍历
        {
            string rlt = ""; // 初始化结果字符串

            if (td != null)
            {
                rlt += LDR_Order(td.leftChild); // 递归访问左子树
                rlt += td.number + " "; // 访问根节点
                rlt += LDR_Order(td.rightChild); // 递归访问右子树
            }

            return rlt; // 返回结果
        }

        private string LRD_Order(binaryTreeNode td) // 后序遍历
        {
            string rlt = ""; // 初始化结果字符串

            if (td != null)
            {
                rlt += LRD_Order(td.leftChild); // 递归访问左子树
                rlt += LRD_Order(td.rightChild); // 递归访问右子树
                rlt += td.number + " "; // 最后访问根节点
            }

            return rlt; // 返回结果
        }

        private void showTree(TreeNode treeViewNode, binaryTreeNode binTree)
        {
            TreeNode nd = new TreeNode(); // 创建新的 TreeNode
            if (binTree != null)
            {
                nd.Text = binTree.number.ToString(); // 设置节点文本
                treeViewNode.Nodes.Add(nd); // 将新节点添加到当前 TreeNode 的子节点中

                if (binTree.leftChild != null) // 如果存在左子树
                {
                    showTree(nd, binTree.leftChild); // 递归显示左子树
                }

                if (binTree.rightChild != null) // 如果存在右子树
                {
                    showTree(nd, binTree.rightChild); // 递归显示右子树
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("请输入一个有效的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int value;
            if (!int.TryParse(textBox1.Text, out value))
            {
                MessageBox.Show("请输入一个有效的整数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (binTree == null)
            {
                binTree = new binaryTreeNode(value); // 创建根节点
            }
            else
            {
                insertNode(ref binTree, value); // 插入新节点
            }

            // 清空 TreeView 并重新构建树
            treeView1.Nodes.Clear();
            TreeNode rootNode = new TreeNode(binTree.number.ToString()); // 添加根节点
            treeView1.Nodes.Add(rootNode);

            // 显示左子树和右子树
            showTree(rootNode, binTree);

            // 展开所有节点
            treeView1.ExpandAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (binTree == null)
            {
                MessageBox.Show("二叉树为空，请先插入节点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            label3.Text = DLR_Order(binTree); // 调用先序遍历方法
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (binTree == null)
            {
                MessageBox.Show("二叉树为空，请先插入节点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            label4.Text = LDR_Order(binTree); // 调用中序遍历方法
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (binTree == null)
            {
                MessageBox.Show("二叉树为空，请先插入节点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            label5.Text = LRD_Order(binTree); // 调用后序遍历方法
        }
    }
}
