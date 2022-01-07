namespace Leetcode0015;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> result= new List<IList<int>>();

        if (nums.Length < 3)
        {
            return result;
        }

        List<int> sortedNums = nums.ToList();
        sortedNums.Sort();
        for(int i = 0; i < sortedNums.Count-2; i++)
        {
            int target = 0 - sortedNums[i];
            int lo = i + 1;
            int hi = sortedNums.Count - 1;

            if (i > 0 && sortedNums[i] == sortedNums[i - 1])
            {
                continue;
            }

            if (sortedNums[i] > 0)
            {
                break;
            }

            while (lo < hi)
            {
                int sum = sortedNums[lo] + sortedNums[hi];
                if(sum == target)
                {
                    List<int> item = new List<int>();
                    item.Add(sortedNums[i]);
                    item.Add(sortedNums[lo]);
                    item.Add(sortedNums[hi]);
                    result.Add(item);
                    while (lo<hi && sortedNums[lo] == sortedNums[lo+1])
                    {
                        lo++;
                    }
                    lo++;
                    while (hi>lo && sortedNums[hi] == sortedNums[hi - 1])
                    {
                        hi--;
                    }
                    hi--;
                }
                else if(sum > target)
                {
                    hi--;
                }
                else
                {
                    lo++;
                }
            }
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { -1, 0, 1, 2, -1, -4 }, 2)]
    [DataRow(2, new int[] { }, 0)]
    [DataRow(3, new int[] { 0 }, 0)]
    [DataRow(4, new int[] { -3, -2, -1, 0, 0, 1, 2, 3, 4 }, 6 )]
    [DataRow(5, new int[] { 5, -7, 8, 5, 1, 0, 0, 0, 2, -2, -3, -3 }, 5 )]
    [DataRow(6, new int[] { -3, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3 }, 7 )]
    [DataTestMethod]
    public void TestBase(int order, int[] nums, int expected)
    {
        var actual = (new Solution()).ThreeSum(nums);
        Assert.AreEqual(expected, actual.Count);
    }
}
