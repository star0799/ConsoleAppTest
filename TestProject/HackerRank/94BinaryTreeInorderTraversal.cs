using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class _94BinaryTreeInorderTraversal
    {
        [Test]
        public void Main()
        {
            //     1
            //        2
            //     3
            //output: 1 3 2
            //TreeNode root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));

            //     1
            //        2
            //     3    4
            //output: 1 3 2 4
            TreeNode root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3), new TreeNode(4)));
            //TreeNode root = new TreeNode(1, new TreeNode(2));
            InorderTraversal(root);
        }

        //Stack作法
        //public IList<int> InorderTraversal(TreeNode root)
        //{
        //    List<int> result = new List<int>();
        //    Stack<TreeNode> stack = new Stack<TreeNode>();
        //    TreeNode curr = root;

        //    while (curr != null || stack.Count > 0)
        //    {
        //        while (curr != null)
        //        {
        //            stack.Push(curr);
        //            curr = curr.left;
        //        }

        //        curr = stack.Pop();
        //        result.Add(curr.val);
        //        curr = curr.right;
        //    }
        //    return result;
        //}

        //public IList<int> InorderTraversal(TreeNode root)
        //{
        //    List<int> res = new List<int>();
        //    TreeNode curr = root;
        //    TreeNode pre;
        //    while (curr != null)
        //    {
        //        if (curr.left == null)
        //        {
        //            res.Add(curr.val);
        //            curr = curr.right; // move to next right node
        //        }
        //        else
        //        { // has a left subtree
        //            pre = curr.left;
        //            while (pre.right != null)
        //            { // find rightmost
        //                pre = pre.right;
        //            }
        //            pre.right = curr; // put cur after the pre node
        //            TreeNode temp = curr; // store cur node
        //            curr = curr.left; // move cur to the top of the new tree
        //            temp.left = null; // original cur left be null, avoid infinite loops
        //        }
        //    }
        //    return res;
        //}

        //遞迴
        private IList<int> res;

        public IList<int> InorderTraversal(TreeNode root)
        {
            res = new List<int>();
            traverse(root);
            return res;
        }

        private void traverse(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            traverse(root.left);
            res.Add(root.val);
            traverse(root.right);
        }
    }
    public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }

