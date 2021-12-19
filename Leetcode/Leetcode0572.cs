namespace Leetcode0572;


public class Solution
{

    private bool IsSame(TreeNode root, TreeNode subRoot)
    {
        // bfs
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        Queue<TreeNode> subQueue = new Queue<TreeNode>();
        subQueue.Enqueue(subRoot);
        while(queue.Count > 0 && subQueue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            TreeNode subNode = subQueue.Dequeue();
            if(node.val != subNode.val)
            {
                return false;
            }

            if(node.left != null && subNode.left != null)
            {
                queue.Enqueue(node.left);
                subQueue.Enqueue(subNode.left);
            }
            else if(node.left == null && subNode.left == null)
            {
                //it is also okay.
            }
            else
            {
                return false;
            }

            if (node.right != null && subNode.right != null)
            {
                queue.Enqueue(node.right);
                subQueue.Enqueue(subNode.right);
            }
            else if (node.right == null && node.right == null)
            {
                //it is also okay.
            }
            else
            {
                return false;
            }
        }

        return queue.Count == subQueue.Count;
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();

            if(IsSame(node, subRoot))
            {
                return true;
            }

            if(node.left != null)
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
    [DataRow(1, "[3,4,5,1,2]", "[4,1,2]", true)]
    [DataRow(2, "[3,4,5,1,2,null,null,null,null,0]", "[4,1,2]", false)]
    [DataRow(3, "[3,4,5,1,2]", "[4,1]", false)]
    [DataRow(4, "[3,4,5,1,2]", "[4, 1, 2, 1]", false)]
    [DataTestMethod]
    public void Test(int order, string rootStr, string subRootStr, bool expected)
    {
        TreeNode root = TreeHelper.ToTree(rootStr);
        TreeNode subRoot = TreeHelper.ToTree(subRootStr);
        bool actual = (new Solution()).IsSubtree(root, subRoot);
        Assert.AreEqual(expected, actual);
    }
}
