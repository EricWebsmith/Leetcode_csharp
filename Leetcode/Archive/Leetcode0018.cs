namespace Leetcode0018;


public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {

        IList<IList<int>> list = new List<IList<int>>();
        List<int> current = new List<int>();

        Array.Sort(nums);
        KSum(4, 0, target);

        return list;

        void KSum(int k, int start, int target)
        {
            if (k != 2)
            {
                for (int i = start; i < nums.Length - k + 1; i++)
                {
                    if (i > start && nums[i] == nums[i - 1])
                    {
                        continue;
                    }

                    current.Add(nums[i]);
                    KSum(k - 1, i + 1, target - nums[i]);
                    current.RemoveAt(current.Count - 1);
                }
            }
            else if (k == 2)
            {
                int left = start;
                int right = nums.Length - 1;

                while (left < right)
                {
                    if (nums[left] + nums[right] > target)
                    {
                        right--;
                    }
                    else if (nums[left] + nums[right] < target)
                    {
                        left++;
                    }
                    else
                    {
                        var temp = new List<int>();
                        temp.Add(nums[left]);
                        temp.Add(nums[right]);
                        temp.AddRange(current);
                        list.Add(temp);

                        left++;

                        while (left < right && nums[left] == nums[left - 1])
                        {
                            left++;
                        }
                    }
                }
            }
        }
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int target, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        IList<IList<int>> actual = new Solution().FourSum(nums, target);
        actual.Print2D();
        Assert.AreEqual(expected, actual.Count);
    }

    [TestMethod] public void Test1() { TestBase("[1,0,-1,0,-2,2]", 0, 3); }
    [TestMethod] public void Test2() { TestBase("[2,2,2,2,2]", 8, 1); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 144 ms, faster than 96.52% of C# online submissions for 4Sum.
Memory Usage: 44.3 MB, less than 42.86% of C# online submissions for 4Sum.
 */