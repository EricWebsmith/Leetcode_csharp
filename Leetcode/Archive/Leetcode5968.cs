namespace Leetcode5968;


public class Solution
{
    private int CountBeams(string beams)
    {
        int currentBeams = 0;
        foreach (char beam in beams)
        {
            if (beam == '1')
            {
                currentBeams++;
            }
        }
        return currentBeams;
    }

    public int NumberOfBeams(string[] bank)
    {
        int previousBeams = 0;
        int ans = 0;
        foreach(string beams in bank)
        {
            int currentBeams = CountBeams(beams);

            if (currentBeams == 0)
            {
                continue;
            }

            ans += previousBeams * currentBeams;
            previousBeams = currentBeams;
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string bankStr, int expected)
    {
        string[] bank = bankStr.LeetcodeToStringArray();
        int actual = new Solution().NumberOfBeams(bank);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[011001, 000000, 010100, 001000]", 8); }
    [TestMethod] public void Test2() { TestBase("[000, 111, 000]", 0); }
    [TestMethod] public void Test3() { TestBase("[000, 000]", 0); }
    [TestMethod] public void Test4() { TestBase("[000, 111, 000, 000, 000, 010]", 3); }
}