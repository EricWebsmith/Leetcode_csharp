namespace Leetcode0659;

public class Solution
{
    public bool IsPossible(int[] nums)
    {
        Dictionary<int, int> c = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!c.ContainsKey(nums[i]))
            {
                c.Add(nums[i], 0);
            }
            c[nums[i]] = c[nums[i]] + 1;
        }

        Dictionary<int, int> ends = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (c[num] == 0)
            {
                continue;
            }

            c[num]--;

            if (ends.ContainsKey(num - 1) && ends[num - 1] > 0)
            {
                ends[num - 1]--;
                ends[num] = (ends.ContainsKey(num) ? ends[num] : 0) + 1;
            }
            else
            {
                if (c.ContainsKey(num + 1) && c.ContainsKey(num + 2)
                    && c[num + 1] > 0 && c[num + 2] > 0)
                {
                    c[num + 1]--;
                    c[num + 2]--;
                    ends[num + 2] = (ends.ContainsKey(num + 2) ? ends[num + 2] : 0) + 1;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, bool expected)
    {
        var nums = numsStr.LeetcodeToArray();
        bool actual = new Solution().IsPossible(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1, 2, 3, 3, 4, 5]", true); }
    [TestMethod] public void Test2() { TestBase("[1, 2, 3, 3, 4, 4, 5, 5]", true); }
    [TestMethod] public void Test3() { TestBase("[1, 2, 3, 4, 4, 5]", false); }
    [TestMethod] public void Test4() { TestBase("[3, 4, 4, 5, 6, 7, 8, 9, 10, 11]", false); }
}

/*
Runtime: 193 ms, faster than 95.00% of C# online submissions for Split Array into Consecutive Subsequences.
Memory Usage: 54.6 MB, less than 5.00% of C# online submissions for Split Array into Consecutive Subsequences.
 */