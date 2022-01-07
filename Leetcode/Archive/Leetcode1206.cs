namespace Leetcode1206;


public class Solution
{
    int ans = 0;

    private void Dfs(TreeNode node, int maxValue, int minValue)
    {

        int diff = Math.Max(maxValue - node.val, node.val - minValue);
        ans = Math.Max(ans, diff);

        maxValue = Math.Max(maxValue, node.val);
        minValue = Math.Min(minValue, node.val);

        if (node.left != null)
        {
            Dfs(node.left, maxValue, minValue);
        }

        if (node.right != null)
        {
            Dfs(node.right, maxValue, minValue);
        }
    }

    public int MaxAncestorDiff(TreeNode root)
    {
        Dfs(root, root.val, root.val);
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        int actual = new Solution().MaxAncestorDiff(root);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[8,3,10,1,6,null,14,null,null,4,7,13]", 7); }
    [TestMethod] public void Test2() { TestBase("[1,null,2,null,0,3]", 3); }
    [TestMethod] public void Test3() { TestBase("[1,2,3]", 2); }
    [TestMethod] public void Test4() { TestBase("[0]", 0); }
    [TestMethod] public void Test5() { TestBase("[2,null,0,1]", 2); }
}