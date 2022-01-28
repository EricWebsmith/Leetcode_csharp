namespace Leetcode0421;

public class Solution
{
    public int FindMaximumXOR(int[] nums)
    {
        int mask = 0;
        int max = 0;
        for(int i = 31; i >= 0; i--)
        {
            mask = mask | (1 << i);
            HashSet<int> set = new HashSet<int>();
            foreach(int num in nums)
            {
                set.Add(mask & num);
            }

            int tmp = max | (1 << i);
            foreach(int prefix in set)
            {
                if(set.Contains(tmp ^ prefix))
                {
                    max = tmp;
                    break;
                }
            }
        }

        return max;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().FindMaximumXOR(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3,10,5,25,2,8]", 28); }
    [TestMethod] public void Test2() { TestBase("[14,70,53,83,49,91,36,80,92,51,66,70]", 127); }
    [TestMethod] public void Test3() { TestBase("[3,4,1,2]", 7); }
    [TestMethod] public void Test4() { TestBase("[3,4,1,2,5]", 7); }
    [TestMethod] public void Test5() { TestBase("[3,4,1,2,5]", 7); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }
}