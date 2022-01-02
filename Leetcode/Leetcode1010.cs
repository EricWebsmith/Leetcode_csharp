namespace Leetcode1010;


public class Solution
{
    public int NumPairsDivisibleBy60(int[] time)
    {
        Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();
        int n = time.Length;
        for (int i = 0; i < n; i++)
        {
            time[i] = time[i] % 60;
            if (!dict.ContainsKey(time[i]))
            {
                dict[time[i]] = new HashSet<int>();
            }

            dict[time[i]].Add(i);
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int complement = (60 - time[i]) % 60;
            if (!dict.ContainsKey(complement))
            {
                continue;
            }

            ans += dict[complement].Count;
            if (complement == 0 || complement == 30)
            {
                ans--;
            }

        }

        return ans / 2;
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