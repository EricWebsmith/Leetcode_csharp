namespace Leetcode5992;


public class Solution
{
    const int BAD = 0;
    const int GOOD = 1;
    const int UNKNOWN = 2;
    int[][] statements;
    int n;

    int PopCount(int num)
    {
        int ans = 0;
        for (int temp = 1; temp < (1 << 15); temp <<= 1)
        {
            if ((num & temp) > 0)
            {
                ans++;
            }
        }
        return ans;
    }

    bool Contradicts(int mask)
    {
        for (int i = 0; i < n; i++)
        {
            bool iGood = (mask & (1 << i)) > 0;
            if (!iGood)
            {
                continue;
            }

            for (int j = 0; j < n; j++)
            {
                if (statements[i][j] == UNKNOWN)
                {
                    continue;
                }

                int jGoodBad = (mask & (1 << j)) > 0 ? GOOD : BAD;
                if (statements[i][j] != jGoodBad)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public int MaximumGood(int[][] statements)
    {
        this.statements = statements;
        n = statements.Length;

        int ans = 0;
        for (int mask = 1; mask < 1 << n; mask++)
        {
            if (!Contradicts(mask))
            {
                ans = Math.Max(ans, PopCount(mask));
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string statementsStr, int expected)
    {
        int[][] statements = statementsStr.LeetcodeToArray2D();
        int actual =  new Solution().MaximumGood(statements);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[2,1,2],[1,2,2],[2,0,2]]", 2); }
    [TestMethod] public void Test2() { TestBase("[[2,0],[0,2]]", 1); }
    [TestMethod] public void Test3() { TestBase("[[2,1,2,2],[1,2,2,2],[2,0,2,2],[2,0,2,2]]", 2); }
    //[TestMethod] public void Test4() { TestBase(); }

}