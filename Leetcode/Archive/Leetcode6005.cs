namespace Leetcode6005;


public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int n = nums.Length;
        int oddCount = n / 2;
        if (n % 2 == 1) { oddCount++; }
        int evenCount = n / 2;
        Dictionary<int, int> oddDict = new Dictionary<int, int>();
        Dictionary<int, int> evenDict = new Dictionary<int, int>();
        for (int i = 0; i < n; i = i + 2)
        {
            if (!oddDict.ContainsKey(nums[i]))
            {
                oddDict.Add(nums[i], 0);
            }
            oddDict[nums[i]]++;
        }

        for (int i = 1; i < n; i = i + 2)
        {
            if (!evenDict.ContainsKey(nums[i]))
            {
                evenDict.Add(nums[i], 0);
            }
            evenDict[nums[i]]++;
        }

        int mostOdd = -1000000000;
        int mostOddCount = 0;
        int secondOddCount = 0;
        foreach (KeyValuePair<int, int> kv in oddDict)
        {
            if (kv.Value >= mostOddCount)
            {
                secondOddCount = mostOddCount;
                mostOddCount = kv.Value;
                mostOdd = kv.Key;
            }
            else if (kv.Value >= secondOddCount)
            {
                secondOddCount = kv.Value;
            }
        }

        int mostEven = -1000000000;
        int mostEvenCount = 0;
        int secondEvenCount = 0;
        foreach (KeyValuePair<int, int> kv in evenDict)
        {
            if (kv.Value >= mostEvenCount)
            {
                secondEvenCount = mostEvenCount;
                mostEvenCount = kv.Value;
                mostEven = kv.Key;
            }
            else if (kv.Value >= secondEvenCount)
            {
                secondEvenCount = kv.Value;
            }
        }

        if (mostOdd != mostEven)
        {
            return n - mostEvenCount - mostOddCount;
        }

        return n - Math.Max(mostOddCount + secondEvenCount, mostEvenCount + secondOddCount);

    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().MinimumOperations(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3,1,3,2,4,3]", 3); }
    [TestMethod] public void Test2() { TestBase("[1,2,2,2,2]", 2); }
    [TestMethod] public void Test3() { TestBase("[1]", 0); }
    [TestMethod] public void Test4() { TestBase("[2,2,2,2]", 2); }
    [TestMethod] public void Test5() { TestBase("[2,2,2,2,2]", 2); }
    [TestMethod] public void Test6() { TestBase("[2,2]", 1); }
    [TestMethod] public void Test7() { TestBase("[1,2]", 0); }
    [TestMethod] public void Test8() { TestBase("[1,2,3]", 1); }
    [TestMethod] public void Test9() { TestBase("[1,2,3,4]", 2); }
    [TestMethod] public void Test10() { TestBase("[1,2,3,4,5]", 3); }
    [TestMethod] public void Test11() { TestBase("[1,2,3,4,5,6]", 4); }
    [TestMethod] public void Test12() { TestBase("[-1]", 0); }
    [TestMethod] public void Test13() { TestBase("[-1,-1]", 1); }
    [TestMethod] public void Test14() { TestBase("[-1,1]", 0); }
    [TestMethod] public void Test15() { TestBase("[1,-1]", 0); }
    [TestMethod] public void Test16() { TestBase("[-1,-1,-1,1]", 1); }
    [TestMethod] public void Test17() { TestBase("[2,2,2,2,1]", 2); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}