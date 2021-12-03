namespace Leetcode0415;

/// <summary>
/// Runtime: 88 ms, faster than 77.72% of C# online submissions for Add Strings.
/// Memory Usage: 40.1 MB, less than 17.42% of C# online submissions for Add Strings.
/// </summary>
public class Solution
{
    public string AddStrings(string num1, string num2)
    {
        
        int[] nums1 = new int[num1.Length];
        for (int i = 0; i < num1.Length; i++)
        {
            nums1[i] = num1[num1.Length - 1 - i] - '0';
        }

        int[] nums2 = new int[num2.Length];
        for (int i = 0; i < num2.Length; i++)
        {
            nums2[i] = num2[num2.Length - 1 - i] - '0';
        }

        int n = Math.Max(nums1.Length, nums2.Length)+1;
        int[] resultArr = new int[n];
        int carry = 0;
        for(int i = 0;i< n; i++)
        {
            int temp = carry;
            if (i < nums1.Length)
            {
                temp += nums1[i];
            }

            if (i < nums2.Length)
            {
                temp += nums2[i];
            }

            carry = temp / 10;
            temp = temp % 10;
            resultArr[i] = temp;
        }

        string result = string.Empty;
        for(int i = n-1;i>= 0; i--)
        {
            result += (char)(resultArr[i]+'0');
        }

        result = result.TrimStart('0');
        if(result.Length == 0)
        {
            result = "0";
        }

        return result;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "11", "123", "134")]
    [DataRow(2, "456", "77", "533")]
    [DataRow(3, "0", "0", "0")]
    [DataRow(4, "1", "1", "2")]
    [DataRow(5, "2", "2", "4")]
    [DataRow(6, "3", "3", "6")]
    [DataRow(7, "4", "44", "48")]
    [DataRow(8, "64", "64", "128")]
    [DataTestMethod]
    public void Test(int order, string num1Str, string num2Str, string expected)
    {
        string actual = new Solution().AddStrings(num1Str, num2Str);
        Assert.AreEqual(expected, actual);
    }

}