namespace Leetcode0236;

public class Solution
{
    bool pFound = false;
    bool qFound = false;
    TreeNode p = null;
    TreeNode q = null;
    List<TreeNode> pPath = new List<TreeNode>();
    List<TreeNode> qPath = new List<TreeNode>();
    List<TreeNode> current = new List<TreeNode>();
    private void Dfs(TreeNode node)
    {
        
        if (node == p)
        {
            pFound = true;
            pPath = current.ToList();
        }
        if(node == q)
        {
            qFound = true;
            qPath = current.ToList();
        }

        if (pFound && qFound) { return; }

        if (node.left != null)
        {
            current.Add(node.left);
            Dfs(node.left);
            current.RemoveAt(current.Count - 1);    
        }

        if(node.right != null)
        {
            current.Add(node.right);
            Dfs(node.right);
            current.RemoveAt(current.Count - 1);
        }

    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        this.p = p;
        this.q = q;
        current.Add(root);
        Dfs(root);

        int i = 0;
        TreeNode lca = new TreeNode();

        pPath.Print1D();
        qPath.Print1D();

        while (i<pPath.Count && i<qPath.Count && pPath[i] == qPath[i])
        {
            lca = pPath[i];
            i++;
        }

        return lca;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string rootStr, int pVal, int qVal, int expectedVal)
    {
        TreeNode root = rootStr.LeetcodeToTree();
        TreeNode p = root.GetNode(pVal);
        TreeNode q = root.GetNode(qVal);
        TreeNode expected =root.GetNode(expectedVal);
        TreeNode actual = new Solution().LowestCommonAncestor(root, p, q);
        Assert.AreEqual(expected, actual);

    }

    [TestMethod] public void Test1() { TestBase("[3,5,1,6,2,0,8,null,null,7,4]", 5, 1, 3); }
    [TestMethod] public void Test2() { TestBase("[3,5,1,6,2,0,8,null,null,7,4]", 5, 4, 5); }
    [TestMethod] public void Test3() { TestBase("[1,2]", 1, 2, 2); }
    [TestMethod] public void Test4() { TestBase("[3,5,1,6,2,0,8,null,null,7,4]", 6, 4, 5); }
    [TestMethod] public void Test5() { TestBase("[3,5,1,6,2,0,8,null,null,7,4]", 7, 8, 3); }
}