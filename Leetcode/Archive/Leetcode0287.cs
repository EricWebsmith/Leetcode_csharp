namespace Leetcode0287;


public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        int n = nums.Length;
        for(int i = 0; i < n; i++)
        {
            int index = Math.Abs(nums[i])-1;
            if (nums[index] < 0)
            {
                return index + 1;
            }
            else
            {
                nums[index] = -nums[index];
            }
        }

        return 0;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 212 ms, faster than 83.22% of C# online submissions for Find the Duplicate Number.
Memory Usage: 50.2 MB, less than 14.84% of C# online submissions for Find the Duplicate Number. 
 */