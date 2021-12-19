namespace Leetcode0226;

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
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) { return null; }
        TreeNode temp = InvertTree(root.left);
        root.left = InvertTree(root.right);
        root.right = temp;
        return root;
    }

    public TreeNode InvertTree2(TreeNode root)
    {
        if (root == null) { return null; }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;
            if(node.left != null)
            {
                queue.Enqueue(node.left);
            }
            if(node.right != null)
            {
                queue.Enqueue(node.right);
            }                
        }

        return root;
    }
}