namespace Leetcode6029;


public class Solution
{
    List<int> path = new List<int>();
    int[] aliceArrows = null;
    int maxScore = 0;
    int[] ans = null;

    private void Dfs(int section, int leftArrows, int score)
    {
        if(leftArrows < 0)
        {
            return;
        }

        if(section == 12)
        {
            if(score > maxScore)
            {
                maxScore = score;
                ans = path.ToArray();
            }
            return;
        }

        // take
        int price = aliceArrows[section] + 1;
        path.Add(price);
        Dfs(section+1, leftArrows - price, score+section);
        path.RemoveAt(path.Count-1);
        // not take
        path.Add(0);
        Dfs(section + 1, leftArrows, score);
        path.RemoveAt(path.Count - 1);
    }

    public int[] MaximumBobPoints(int numArrows, int[] aliceArrows)
    {
        this.aliceArrows = aliceArrows;
        Dfs(0, numArrows, 0);
        ans[0] += numArrows - ans.Sum();
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int numArrows, string aliceArrowsStr, int expected)
    {
        int[] aliceArrows = aliceArrowsStr.LeetcodeToArray();
        int[] actual = new Solution().MaximumBobPoints(numArrows, aliceArrows);
        actual.Print1D();
        Assert.AreEqual(numArrows, actual.Sum());
    }

    [TestMethod] public void Test1() { TestBase(9, "[1,1,0,1,0,0,2,1,0,1,2,0]", 47); }
    [TestMethod] public void Test2() { TestBase(3, "[0,0,1,0,0,0,0,0,0,0,0,2]", 27); }
    [TestMethod] public void Test3() { TestBase(89, "[3, 2, 28, 1, 7, 1, 16, 7, 3, 13, 3, 5]", 27); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}