namespace Leetcode6019;


public class Solution
{
    private int GetGcd(int x, int y)
    {
        if (x == 0) return y;
        return GetGcd(y % x, x);
    }

    public IList<int> ReplaceNonCoprimes(int[] nums)
    {
        List<int> list = new List<int>(nums);
        int left = 0;
        while (left < list.Count - 1)
        {

            int gcd = GetGcd(list[left], list[left + 1]);
            if (gcd > 1)
            {
                list[left] = list[left] / gcd * list[left + 1];
                list.RemoveAt(left + 1);
                if (left > 0)
                {
                    left--;
                }
            }
            else
            {
                left++;
            }
        }

        return list;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, string expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int[] ans = new Solution().ReplaceNonCoprimes(nums).ToArray();
        string actual = ans.ToLeetcode();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[6,4,3,2,7,6,2]", "[12,7,6]"); }
    [TestMethod] public void Test2() { TestBase("[2,2,1,1,3,3,3]", "[2,1,1,3]"); }
    [TestMethod] public void Test3() { TestBase("[287,41,49,287,899,23,23,20677,5,825]", "[2009,20677,825]"); }
    [TestMethod] public void Test4() { TestBase("[2009,899,20677,825]", "[2009,20677,825]"); }

}