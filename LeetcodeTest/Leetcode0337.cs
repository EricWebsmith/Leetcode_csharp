namespace Leetcode0337;

/// <summary>
/// Runtime: 92 ms, faster than 69.59% of C# online submissions for House Robber III.
/// Memory Usage: 41.5 MB, less than 18.24% of C# online submissions for House Robber III.
/// </summary>
public class Solution
{
    Dictionary<TreeNode, int[]> map = new Dictionary<TreeNode, int[]>();

    private int[] Dfs(TreeNode node)
    {
        if (node == null) { return new int[] { 0, 0 }; }

        if (map.ContainsKey(node))
        {
            return map[node];
        }

        var left = Dfs(node.left);
        var right = Dfs(node.right);

        var income = new int[]
        {
            node.val + left[1] + right[1],
            Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]),
        };

        map.Add(node, income);

        return income;
    }

    public int Rob(TreeNode root)
    {
        var ans = Dfs(root);
        return ans.Max();
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        int actual = new Solution().Rob(root);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3,2,3,null,3,null,1]", 7); }
    [TestMethod] public void Test2() { TestBase("[3,4,5,1,3,null,1]", 9); }
}