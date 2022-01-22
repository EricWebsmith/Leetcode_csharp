namespace Leetcode2138;

/// <summary>
/// Runtime: 136 ms, faster than 86.34% of C# online submissions for Divide a String Into Groups of Size k.
/// Memory Usage: 43.2 MB, less than 8.78% of C# online submissions for Divide a String Into Groups of Size k.
/// </summary>
public class Solution
{
    public string[] DivideString(string s, int k, char fill)
    {
        int n = s.Length;
        int m = n / k;
        int remain = n % k;
        int resultLength = m;
        if (remain > 0)
        {
            resultLength++;
        }
        string [] result =new string [resultLength];
        for(int i = 0; i < m; i++) 
        {
            string item = s.Substring(i * k, k);
            result[i] = item;
        }

        
        if (remain > 0)
        {
            string lastItem = s.Substring(m*k, remain);
            for(int i = 0; i < k-remain; i++)
            {
                lastItem += fill;
            }
            result[m] = lastItem;
        }

        return result;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string s, int k, char fill)
    {
        string[] actual = new Solution().DivideString(s, k, fill);
        actual.Print1D();
    }

    [TestMethod] public void Test1() { TestBase("abcdefghi", 3, 'x'); }
    [TestMethod] public void Test2() { TestBase("abcdefghij", 3, 'x'); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}