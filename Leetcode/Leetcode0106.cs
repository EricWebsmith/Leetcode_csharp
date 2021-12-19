namespace Leetcode0106;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    int[] inorder;
    int[] postorder;
    Dictionary<int, int> inorderDict = new Dictionary<int, int>();

    public TreeNode BuildTree(int inorderStart, int inorderEnd, int postorderStart, int postorderEnd)
    {
        if(inorderStart > inorderEnd)
        {
            return null;
        }

        if(inorderStart == inorderEnd)
        {
            return new TreeNode(inorder[inorderStart]);
        }

        int rootValue = postorder[postorderEnd];
        TreeNode root = new TreeNode(rootValue);
        int rootAt = inorderDict[rootValue] - inorderStart;

        root.left = BuildTree(inorderStart, inorderStart + rootAt - 1, postorderStart, postorderStart + rootAt - 1);
        root.right = BuildTree(inorderStart + rootAt + 1, inorderEnd, postorderStart+rootAt, postorderEnd-1);


        return root;
    }

    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        this.inorder = inorder;
        this.postorder = postorder;
        for(int i = 0; i < inorder.Length; i++)
        {
            inorderDict[inorder[i]] = i;
        }

        TreeNode root = BuildTree(0, inorder.Length-1, 0, inorder.Length-1);


        return root;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { 2, 1}, new int[] { 2, 1})]
    [DataRow(2, new int[] { 1, 2, 3, 4}, new int[] { 3, 2, 4, 1})]
    [DataTestMethod]
    public void Test(int order, int[] inorder, int[] postorder)
    {
        TreeNode actual = (new Solution()).BuildTree(inorder, postorder);
    }

    [TestMethod]
    public void Test1()
    {
        TreeNode node3 = new TreeNode(3);
        TreeNode node9 = new TreeNode(9);
        TreeNode node20 = new TreeNode(20);
        TreeNode node15 = new TreeNode(15);
        TreeNode node7 = new TreeNode(7);
        node3.left = node9;
        node3.right = node20;
        node20.left = node15;
        node15.right = node7;

        TreeNode actual = (new Solution()).BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });


    }
}

/*

[9,3,15,20,7]
[9,15,7,20,3]
[2,1]
[2,1]

 */