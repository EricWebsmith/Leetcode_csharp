namespace Leetcode0709;


public class Solution
{
    public string ToLowerCase(string s)
    {
        StringBuilder sb = new StringBuilder();
        int diff = 'a' - 'A';
        foreach (char c in s)
        {
            char t = c;
            if (t>='A' && t <= 'Z')
            {
                t = (char)(c+diff);
            }
            sb.Append(t);
        }
        return sb.ToString();
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