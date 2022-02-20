namespace Leetcode0507;


public class Solution
{
    public bool CheckPerfectNumber(int num)
    {
        if(num == 1) { return false; }
        int sum = 1;
        for(int i = 2; i * i < num; i++)
        {
            if(num % i != 0)
            {
                continue;
            }

            sum += num / i + i;
        }

        return sum == num;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int num, bool expected)
    {
        bool actual = new Solution().CheckPerfectNumber(num);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase(1, false); }
    [TestMethod] public void Test02() { TestBase(2, false); }
    [TestMethod] public void Test06() { TestBase(6, true); }
    [TestMethod] public void Test07() { TestBase(7, false); }
    [TestMethod] public void Test08() { TestBase(8, false); }
    [TestMethod] public void Test09() { TestBase(9, false); }
    [TestMethod] public void Test10() { TestBase(10, false); }
    [TestMethod] public void Test12() { TestBase(12, false); }
    [TestMethod] public void Test28() { TestBase(28, true); }

}

[TestClass]
public class Exhaustion
{
    [TestMethod]
    public void Exhaust()
    {
        Solution s = new Solution();
        for (int i = 1; i <= 100000000; i++)
        {
            if (s.CheckPerfectNumber(i))
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}