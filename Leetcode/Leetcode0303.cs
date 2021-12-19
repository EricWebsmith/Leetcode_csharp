namespace Leetcode0303;


/// <summary>
/// Runtime: 132 ms, faster than 96.09% of C# online submissions for Range Sum Query - Immutable.
/// Memory Usage: 56 MB, less than 12.61% of C# online submissions for Range Sum Query - Immutable.
/// </summary>
public class NumArray
{
    int[] nums;

    public NumArray(int[] nums)
    {
        //reduce
        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] += nums[i-1];
        }

        this.nums = nums;
    }

    public int SumRange(int left, int right)
    {
        if(left == 0)
        {
            return nums[right];
        }

        return nums[right] - nums[left-1];
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