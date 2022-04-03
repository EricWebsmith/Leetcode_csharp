namespace Leetcode0365;


public class Solution
{
    private int getGcd(int a, int b)
    {
        if(b == 0)
        {
            return a;
        }

        return getGcd(b, a % b);
    }

    public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
    {
        if(jug1Capacity + jug2Capacity < targetCapacity)
        {
            return false;
        }

        int gcd = getGcd(jug1Capacity, jug2Capacity);
        return targetCapacity % gcd == 0;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int jug1Capacity, int jug2Capacity, int targetCapacity, bool expected)
    {
        bool actual = new Solution().CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(3, 5, 4, true); }
    [TestMethod] public void Test2() { TestBase(2, 6, 5, false); }
    [TestMethod] public void Test3() { TestBase(1, 2, 3, true); }
    [TestMethod] public void Test4() { TestBase(22003, 31237, 1, true); }

}