namespace Leetcode0326;

/// <summary>
/// Runtime: 44 ms, faster than 96.85% of C# online submissions for Power of Three.
/// Memory Usage: 32.5 MB, less than 7.26% of C# online submissions for Power of Three.
/// </summary>
public class Solution
{
    public bool IsPowerOfThree(int n)
    {
        int[] threePowered = new int[] {
            1, 3, 9, 27, 81, 243, 729, 2187,
            6561, 19683, 59049, 177147, 531441,
            1594323, 4782969, 14348907, 43046721,
            129140163, 387420489, 1162261467 };
        return threePowered.Contains(n);
    }
}

/// <summary>
/// Runtime: 72 ms, faster than 27.76% of C# online submissions for Power of Three.
/// Memory Usage: 33.2 MB, less than 7.26% of C# online submissions for Power of Three.
/// </summary>
public class SolutionSlow
{
    public bool IsPowerOfThree(int n)
    {
        HashSet<int> numbers = new HashSet<int>();
        numbers.Add(1);
        numbers.Add(3);
        numbers.Add(9);
        numbers.Add(27);
        numbers.Add(81);
        numbers.Add(243);
        numbers.Add(729);
        numbers.Add(2187);
        numbers.Add(6561);
        numbers.Add(19683);
        numbers.Add(59049);
        numbers.Add(177147);
        numbers.Add(531441);
        numbers.Add(1594323);
        numbers.Add(4782969);
        numbers.Add(14348907);
        numbers.Add(43046721);
        numbers.Add(129140163);
        numbers.Add(387420489);
        numbers.Add(1162261467);
        return numbers.Contains(n);
    }
}



[TestClass]
public class SolutionTests
{
    [TestMethod]
    public void Print3Power()
    {
        HashSet<int> numbers = new HashSet<int>();
        int temp = 1;
        numbers.Add(temp);
        Console.WriteLine($"numbers.Add(1);");
        for (int i = 1; i < 32; i++)
        {
            temp = temp * 3;
            if (temp > 0)
            {
                numbers.Add(temp);
                Console.WriteLine($"numbers.Add({temp});");
            }
            else
            {
                break;
            }
            
        }

        numbers.ToArray().Print1D();
    }

    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}