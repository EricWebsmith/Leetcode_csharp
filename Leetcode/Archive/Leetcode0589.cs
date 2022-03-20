namespace Leetcode0589;


public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}


public class Solution
{
    List<int> ans = new List<int> ();

    private void Dfs(Node node)
    {
        if (node == null)
        {
            return;
        }

        ans.Add(node.val);

        if (node.children != null)
        {
            foreach(Node child in node.children)
            {
                Dfs(child);
            }
        }
        
    }

    public IList<int> Preorder(Node root)
    {
        Dfs (root);
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}