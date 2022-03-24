namespace Leetcode1663;


public class Solution
{
    public string GetSmallestString(int n, int k)
    {
        int[] indices = new int[n];
        Array.Fill(indices, 1);
        k = k - n;
        for (int i = n - 1; i >= 0; i--)
        {
            if (k <= 25)
            {
                indices[i] = k+1;
                break;
            }
            if (k > 25)
            {
                indices[i] = 26;
                k = k - 25;
            }
        }

        StringBuilder stringBuilder = new StringBuilder(n);
        for (int i = 0; i < n; i++)
        {
            stringBuilder.Append((char)('a' - 1 + indices[i]));
        }
        return stringBuilder.ToString();
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int n, int k, string expected)
    {
        string actual = new Solution().GetSmallestString(n, k);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(3, 27, "aay"); }
    [TestMethod] public void Test2() { TestBase(5, 73, "aaszz"); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}


/*
Runtime: 92 ms, faster than 66.67% of C# online submissions for Smallest String With A Given Numeric Value.
Memory Usage: 42.2 MB, less than 33.33% of C# online submissions for Smallest String With A Given Numeric Value. 
 */