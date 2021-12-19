namespace Leetcode0938;

/// <summary>
/// Runtime: 172 ms, faster than 83.68% of C# online submissions for Range Sum of BST.
/// Memory Usage: 47.1 MB, less than 23.51% of C# online submissions for Range Sum of BST.
/// </summary>
public class Solution
{
    int low;
    int high;
    int sum;

    private void Dfs(TreeNode node)
    {
        int value = node.val;
        if(value>=low && value <= high)
        {
            sum += value;
        }
        
        if(node.left != null && value>low)
        {
            Dfs(node.left);
        }

        if(node.right != null && value < high)
        {
            Dfs(node.right);
        }
    }

    public int RangeSumBST(TreeNode root, int low, int high)
    {
        this.low = low;
        this.high = high;
        Dfs(root);
        return sum;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int low, int high, int expected)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        int actual = new Solution().RangeSumBST(root, low, high);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[10,5,15,3,7,null,18]", 7, 15, 32); }
    [TestMethod] public void Test2() { TestBase("[10,5,15,3,7,13,18,1,null,6]", 6, 10, 23); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }
}