namespace Leetcode0653;

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
    private bool FindVal(TreeNode node, int val)
    {
        if (node == null)
        {
            return false;
        }

        if (node.val == val)
        {
            return true;
        }
        else if(val < node.val)
        {
            return FindVal(node.left, val);
        }
        else
        {
            return FindVal(node.right, val);
        }

    }

    public bool FindTarget(TreeNode root, int k)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            //Console.WriteLine(node.val);
            
            int val = k - node.val;
            if(val != node.val && FindVal(root, val))
            {
                return true;
            }

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }
            if(node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }
        return false;
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void Test1()
    {
        TreeNode root = new TreeNode(5);
        TreeNode node3 = new TreeNode(3);
        TreeNode node6 = new TreeNode(6);
        TreeNode node2 = new TreeNode(2);
        TreeNode node4 = new TreeNode(4);
        TreeNode node7 = new TreeNode(7);

        root.left = node3;
        root.right = node6;
        node3.left = node2;
        node3.right = node4;
        node6.right = node7;

        Solution solution = new Solution();
        Assert.AreEqual(true, solution.FindTarget(root, 9));
        Assert.AreEqual(false, solution.FindTarget(root, 28));
    }

    [TestMethod]
    public void Test2()
    {
        TreeNode node2 = new TreeNode(2);
        TreeNode node1 = new TreeNode(1);
        TreeNode node3 = new TreeNode(3);
        node2.left = node1;
        node2.right = node3;

        Solution solution = new Solution();
        Assert.AreEqual(true, solution.FindTarget(node2, 4));
        Assert.AreEqual(false, solution.FindTarget(node2, 1));
        Assert.AreEqual(true, solution.FindTarget(node2, 3));
    }
}

