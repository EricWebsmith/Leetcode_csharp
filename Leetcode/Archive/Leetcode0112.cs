namespace Leetcode112
{


    //Definition for a binary tree node.
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

    public class Solution
    {
        public int Target { get; set; }
        public bool HasTarget { get; set; }
        public List<int> PathSums = new List<int>();

        public void GetPathSum(TreeNode node, int path_sum)
        {
            if (HasTarget)
            {
                return;
            }

            if (node is null)
            {
                return;
            }

            if (node.left == null && node.right == null)
            {
                if (path_sum + node.val == Target)
                {
                    HasTarget = true;
                }
            }

            if (node.left != null)
            {
                GetPathSum(node.left, path_sum + node.val);
            }

            if (node.right != null)
            {
                GetPathSum(node.right, path_sum + node.val);
            }
        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            Target = targetSum;
            HasTarget = false;
            GetPathSum(root, 0);
            return HasTarget;
        }
    }
}