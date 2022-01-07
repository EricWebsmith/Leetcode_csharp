namespace Leetcode0374;


public class GuessGame
{
    public int pick = 0;

    public int guess(int num)
    {
        return pick.CompareTo(num);
    }
}

/// <summary>
/// Runtime: 32 ms, faster than 74.39% of C# online submissions for Guess Number Higher or Lower.
/// Memory Usage: 26.9 MB, less than 25.61% of C# online submissions for Guess Number Higher or Lower.
/// </summary>
public class Solution : GuessGame
{
    public int GuessNumber(int n)
    {
        int lo = 1;
        int hi = n;
        int mid = lo + (hi - lo) / 2;
        while (lo <= hi)
        {
            int guessResult = guess(mid);
            if (guessResult == 0)
            {
                return mid;
            }
            else if (guessResult > 0)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
            mid = lo + (hi - lo) / 2;
        }

        return -1;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(int n, int pick)
    {
        Solution solution = new Solution();
        solution.pick = pick;
        int actual = solution.GuessNumber(n);
        Assert.AreEqual(pick, actual);
    }

    [TestMethod] public void Test1() { TestBase(10, 6); }
    [TestMethod] public void Test2() { TestBase(1, 1); }
    [TestMethod] public void Test3() { TestBase(2, 1); }
    [TestMethod] public void Test4() { TestBase(100, 95); }
}