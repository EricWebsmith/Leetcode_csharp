namespace Leetcode0117;

[DebuggerDisplay("{val}")]
public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}

public class Solution
{
    public Node Connect(Node root)
    {
        if(root == null)
        {
            return null;
        }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        int qCount = 1;
        while (qCount > 0)
        {
            Node previousNode = null;
            for (int i = 0; i< qCount; i++)
            {
                Node node = queue.Dequeue();

                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }

                if(previousNode != null)
                {
                    previousNode.next = node;
                }
                previousNode = node;
            }
            qCount = queue.Count;
        }
        return root;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "1,2,3,4,5,null,7")]
    [DataRow(2, "[]")]
    [TestMethod]
    public void Test(int order, string rootStr)
    {
        Node root = NodeHelper.ToTree(rootStr);
        Solution solution = new Solution();
        solution.Connect(root);
    }
}

public static class NodeHelper
{
    public static Node ToTree(string rootStr)
    {
        string[] arr = rootStr
            .Replace("[", "")
            .Replace("]", "")
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        int?[] nodes = new int?[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == "null")
            {
                nodes[i] = null;
            }
            else
            {
                nodes[i] = int.Parse(arr[i]);
            }
        }

        Queue<Node> q = new Queue<Node>();
        Node root = new Node(nodes[0].Value);
        q.Enqueue(root);
        int qCount = 1;
        int index = 1;
        while (qCount > 0)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Node node = q.Dequeue();

                if (index >= nodes.Length)
                {
                    return root;
                }

                if (nodes[index] != null)
                {
                    Node leftNode = new Node(nodes[index].Value);
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
                    Node rightNode = new Node(nodes[index].Value);
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
