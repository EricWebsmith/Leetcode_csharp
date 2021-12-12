namespace Leetcode0103;

/// <summary>
/// Runtime: 116 ms, faster than 96.12% of C# online submissions for Binary Tree Zigzag Level Order Traversal.
/// Memory Usage: 41.1 MB, less than 13.90% of C# online submissions for Binary Tree Zigzag Level Order Traversal.
/// </summary>
public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        

        IList<IList<int>> result = new List<IList<int>>();
        if (root == null) { return result; }
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        int qCount = q.Count;
        bool odd = false;
        while(qCount > 0)
        {
            List<int> subList = new List<int>();
            for (int i=0; i < qCount; i++)
            {
                TreeNode node = q.Dequeue();
                subList.Add(node.val);

                if(node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
            qCount = q.Count;

            if (odd)
            {
                subList.Reverse();
            }
            odd = !odd;
            result.Add(subList);
        }

        //result.Print2D();

        return result;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, string expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        IList<IList<int>> actual = new Solution().ZigzagLevelOrder(root);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[3,9,20,null,null,15,7]", "[[3],[20,9],[15,7]]"); }
    [TestMethod] public void Test2() { TestBase("[1]", "[[1]]"); }
    [TestMethod] public void Test3() { TestBase("[]", "[]"); }
    //[TestMethod] public void Test4() { TestBase(); }
}