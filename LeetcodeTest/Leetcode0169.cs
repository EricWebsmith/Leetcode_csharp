namespace Leetcode0169;

public class Solution
{
    public int MajorityElement(int[] nums)
    {
        int count = 0;
        int result = -1;
        foreach(int num in nums)
        {
            if(count == 0)
            {
                result = num;
                count++;
            }
            else
            {
                if(result == num)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { 3,2,3}, 3)]
    [DataRow(1, new int[] { 2,2,1,1,1,2,2 }, 2)]
    [DataTestMethod]
    public void Test(int order,int[] nums, int expected)
    {
        int actual = (new Solution()).MajorityElement(nums);
        Assert.AreEqual(expected, actual);
    }
}