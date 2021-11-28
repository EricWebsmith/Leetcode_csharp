namespace Leetcode5924;

public class Solution
{
    public int MinCost(int[] startPos, int[] homePos, int[] rowCosts, int[] colCosts)
    {
        int result = 0;
        int step = Math.Sign(homePos[0] - startPos[0]);
        if(step != 0)
        {
            for (int r = startPos[0]; step == 1 ? r <= homePos[0] :r  >= homePos[0]; r += step)
            {
                if (r == startPos[0])
                {
                    continue;
                }
                result += rowCosts[r];
            }
        }

        step = Math.Sign(homePos[1] - startPos[1]);
        if (step != 0)
        {
            for (int c = startPos[1]; step == 1 ? c <= homePos[1] : c >= homePos[1]; c += step)
            {
                if (c == startPos[1])
                {
                    continue;
                }
                result += colCosts[c];
            }
        }
        return result;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[1, 0]", "[2, 3]", "[5, 4, 3]", "[8, 2, 6, 7]", 18)]
    [DataRow(2, "[0, 0]", "[0, 0]", "[5]", "[26]", 0)]
    [DataTestMethod]
    public void Test(int order, string startPosStr, string homePosStr, string rowCostsStr, string colCostsStr, int expected)
    {
        int[] startPos = Helper.Convert1D(startPosStr);
        int[] homePos = Helper.Convert1D(homePosStr);
        int[] rowCosts = Helper.Convert1D(rowCostsStr);
        int[] colCosts = Helper.Convert1D(colCostsStr);
        int actual = new Solution().MinCost(startPos, homePos, rowCosts, colCosts);
        Assert.AreEqual(expected, actual);
    }
}