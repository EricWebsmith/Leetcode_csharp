namespace Leetcode0113;

/// <summary>
/// Runtime: 120 ms, faster than 96.73% of C# online submissions for Path Sum II.
/// Memory Usage: 42.6 MB, less than 42.51% of C# online submissions for Path Sum II.
/// </summary>
public class Solution
{
    IList<IList<int>> result = new List<IList<int>>();
    IList<int> current = new List<int>();
    int targetSum;
    private void Dfs(TreeNode node, int sum)
    {
        if (node.left == null && node.right == null)
        {
            if (sum + node.val == targetSum)
            {
                var t = current.ToList();
                t.Add(node.val);
                result.Add(t);
            }
            return;
        }

        if (node.left != null)
        {
            current.Add(node.val);
            Dfs(node.left, sum + node.val);
            current.RemoveAt(current.Count - 1);
        }

        if (node.right != null)
        {
            current.Add(node.val);
            Dfs(node.right, sum + node.val);
            current.RemoveAt(current.Count - 1);
        }
    }

    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        if(root == null) { return result; }
        this.targetSum = targetSum;
        Dfs(root, 0);
        return result;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int targetSum, string expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        IList<IList<int>> actual = new Solution().PathSum(root, targetSum);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[5,4,8,11,null,13,4,7,2,null,null,5,1]", 22, "[[5,4,11,2],[5,8,4,5]]"); }
    [TestMethod] public void Test2() { TestBase("[1,2,3]", 5, "[]"); }
    [TestMethod] public void Test3() { TestBase("[1,2]", 0, "[]"); }
    [TestMethod] public void Test4() { TestBase("[]", 5, "[]"); }
    [TestMethod] public void Test5() { TestBase("[-2,null,-3]", -2, "[]"); }
}