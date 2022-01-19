namespace Leetcode1022;

/// <summary>
/// Runtime: 80 ms, faster than 93.69% of C# online submissions for Sum of Root To Leaf Binary Numbers.
/// Memory Usage: 38.2 MB, less than 53.15% of C# online submissions for Sum of Root To Leaf Binary Numbers.
/// </summary>
public class Solution
{

    int ans;

    private void Dfs(TreeNode node, int previous)
    {
        int value = previous * 2 + node.val;
        if (node.left == null && node.right == null)
        {
            ans += value;
            return;
        }

        if (node.left != null)
        {
            Dfs(node.left, value);
        }

        if (node.right != null)
        {
            Dfs(node.right, value);
        }
    }

    public int SumRootToLeaf(TreeNode root)
    {
        Dfs(root, 0);
        return ans;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        int actual = new Solution().SumRootToLeaf(root);
        Assert.AreEqual(actual, expected);
    }

    [TestMethod] public void Test1() { TestBase("[1,0,1,0,1,0,1]", 22); }
    [TestMethod] public void Test2() { TestBase("[1,1,1,0,1,0,1]", 26); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}