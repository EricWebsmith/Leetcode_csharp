namespace Leetcode0022;

public class Solution
{
    int n = 0;
    IList<string> ans = new List<string>();


    private void Recurse(string t, int open, int close)
    {
        if (close == 0)
        {
            ans.Add(t);
            return;
        }

        if (close > open)
        {
            Recurse(t + ")", open, close - 1);
        }


        if (open > 0)
        {
            Recurse(t + "(", open - 1, close);
        }
    }

    public IList<string> GenerateParenthesis(int n)
    {
        this.n = n;
        ans.Clear();
        Recurse(string.Empty, n, n);
        return ans;
    }
}

[TestClass]
public class SolutionTests
{
    [TestMethod]
    public void Test1()
    {
        Solution solution = new Solution();
        int n = 3;
        IList<string> actual = solution.GenerateParenthesis(n);
        Helper.Print1D(actual);

    }

    [TestMethod]
    public void Test()
    {
        Solution solution = new Solution();
        int[] expected = { 0, 1, -1, 5, -1, -1, -1, -1, -1 };
        for (int n = 1; n <= 8; n++)
        {
            IList<string> actual = solution.GenerateParenthesis(n);
            Helper.Print1D(actual);
            if (expected[n] != -1)
            {
                Assert.AreEqual(expected[n], actual.Count);
            }
        }
    }
}