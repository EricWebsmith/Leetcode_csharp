namespace Leetcode0257;

/// <summary>
/// Runtime: 132 ms, faster than 91.88% of C# online submissions for Binary Tree Paths.
/// Memory Usage: 42.6 MB, less than 33.61% of C# online submissions for Binary Tree Paths.
/// </summary>
public class Solution
{
    List<int> current = new List<int>();
    List<string> result = new List<string> ();

    private void SaveResult()
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0;i < current.Count - 1; i++)
        {
            sb.Append(current[i]);
            sb.Append("->");
        }
        sb.Append(current.Last());
        result.Add (sb.ToString());
    }

    private void Dfs(TreeNode node)
    {
        if(node.left == null && node.right == null)
        {
            current.Add(node.val);
            SaveResult();
            current.RemoveAt(current.Count - 1);
            return;
        }

        if(node.left != null)
        {
            current.Add(node.val);
            Dfs(node.left);
            current.RemoveAt(current.Count - 1);
        }

        if (node.right != null)
        {
            current.Add(node.val);
            Dfs(node.right);
            current.RemoveAt(current.Count - 1);
        }

    }

    public IList<string> BinaryTreePaths(TreeNode root)
    {
        Dfs(root);
        return result;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}