namespace Leetcode0102;

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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        List<IList<int>> results = new List<IList<int>>();
        if(root == null)
        {
            return results;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0)
        {
            int count = queue.Count;
            List<int> layer = new List<int>();
            for (int i = 0; i < count; i++)
            {
                TreeNode node = queue.Dequeue();

                layer.Add(node.val);
                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                
                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            results.Add(layer);
        }
        return results;
    }
}