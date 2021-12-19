namespace Leetcode5957;


public class Solution
{
    public string AddSpaces(string s, int[] spaces)
    {
        int n = s.Length;
        int m = spaces.Length;
        int j = 0;
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < n; i++)
        {
            if(j<m && i == spaces[j])
            {
                sb.Append(' ');
                j++;
            }
            sb.Append(s[i]);
        }
        return sb.ToString();
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string s, string spacesStr, string expected)
    {
        int[] spaces = spacesStr.LeetcodeToArray();
        string actual = new Solution().AddSpaces(s, spaces);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("LeetcodeHelpsMeLearn", "[8,13,15]", "Leetcode Helps Me Learn"); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }
}