using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006
{
    class binaryTreeNode
    {
        public int number; // 节点数值
        public binaryTreeNode leftChild; // 左子树
        public binaryTreeNode rightChild; // 右子树

        // 构造函数
        public binaryTreeNode(int n)
        {
            number = n;
            leftChild = null;
            rightChild = null;
        }
    }
}
