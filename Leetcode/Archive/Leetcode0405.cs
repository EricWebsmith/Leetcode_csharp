namespace Leetcode0405;

/// <summary>
/// Runtime: 64 ms, faster than 100.00% of C# online submissions for Convert a Number to Hexadecimal.
/// Memory Usage: 36.3 MB, less than 17.86% of C# online submissions for Convert a Number to Hexadecimal.
/// </summary>
public class Solution
{
    public string ToHex(int num)
    {
        if(num == 0) { return "0"; }
        Dictionary<int, char> map = new Dictionary<int, char>();
        map.Add(0, '0');
        map.Add(1, '1');
        map.Add(2, '2');
        map.Add(3, '3');
        map.Add(4, '4');
        map.Add(5, '5');
        map.Add(6, '6');
        map.Add(7, '7');
        map.Add(8, '8');
        map.Add(9, '9');
        map.Add(10, 'a');
        map.Add(11, 'b');
        map.Add(12, 'c');
        map.Add(13, 'd');
        map.Add(14, 'e');
        map.Add(15, 'f');
        map.Add(-1, 'f');
        map.Add(-2, 'e');
        map.Add(-3, 'd');
        map.Add(-4, 'c');
        map.Add(-5, 'b');
        map.Add(-6, 'a');
        map.Add(-7, '9');
        map.Add(-8, '8');
        map.Add(-9, '7');
        map.Add(-10, '6');
        map.Add(-11, '5');
        map.Add(-12, '4');
        map.Add(-13, '3');
        map.Add(-14, '2');
        map.Add(-15, '1');

        char[] chars = new char[8];
        for (int i = 0; i < 8; i++)
        {
            int move = (7 - i) * 4;
            int value = (num & (15 << move)) >> move;
            chars[i] = map[value];
        }

        string result = new string(chars);
        result = result.TrimStart('0');
        return result;
    }
}


[TestClass]
public class SolutionTests
{
    [TestMethod]
    public void Research()
    {
        Console.WriteLine((-1 >> 28) + (1 << 30) + (1 << 30));
        Console.WriteLine(-1 << 4);
        Console.WriteLine(-1 & 15);
        Console.WriteLine((-1 & (15<<4))>>4);
        Console.WriteLine((-1 & (15 << 8))>>8);
        Console.WriteLine(-1 & (15 << 12));
        Console.WriteLine(-1 & (15 << 16));
        Console.WriteLine(-1 & (15 << 20));
        Console.WriteLine(-1 & (15 << 24));
        Console.WriteLine(-1 & (15 << 28));
        Console.WriteLine(-1 & (15 << 32));
    }

    private void TestBase(int num, string expected)
    {
        string actual = new Solution().ToHex(num);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(26, "1a"); }
    [TestMethod] public void Test2() { TestBase(-1, "ffffffff"); }
    [TestMethod] public void Test3() { TestBase(5, "5"); }
    [TestMethod] public void Test4() { TestBase(10, "a"); }
    [TestMethod] public void Test5() { TestBase(-2147483648, "80000000"); }
}