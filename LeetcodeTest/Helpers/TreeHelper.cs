namespace LeetcodeTest;

[DebuggerDisplay("{val}")]
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

public static class TreeHelper
{
    public static TreeNode LeetcodeToTree(this string rootStr)
    {
        string[] arr = rootStr
            .Replace("[","")
            .Replace("]", "")
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        int?[] nodes = new int?[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            if(arr[i] == "null")
            {
                nodes[i] = null;
            }
            else
            {
                nodes[i] = int.Parse(arr[i]);
            }
        }

        Queue<TreeNode> q = new Queue<TreeNode>();
        TreeNode root = new TreeNode(nodes[0].Value);
        q.Enqueue(root);
        int qCount = 1;
        int index = 1;
        while (qCount > 0)
        {
            for(int i=0; i < arr.Length; i++)
            {
                TreeNode node = q.Dequeue();

                if(index >= nodes.Length)
                {
                    return root;
                }

                if (nodes[index] != null)
                {
                    TreeNode leftNode = new TreeNode(nodes[index].Value);
                    node.left = leftNode;
                    q.Enqueue(leftNode);
                }
                index++;

                if (index >= nodes.Length)
                {
                    return root;
                }

                if (nodes[index] != null)
                {
                    TreeNode rightNode = new TreeNode(nodes[index].Value);
                    node.right = rightNode;
                    q.Enqueue(rightNode);
                }
                index++;
            }
            qCount = q.Count;
        }
        return root;
    }
}
