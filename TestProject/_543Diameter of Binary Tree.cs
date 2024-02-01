using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class _543Diameter_of_Binary_Tree
    {
        [Test]
        public void Main()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right = new TreeNode(3);
            DiameterOfBinaryTree(root);
        }

        private int diameter; 
        public int DiameterOfBinaryTree(TreeNode root)
        {
            diameter = 0;
            CalculateHeight(root);
            return diameter;
        }

        private int CalculateHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftHeight = CalculateHeight(node.left);
            int rightHeight = CalculateHeight(node.right);

            diameter = Math.Max(diameter, leftHeight + rightHeight);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
