namespace Leetcode0105;

/// <summary>
/// Runtime: 76 ms, faster than 98.88% of C# online submissions for Construct Binary Tree from Preorder and Inorder Traversal.
/// Memory Usage: 39.9 MB, less than 56.32% of C# online submissions for Construct Binary Tree from Preorder and Inorder Traversal.
/// </summary>
public class Solution
{
    int[] preorder;
    int[] inorder;

    private TreeNode BuildTree(int preorderLeft, int preorderRight, int inorderLeft, int inorderRight)
    {
        if(preorderLeft > preorderRight)
        {
            return null;
        }

        TreeNode root = new TreeNode(preorder[preorderLeft]);

        if (preorderLeft == preorderRight)
        {
            return root;
        }

        // find root in inorder
        int inorderRootIndex = 0;
        for (int i = inorderLeft; i <= inorderRight; i++)
        {
            if (inorder[i] == root.val)
            {
                inorderRootIndex = i;
                break;
            }
        }

        int leftCount = inorderRootIndex - inorderLeft;

        root.left = BuildTree(preorderLeft + 1, preorderLeft + leftCount, inorderLeft, inorderLeft + leftCount-1);
        root.right = BuildTree(preorderLeft + 1 + leftCount, preorderRight, inorderLeft+1 + leftCount, inorderRight);
        return root;
    }


    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        int n = preorder.Length;
        this.preorder = preorder;
        this.inorder = inorder;

        return BuildTree(0, n-1, 0, n-1);
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string preorderStr, string inorderStr, string expected)
    {
        int[] preorder = preorderStr.LeetcodeToArray();
        int[] inorder = inorderStr.LeetcodeToArray();
        TreeNode actual = new Solution().BuildTree(preorder, inorder);
        string actualStr = actual.ToLeetcode();
        Assert.AreEqual(expected, actualStr);
    }

    [TestMethod] public void Test1() { TestBase("[3,9,20,15,7]", "[9,3,15,20,7]", "[3,9,20,null,null,15,7]"); }
    [TestMethod] public void Test2() { TestBase("[-1]", "[-1]", "[-1]"); }
    [TestMethod] public void Test3() { TestBase("[1,2]", "[2,1]", "[1,2]"); }
}