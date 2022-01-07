namespace Leetcode0090;

public class Solution
{
    int[] nums;
    List<int> current = new List<int>();
    IList<IList<int>> ans = new List<IList<int>>();

    private void Dfs(int startIndex)
    {
        ans.Add(current.ToList());
        if (startIndex >= nums.Length)
        {
            return;
        }

        for (int i = startIndex; i < nums.Length; i++)
        {
            if (i > startIndex && nums[i] == nums[i - 1])
            {
                continue;
            }
            current.Add(nums[i]);
            Dfs(i + 1);
            current.RemoveAt(current.Count - 1);

        }
    }

    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        Array.Sort(nums);
        this.nums = nums;
        Dfs(0);
        return ans;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[1,2,2]", 6)]
    [DataRow(2, "[0]", 2)]
    [DataRow(3, "[0, 0]", 3)]
    [DataRow(4, "[0, 0, 0]", 4)]
    [DataRow(5, "[2,1,2]", 6)]
    [DataTestMethod]
    public void Test(int order, string numsStr, int expected)
    {
        int[] nums = Helper.Convert1D(numsStr);
        IList<IList<int>> actual = new Solution().SubsetsWithDup(nums);
        Helper.Print2D(actual);

        Assert.AreEqual(expected, actual.Count);
    }
}
