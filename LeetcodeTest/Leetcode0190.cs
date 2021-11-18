namespace Leetcode0190;

public class Solution
{
    public uint reverseBits(uint n)
    {
        uint[] arr = new uint[32];

        int index = 31;
        while (n > 0)
        {
            uint r = n % 2;
            arr[index] = r;
            n = n / 2;
            index--;
        }

        uint times = 1;
        uint result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            result += arr[i] * times;
            times *= 2;
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(uint n, uint expected)
    {
        Solution solution = new Solution();
        uint actual = solution.reverseBits(n);
        Assert.AreEqual(expected, actual);
    }



    [TestMethod]
    public void Test2() { TestBase(43261596, 964176192); }


    [TestMethod]
    public void Test3() { TestBase(4294967293, 3221225471); }

}

// Runtime: 28 ms, faster than 92.68% of C# online submissions for Reverse Bits.
// Memory Usage: 26.7 MB, less than 29.67% of C# online submissions for Reverse Bits.