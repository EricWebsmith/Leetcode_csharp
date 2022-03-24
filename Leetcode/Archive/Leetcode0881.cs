namespace Leetcode0881;


public class Solution
{
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);
        int num = people.Length;
        int left = 0;
        int right = num - 1;
        int boats = 0;
        while (left <= right)
        {
            if(people[left] + people[right]<=limit)
            {
                left++;
                right--;
            }
            else
            {
                right--;
            }
            boats++;
        }

        return boats;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string peopleStr, int limit, int expected)
    {
        int[] people = peopleStr.LeetcodeToArray();
        int actual = new Solution().NumRescueBoats(people, limit);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,2]", 3, 1); }
    [TestMethod] public void Test2() { TestBase("[3,2,2,1]", 3, 3); }
    [TestMethod] public void Test3() { TestBase("[3,5,3,4]", 5, 4); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 156 ms, faster than 86.90% of C# online submissions for Boats to Save People.
Memory Usage: 46.4 MB, less than 25.00% of C# online submissions for Boats to Save People. 
 */