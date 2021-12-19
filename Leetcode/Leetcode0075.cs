using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Leetcode0075;

public class Solution_TwoPointers
{
    private void Switch(int[] nums, int a, int b)
    {
        int temp = nums[a];
        nums[a] = nums[b];
        nums[b] = temp;
    }

    public void SortColors(int[] nums)
    {
        int p0 = 0;
        int p2 = nums.Length - 1;
        int p1left = -1;
        int p1right = -1;

        // 0 
        while (p0 < p2)
        {
            if (nums[p0] != 0 && nums[p2] == 0)
            {
                Switch(nums, p0, p2);
                p0++;
                p2--;
            }
            else if (nums[p0] == 0)
            {
                p0++;
            }
            else if (nums[p2] != 0)
            {
                p2--;
            }
        }

        // 1 
        p2 = nums.Length - 1;
        while (p0 < p2)
        {
            if (nums[p0] == 2 && nums[p2] != 2)
            {
                Switch(nums, p0, p2);
                p0++;
                p2--;
            }
            else if (nums[p0] != 2)
            {
                p0++;
            }
            else if (nums[p2] == 2)
            {
                p2--;
            }
        }
    }
}

public class Solution
{
    public void SortColors(int[] nums)
    {
        int c0 = 0;
        int c1 = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            switch (nums[i])
            {
                case 0: c0++; break;
                case 1: c1++; break;
            }
        }

        for (int i = 0; i < c0; i++)
        {
            nums[i] = 0;
        }

        for (int i = c0; i < c0 + c1; i++)
        {
            nums[i] = 1;
        }

        for (int i = c0 + c1; i < nums.Length; i++)
        {
            nums[i] = 2;
        }
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { 2, 0, 2, 1, 1, 0 })]
    [DataRow(2, new int[] { 2, 0, 1 })]
    [DataRow(3, new int[] { 0 })]
    [DataRow(4, new int[] { 1 })]
    [DataRow(5, new int[] { 1, 0, 0 })]
    [DataTestMethod]
    public void MyTestMethod(int order, int[] nums)
    {
        (new Solution()).SortColors(nums);
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                Assert.Fail();
            }
        }
    }
}