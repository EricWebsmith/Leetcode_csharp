namespace Leetcode0016;

public class Solution
{
    private int TwoSumClosest(List<int> list, int target)
    {
        int distance = 1000;
        int lo = 0;
        int hi = list.Count - 1;
        while (lo < hi)
        {
            int current_distance = list[lo] + list[hi] - target;
            if (Math.Abs(current_distance) < Math.Abs(distance))
            {
                distance = current_distance;
            }

            if (list[lo] + list[hi] == target)
            {
                return target + 0;
            }
            else if (list[lo] + list[hi] > target)
            {
                hi--;
            }
            else
            {
                lo++;
            }
        }

        return target + distance;
    }

    public int ThreeSumClosest(int[] nums, int target)
    {
        var list = nums.ToList();
        list.Sort();

        int distance = 10000;

        for (int i = 0; i < list.Count; i++)
        {
            var newList = list.ToList();
            int lookfor = target - list[i];
            newList.RemoveAt(i);
            int closest = TwoSumClosest(newList, lookfor);
            int currentDistance = closest - lookfor;
            if (Math.Abs(currentDistance) < Math.Abs(distance))
            {
                distance = currentDistance;
            }
        }

        return target + distance;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int target, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.ThreeSumClosest(nums, target);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { -1, 2, 1, -4 }, 1, 2); }
    [TestMethod] public void Test2() { TestBase(new int[] { 0, 0, 0, }, 1, 0); }
    [TestMethod] public void Test3() { TestBase(new int[] { 1, 1, -1, }, 2, 1); }
    [TestMethod] public void Test4() { TestBase(new int[] { -1, 0, 1, 1, 55 }, 3, 2); }

}
