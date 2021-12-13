namespace Leetcode1446;

public class Solution
{
    public int MaxPower(string s)
    {
        int power = 1;
        int maxPower = 1;
        for (int i = 1; i < s.Length; i++)
        {
            if(s[i] == s[i - 1])
            {
                power++;
            }
            else
            {
                maxPower = Math.Max(maxPower,power);
                power = 1;
            }
        }

        maxPower = Math.Max(maxPower, power);

        return maxPower;
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