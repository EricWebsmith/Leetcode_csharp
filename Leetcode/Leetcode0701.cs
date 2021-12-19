namespace Leetcode0701;


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

    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        
        TreeNode newNode =new TreeNode(val);
        if (root == null) return newNode;

        TreeNode node = root;
        while (node != null)
        {
            if (node.val == val)
            {
                return node;
            }
            else if (node.val > val)
            {
                if(node.left == null)
                {
                    node.left = newNode;
                    return root;
                }
                node = node.left;
            }
            else
            {
                if (node.right == null)
                {
                    node.right = newNode;
                    return root;
                }
                node = node.right;
            }
        }
        return root;
    }


}