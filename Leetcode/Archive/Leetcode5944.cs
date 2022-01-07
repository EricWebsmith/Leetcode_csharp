namespace Leetcode5944;

// 2096

public class Solution
{
    int startValue;
    int destValue;
    string s1;
    string s2;
    bool s1found = false;
    bool s2found = false;
     List<char> current = new List<char>();


    private void Dfs(TreeNode node)
    {
        if(s1found && s2found) { return; }

        if(node == null) { return; }

        if(node.val == startValue)
        {
            s1 = string.Join(string.Empty, current);
            s1found = true;
        }

        if(node.val == destValue)
        {
            s2 = string.Join(string.Empty, current);
            s2found = true;
        }

        current.Add('L');
        Dfs(node.left);
        current.RemoveAt(current.Count-1);

        current.Add('R');
        Dfs(node.right);
        current.RemoveAt(current.Count - 1);
    }

    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        this.startValue = startValue;
        this.destValue = destValue;
        Dfs(root);


        int limit = Math.Min(s1.Length, s2.Length);
        int commonRoot = limit;
        for (int i = 0;i < limit; i++)
        {
            if (s1[i] != s2[i])
            {
                commonRoot = i;
                break;
            }
        }

        //string.Join(string.Empty, s2.Substring(commonRoot).Reverse());

        return s1.Substring(commonRoot).Replace("R", "U").Replace("L", "U") + s2.Substring(commonRoot);
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string headStr, int startvalue, int destvalue, string explected)
    {
        TreeNode head = headStr.LeetcodeToTree();
        string actual = new Solution().GetDirections(head, startvalue, destvalue);
        Assert.AreEqual(explected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[5,1,2,3,null,6,4]", 3, 6, "UURL"); }
    [TestMethod] public void Test2() { TestBase("[2,1]", 2, 1, "L"); }
    [TestMethod] public void Test3() { TestBase("[1,2]", 2, 1, "U"); }
    [TestMethod] public void Test4() { TestBase("[13,5,4,7,null,8,6,3,null,null,12,9,1,null,null,11,null,null,10,null,null,null,null,2]", 3, 2, "UUURRLRL"); }
    [TestMethod] public void Test5() { TestBase("[5,8,3,1,null,4,7,6,null,null,null,null,null,null,2]", 4, 3, "U"); }
}