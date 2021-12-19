namespace Leetcode0572Dfs;

public class Solution
{

    private bool IsSame(TreeNode root, TreeNode subRoot)
    {
        if (root == null && subRoot == null) { return true; }
        if (root == null || subRoot == null) { return false; }
        if (root.val != subRoot.val) { return false; }
        return IsSame(root.left, subRoot.left) && IsSame(root.right, subRoot.right);
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (subRoot == null) { return true; }
        if (root == null) { return false; }
        if (IsSame(root, subRoot)) { return true; }
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[3,4,5,1,2]", "[4,1,2]", true)]
    [DataRow(2, "[3,4,5,1,2,null,null,null,null,0]", "[4,1,2]", false)]
    [DataRow(3, "[3,4,5,1,2]", "[4,1]", false)]
    [DataRow(4, "[3,4,5,1,2]", "[4, 1, 2, 1]", false)]
    [DataTestMethod]
    public void Test(int order, string rootStr, string subRootStr, bool expected)
    {
        TreeNode root = TreeHelper.ToTree(rootStr);
        TreeNode subRoot = TreeHelper.ToTree(subRootStr);
        bool actual = (new Solution()).IsSubtree(root, subRoot);
        Assert.AreEqual(expected, actual);
    }
}
