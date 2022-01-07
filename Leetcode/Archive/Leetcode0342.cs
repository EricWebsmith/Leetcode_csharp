namespace Leetcode0342;

/// <summary>
/// Runtime: 40 ms, faster than 78.13% of C# online submissions for Power of Four.
/// Memory Usage: 29.1 MB, less than 6.88% of C# online submissions for Power of Four.
/// </summary>
public class Solution
{
    public bool IsPowerOfFour(int n)
    {
        int[] validNums = new int[] { 
            1, 4, 16, 64, 256, 1024, 4096, 16384, 
            65536, 262144, 1048576, 4194304, 16777216,
            67108864, 268435456, 1073741824 };
        return validNums.Contains(n);
    }
}



[TestClass]
public class SolutionTests
{
    [TestMethod]
    public void Print()
    {
        int temp = 1;
        List<int> list = new List<int>();
        list.Add(temp);
        for(int i = 0; i < 16; i++)
        {
            temp = temp * 4;
            if (temp > 0)
            {
                list.Add(temp);
            }
            else
            {
                break;
            }
        }

        list.Print1D();
    }

    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}