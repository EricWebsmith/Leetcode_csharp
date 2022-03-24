namespace Leetcode1309;


public class Solution
{
    public string FreqAlphabets(string s)
    {
        int n = s.Length;
        string result = string.Empty;
        for(int i = n -1; i >= 0; i--)
        {
            if(s[i] == '#')
            {
                int order = (s[i-2]-'0') * 10 + (s[i - 1] - '0');
                result = (char)('a'-1+order) + result;
                i = i - 2;
                
            }
            else
            {
                int order = (s[i] - '0');
                result = (char)('a' - 1 + order) + result;
            }
        }
        return result;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string s, string expected)
    {
        string actual = new Solution().FreqAlphabets(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("10#11#12", "jkab"); }
    [TestMethod] public void Test2() { TestBase("1326#", "acz"); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}