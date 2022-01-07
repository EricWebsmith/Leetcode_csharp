namespace Leetcode0338;

/// <summary>
/// Runtime: 72 ms, faster than 99.11% of C# online submissions for Counting Bits.
/// Memory Usage: 38.1 MB, less than 23.06% of C# online submissions for Counting Bits.
/// </summary>
public class Solution
{
    public int[] CountBits(int n)
    {
        int ones = 0;
        List<bool> list = new List<bool>();
        list.Add(false);
        int[] result = new int[n + 1];
        result[0] = 0;
        for (int i=0;i<n;i++)
        {
            bool carry = true;
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j])
                {
                    ones--;
                    list[j] = false;
                }
                else
                {
                    ones++;
                    list[j] = true;
                    carry = false;
                    break;
                }
            }
            if (carry)
            {
                list.Add(carry);
                ones++;
            }
            result[i + 1] = ones;
        }
        return result;
    }
}

/// <summary>
/// Runtime: 88 ms, faster than 64.75% of C# online submissions for Counting Bits.
/// Memory Usage: 38 MB, less than 38.80% of C# online submissions for Counting Bits.
/// </summary>
public class Solution_Generator
{
    private IEnumerator<int> Generator()
    {
        //int i = 0;
        int ones = 0;
        yield return ones;
        List<bool> list = new List<bool>();
        list.Add(false);
        while (true)
        {
            bool carry = true;
            for(int i =0;i < list.Count; i++)
            {
                if (list[i])
                {
                    ones--;
                    list[i] = false;
                }
                else
                {
                    ones++;
                    list[i] = true;
                    carry=false;
                    break;
                }
            }
            if (carry)
            {
                list.Add(carry);
                ones++;
            }
            yield return ones;
        }
    }

    public int[] CountBits(int n)
    {
        var g = Generator();
        int[] result = new int[n+1];
        for(int i = 0; i <= n; i++)
        {
            g.MoveNext();
            result[i] = g.Current;
        }
        return result;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int n)
    {
        var actual = new Solution().CountBits(n);
        Console.WriteLine(actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase(1); }
    [TestMethod] public void Test2() { TestBase(2); }
    [TestMethod] public void Test3() { TestBase(5); }
    [TestMethod] public void Test4() { TestBase(10); }
    [TestMethod] public void Test_Performance() 
    {
        var actual = new Solution().CountBits(100000);
    }
}