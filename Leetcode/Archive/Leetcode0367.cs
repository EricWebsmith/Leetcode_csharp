namespace Leetcode0367;

/// <summary>
/// Runtime: 36 ms, faster than 89.64% of C# online submissions for Valid Perfect Square.
/// Memory Usage: 28.4 MB, less than 47.30% of C# online submissions for Valid Perfect Square.
/// </summary>
public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        int lo = 1;
        // Math.Sqrt(2147483647) == 46340.95
        // so the sqrt cannot be more than 46340
        // and it is guarrentied that 46340 * 46340 > 0 
        // (will not stack overflow)
        int hi =Math.Min(46340, num);
        int mid = lo + (hi - lo) / 2;
        while (lo <= hi)
        {
            int square = mid * mid;
            if (square == num)
            {
                return true;
            }
            else if (square > num)
            {
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;
            }
            mid = lo + (hi - lo) / 2;
        }
        return false;
    }
}


[TestClass]
public class SolutionTests
{
    [TestMethod]
    public void Print2()
    {
        int tmp = 1;
        while (tmp > 0)
        {
            Console.WriteLine(tmp);
            tmp = tmp << 2;
        }

        Console.WriteLine(Math.Pow(2, 16));
        Console.WriteLine(Math.Pow(2, 31));
        Console.WriteLine(Math.Pow(2, 32));
        Console.WriteLine(Math.Pow(2, 16) * Math.Pow(2, 16));
        Console.WriteLine(Math.Sqrt(2147395600));
        Console.WriteLine("SQRT max is:");
        Console.WriteLine(Math.Sqrt(2147483647));
    }

    private void TestBase(int num, bool expected)
    {
        bool actual = new Solution().IsPerfectSquare(num);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(16, true); }
    [TestMethod] public void Test2() { TestBase(14, false); }
    [TestMethod] public void Test3() { TestBase(9, true); }
    [TestMethod] public void Test4() { TestBase(32, false); }
    [TestMethod] public void Test5() { TestBase(4, true); }
    [TestMethod] public void Test6() { TestBase(100, true); }
    [TestMethod] public void Test7() { TestBase(101, false); }
    [TestMethod] public void Test8() { TestBase(1, true); }
    [TestMethod] public void Test9() { TestBase(2147483647, false); }
    [TestMethod] public void Test10() { TestBase(808201, true); }
    [TestMethod] public void Test11() { TestBase(1<<30, true); }
    [TestMethod] public void Test12() { TestBase(2147395600, true); }
}