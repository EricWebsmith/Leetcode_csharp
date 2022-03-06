namespace Leetcode0662;


public class Solution
{
    List<int> ids = new List<int>();

    private int Max(params int[] values)
    {
        int maxValue = values[0];
        for(int i = 1; i < values.Length; i++)
        {
            maxValue = Math.Max(maxValue, values[i]);
        }
        return maxValue;
    }

    private int Dfs(TreeNode root, int depth, int id)
    {
        if(root == null)
        {
            return 0;
        }

        if(ids.Count == depth)
        {
            ids.Add(id);
        }

        return Max(
            id - ids[depth] + 1,
            Dfs(root.left, depth + 1, (id - ids[depth]) * 2),
            Dfs(root.right, depth + 1, (id - ids[depth]) * 2 + 1)
            );
    }

    public int WidthOfBinaryTree(TreeNode root)
    {
        return Dfs(root, 0, 0);
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        int actual = new Solution().WidthOfBinaryTree(root);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,3,2,5,3,null,9]", 4); }
    [TestMethod] public void Test2() { TestBase("[1,3,null,5,3]", 2); }
    [TestMethod] public void Test3() { TestBase("[1,3,2,5]", 2); }
    string rootStr4 = "[1,1,1,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,null,1,1,null,1,null,1,null,1,null,1,null]";
    [TestMethod] public void Test4() { TestBase(rootStr4, 2147483645); }


}