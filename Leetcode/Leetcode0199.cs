
namespace Leetcode0199;

/// <summary>
/// Runtime: 112 ms, faster than 97.90% of C# online submissions for Binary Tree Right Side View.
/// Memory Usage: 41.3 MB, less than 20.45% of C# online submissions for Binary Tree Right Side View.
/// </summary>
public class Solution
{
    public IList<int> RightSideView(TreeNode root)
    {
        IList<int> result = new List<int>();
        if(root == null)
        {
            return result;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int qCount = queue.Count;
        while (qCount > 0)
        {
            int current = 0;
            for(int i = 0; i < qCount; i++)
            {
                TreeNode node = queue.Dequeue();
                current = node.val;
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            result.Add(current);
            qCount = queue.Count;
        }

        //result.Print1D();

        return result;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, string expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        IList<int> actual = new Solution().RightSideView(root);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[1,2,3,null,5,null,4]", "[1,3,4]"); }
    [TestMethod] public void Test2() { TestBase("[1,null,3]", "[1,3]"); }
    [TestMethod] public void Test3() { TestBase("[]", "[]"); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,null,5,null]", "[1,3,5]"); }
}