namespace Leetcode0191;

public class Solution
{
    public int HammingWeight(uint n)
    {
        uint[] arr = new uint[32];
        uint result = 0;
        int index = 31;
        while (n > 0)
        {
            uint r = n % 2;
            result += r;
            n = n / 2;
            index--;
        }
        return (int)result;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(uint n, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.HammingWeight(n);
        Assert.AreEqual(expected, actual);
    }



    [TestMethod]
    public void Test1() { TestBase(11, 3); }

    [TestMethod]
    public void Test2() { TestBase(128, 1); }

    //[TestMethod]
    //public void Test2() { TestBase(Math.Pow(2, 32) - 2, 31); }


}

//Runtime: 28 ms, faster than 92.96% of C# online submissions for Number of 1 Bits.
//Memory Usage: 26.8 MB, less than 15.92% of C# online submissions for Number of 1 Bits.