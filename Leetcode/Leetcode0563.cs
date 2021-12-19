namespace Leetcode0563;

/// <summary>
/// Runtime: 100 ms, faster than 63.01% of C# online submissions for Binary Tree Tilt.
/// Memory Usage: 41.3 MB, less than 24.66% of C# online submissions for Binary Tree Tilt.
/// </summary>
public class Solution
{
    private Tuple<int, int> GetSumAndTilt(TreeNode node)
    {
        if(node == null) { return new Tuple<int, int>(0, 0); }

        Tuple<int, int> leftResult = GetSumAndTilt(node.left);
        Tuple<int, int> rightResult = GetSumAndTilt(node.right);
        return new Tuple<int, int>(node.val + leftResult.Item1 + rightResult.Item1, Math.Abs(leftResult.Item1 - rightResult.Item1) + leftResult.Item2+rightResult.Item2);
    }

    public int FindTilt(TreeNode root)
    {
        return GetSumAndTilt(root).Item2;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        int actual = new Solution().FindTilt(root);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,2,3]", 1); }
    [TestMethod] public void Test2() { TestBase("[4,2,9,3,5,null,7]", 15); }
    [TestMethod] public void Test3() { TestBase("[21,7,14,1,1,2,2,3,3]", 9); }
    [TestMethod] public void Test4() { TestBase("[]", 0); }
}
