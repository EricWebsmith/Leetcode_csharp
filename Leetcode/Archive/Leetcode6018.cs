namespace Leetcode6018;


public class Solution
{
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        int n = descriptions.Length;
        Dictionary<int, TreeNode> treeDict = new Dictionary<int, TreeNode>();
        Dictionary<int, int> rootDict = new Dictionary<int, int>(); 
        for (int i = 0; i < n; i++)
        {
            TreeNode? parent = null;
            if (treeDict.ContainsKey(descriptions[i][0]))
            {
                parent = treeDict[descriptions[i][0]];
            }
            else
            {
                parent = new TreeNode(descriptions[i][0]);
                treeDict[descriptions[i][0]] = parent;
            }

            TreeNode? child = null;
            if (treeDict.ContainsKey(descriptions[i][1]))
            {
                child = treeDict[descriptions[i][1]];
            }
            else
            {
                child = new TreeNode(descriptions[i][1]);
                treeDict[descriptions[i][1]] = child;
            }

            if (descriptions[i][2] == 1)
            {
                parent.left = child;
            }
            else
            {
                parent.right = child;
            }

            rootDict[descriptions[i][1]] = descriptions[i][0];
        }

        int rootVal = descriptions[0][0];
        while (rootDict.ContainsKey(rootVal))
        {
            rootVal = rootDict[rootVal];
        }

        return treeDict[rootVal];
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string descriptionsStr, string expected)
    {
        int[][] descriptions = descriptionsStr.LeetcodeToArray2D();
        TreeNode root = new Solution().CreateBinaryTree(descriptions);
        string actual = root.ToLeetcode();
        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]]", "[50,20,80,15,17,19]"); }
    [TestMethod] public void Test2() { TestBase("[[1,2,1],[2,3,0],[3,4,1]]", "[1,2,null,null,3,4]"); }
    [TestMethod] public void Test3() { TestBase("[[39,70,1],[13,39,1],[85,74,1],[74,13,1],[38,82,1],[82,85,1]]", "[38,82,null,85,null,74,null,13,null,39,null,70]"); }
}