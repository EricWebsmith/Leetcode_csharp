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

    public override string ToString()
    {
        return val.ToString();
    }
}

public static class TreeHelper
{
    public static TreeNode LeetcodeToTree(this string rootStr)
    {
        if(rootStr == null) { return null; }
        if(rootStr == "[]") { return null; }

        string[] arr = rootStr
            .Replace("[","")
            .Replace("]", "")
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if(arr.Length == 0) { return null; }
        int?[] nodes = new int?[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            if(arr[i].Trim() == "null")
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

    public static string ToLeetcode(this TreeNode root)
    {
        if(root == null) { return "[]"; }
        List<int?> values = new List<int?>();
        

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        values.Add(root.val);
        int qCount = q.Count;
        while (qCount>0)
        {
            while(q.Count > 0)
            {
                TreeNode node = q.Dequeue();
                if(node.left != null)
                {
                    values.Add(node.left.val);
                    q.Enqueue(node.left);
                }
                else
                {
                    values.Add(null);
                }

                if(node.right != null)
                {
                    values.Add(node.right.val);
                    q.Enqueue(node.right);
                }
                else
                {
                    values.Add(null);
                }
            }
            qCount = q.Count;
        }

        int? last = values.Last();
        while (!last.HasValue)
        {
            values.RemoveAt(values.Count-1);
            last = values.Last();
        }

        StringBuilder sb = new StringBuilder();
        sb.Append('[');
        for (int i = 0; i < values.Count-1; i++)
        {
            if (values[i].HasValue)
            {
                sb.Append(values[i].Value);
                sb.Append(',');
            }
            else
            {
                sb.Append("null,");
            }
        }

        sb.Append(values[values.Count - 1].Value);

        sb.Append(']');
        return sb.ToString();
    }

    public static TreeNode GetNode(this TreeNode head, int val)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(head);
        while (q.Count > 0)
        {
            TreeNode node = q.Dequeue();
            if(node.val == val)
            {
                return node;
            }

            if(node.left != null)
            {
                q.Enqueue(node.left);
            }

            if(node.right!= null)
            {
                q.Enqueue(node.right);
            }
        }

        return null;
    }
}
