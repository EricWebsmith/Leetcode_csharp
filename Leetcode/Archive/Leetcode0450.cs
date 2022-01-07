namespace Leetcode0450;


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
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        TreeNode supper = new TreeNode(1000000);
        supper.left = root;
        //search key
        TreeNode slow = supper;
        TreeNode keyNode = root;
        while (keyNode != null)
        {
            if (keyNode.val == key)
            {
                break;
            }
            else if(keyNode.val > key)
            {
                slow = keyNode;
                keyNode = keyNode.left;
            }
            else
            {
                slow = keyNode;
                keyNode = keyNode.right;
            }
        }

        if(keyNode == null)
        {
            return root;
        }

        bool left = keyNode.val < slow.val;
        if(keyNode.right == null)
        {
            if(left) slow.left = keyNode.left;
            else slow.right = keyNode.left;
            return supper.left;
        }

        if(keyNode.left == null)
        {
            if(left) slow.left = keyNode.right;
            else slow.right = keyNode.right;
            return supper.left;
        }

        if (left) slow.left = keyNode.right;
        else slow.right = keyNode.right;

        TreeNode current = keyNode.right;
        while(current.left != null)
        {
            current = current.left;
        }

        current.left = keyNode.left;

        return supper.left;

    }
}