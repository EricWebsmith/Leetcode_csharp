namespace Leetcode5966;


/// <summary>
/// Time Limit Exceeded
/// </summary>
public class Solution
{

    int n;
    int[] nums;
    List<int> current = new List<int>();
    //List<int> rest = new List<int>();
    List<int> rest = new List<int>();
    int[] ans;
    bool found = false;


    private bool Dfs(int restChoices)
    {
        if (found)
        {
            return false;
        }

        if (current.Count == n)
        {
            List<int> restList =rest.ToList();
            restList.Sort();
            int diff = restList[0] - current[0];

            if (diff % 2 == 1)
            {
                return false;
            }

            for (int i = 1; i < n; i++)
            {
                if (diff != restList[i] - current[i])
                {
                    return false;
                }
            }

            ans = new int[n];
            for (int i = 0; i < n; i++)
            {
                ans[i] = (current[i] + restList[i]) / 2;
            }
            found = true;
        }

        //choose
        for(int i = n * 2 - restChoices; i < n * 2-1; i++)
        {
            current.Add(nums[i]);
            rest.Remove(nums[i]);
            Dfs(2*n-i-1);
            current.RemoveAt(current.Count-1);
            rest.Add(nums[i]);
        }

        return false;
    }

    public int[] RecoverArray(int[] nums)
    {

        Array.Sort(nums);
        this.nums = nums;
        n = nums.Length / 2;

        rest = nums.ToList();

        current.Add(nums[0]);
        rest.RemoveAt(0);
        Dfs(2*n-1);

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, params string[] expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int[] ans = new Solution().RecoverArray(nums);
        string actual = ans.ToLeetcode();
        Assert.IsTrue(expected.Contains(actual));
    }

    [TestMethod] public void Test1() { TestBase("[2,10,6,4,8,12]", "[3,7,11]", "[5,7,9]"); }
    [TestMethod] public void Test2() { TestBase("[1,1,3,3]", "[2,2]"); }
    [TestMethod] public void Test3() { TestBase("[5,435]", "[220]"); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,4]", "[2,3]"); }
    
    [TestMethod] public void Test5() { TestBase("[11,6,3,4,8,7,8,7,9,8,9,10,10,2,1,9]", "[2,3,7,8,8,9,9,10]"); }
    [TestMethod] public void Test6() { TestBase("[1,2,3,3,4,5]", "[2,3,4]"); }
    [TestMethod] public void Test7() { TestBase(
        "[8,4,5,1,9,8,6,5,6,9,7,3,8,3,6,7,10,11,6,4]",
        "[2,4,5,5,6,7,7,8,9,10]"); }
    [TestMethod]
    public void TestPerformance()
    {
        int[] nums = new int[] {
            79, 96, 98, 60, 77, 80, 97, 22, 27, 4, 89, 61, 91, 58, 98, 42,
            75, 40, 65, 64, 73, 14, 97, 78, 75, 69, 92, 58, 10, 60, 28, 13,
            96, 63, 11, 67, 53, 20, 77, 99, 68, 32, 95, 100, 88, 26, 60, 85,
            8, 97, 90, 83, 10, 90, 25, 38, 75, 38, 73, 66, 98, 16, 40, 95,
            19, 54, 52, 23, 62, 44, 30, 71, 2, 77, 12, 51, 66, 21, 25, 75};
        int[] ans = new Solution().RecoverArray(nums);
    }       

}