namespace Leetcode0230;

public class Solution
{
    List<int> current = new List<int>();
    int k;

    public int KthSmallest(TreeNode root, int k)
    {
        this.k = k;
        Dfs(root);

        return current[k-1];
    }

    private void Dfs(TreeNode root)
    {
        int value = root.val;
        if(root.left != null)
        {
            Dfs(root.left);
        }

        current.Add(value);

        if(current.Count >= k)
        {
            return;
        }

        if(root.right != null)
        {
            Dfs(root.right);
        }
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int k, int expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        int actual = new Solution().KthSmallest(root, k);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3,1,4,null,2]", 1,1); }
    [TestMethod] public void Test2() { TestBase("[5,3,6,2,4,null,null,1]", 3, 3); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }
}