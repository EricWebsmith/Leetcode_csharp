namespace Leetcode0404;

/// <summary>
/// Runtime: 80 ms, faster than 86.87% of C# online submissions for Sum of Left Leaves.
/// Memory Usage: 37.8 MB, less than 44.18% of C# online submissions for Sum of Left Leaves.
/// </summary>
public class Solution
{
    int ans = 0;

    private void Dfs(TreeNode node)
    {
        if(node.left!= null)
        {
            if (node.left.left == null && node.left.right == null)
            {
                ans += node.left.val;
            }
            else
            {
                Dfs(node.left);
            }
        }

        if(node.right!= null)
        {
            Dfs(node.right);
        }
    }

    public int SumOfLeftLeaves(TreeNode root)
    {
        Dfs(root);
        return ans;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        int actual = new Solution().SumOfLeftLeaves(root);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3, 9, 20, null, null, 15, 7]", 24); }
    [TestMethod] public void Test2() { TestBase("[1]", 0); }
    [TestMethod] public void Test3() { TestBase("[1,2,3]",2); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,4]",4); }
}