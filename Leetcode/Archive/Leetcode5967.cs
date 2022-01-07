namespace Leetcode5967;


public class Solution
{
    public bool CheckString(string s)
    {
        int n = s.Length;
        int lastA = -1;
        int firstB = -1;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == 'b')
            {
                firstB = i;
                break;
            }
            
        }

        for(int i = n-1; i >= 0; i--)
        {
            if (s[i] == 'a')
            {
                lastA = i;
                break;
            }
            
        }

        if(lastA == -1 || firstB == -1)
        {
            return true;
        }

        return firstB> lastA;
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