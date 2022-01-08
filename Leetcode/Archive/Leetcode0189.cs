namespace Leetcode0189;


public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        if (nums.Length <= 1)
        {
            return;
        }

        k = k % nums.Length;
        int temp = 0;
        for (int i = 0; i < k; i++)
        {
            temp = nums[nums.Length - 1];
            // rotate
            for (int j = nums.Length - 1; j > 0; j--)
            {
                nums[j] = nums[j - 1];
            }
            nums[0] = temp;
        }
    }
}

public class Solution2
{
    public void Rotate(int[] nums, int k)
    {
        if (nums.Length <= 1)
        {
            return;
        }

        if (k == 0)
        {
            return;
        }

        k = k % nums.Length;
        int[] temp = new int[k];
        for (int i = 0; i < k; i++)
        {
            temp[i] = nums[nums.Length - k + i];
        }

        // rotate
        for (int j = nums.Length - 1; j >= k; j--)
        {
            nums[j] = nums[j - k];
        }

        for (int i = 0; i < k; i++)
        {
            nums[i] = temp[i];
        }

    }
}

public class Solution3
{
    public void Rotate(int[] nums, int k)
    {
        k = k % nums.Length;
        if (k == 0) { return; }

        Flip(nums, 0, nums.Length);
        Flip(nums, 0, k);
        Flip(nums, k, nums.Length);
    }

    private static void Flip(int[] nums, int start, int end)
    {
        for (int i = start; i < (start + end) / 2; i++)
        {
            int j = start + end - i - 1;
            (nums[i], nums[j]) = (nums[j], nums[i]);
        }
    }
}

[TestClass]
public class Leetcode0189
{
    public void TestBase(int[] nums, int k ,int[] result)
    {
        Solution3 solution = new Solution3();
        solution.Rotate(nums, k);
        for(int i=0; i<nums.Length; i++)
        {
            Assert.AreEqual(result[i], nums[i]);
        }
    }

    [TestMethod]
    public void Test1()
    {
        TestBase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 });
    }

    [TestMethod]
    public void Test2()
    {
        TestBase(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 });
    }
}

