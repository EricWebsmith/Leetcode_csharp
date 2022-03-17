namespace Leetcode5227;


public class Solution
{
    public int MaximumTop(int[] nums, int k)
    {
        return 0;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int k, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().MaximumTop(nums, k);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[91,98,17,79,15,55,47,86,4,5,17,79,68,60,60,31,72,85,25,77,8,78,40,96,76,69,95,2,42,87,48,72,45,25,40,60,21,91,32,79,2,87,80,97,82,94,69,43,18,19,21,36,44,81,99]", 2, 91); }
    [TestMethod] public void Test2() { TestBase("[91,98,17]",3, 98); }
    [TestMethod] public void Test3() { TestBase("[1,2,3,4,5]", 3, 4); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,2,5]", 3, 2); }
    [TestMethod] public void Test5() { TestBase("[17,61,5,1,44]", 100, 61); }

    [TestMethod] public void Test6() { TestBase("[1,2,1000000000]", 2, 1000000000); }
    [TestMethod] public void Test7() { TestBase("[3,2,1]", 1, 2); }
    [TestMethod] public void Test8() { TestBase("[3,2,1]", 2, 3); }
    [TestMethod] public void Test9() { TestBase("[5,4,3,2,1]", 3, 5); }
    [TestMethod] public void Test10() { TestBase("[5,4,3,2,1]", 4, 5); }
    [TestMethod] public void Test11() { TestBase("[1,2,3,4,5]", 1, 2); }
    [TestMethod] public void Test12() { TestBase("[1,2,3,4,5]", 2, 3); }
    [TestMethod] public void Test13() { TestBase("[1,2,3,4,5]", 3, 4); }
    [TestMethod] public void Test14() { TestBase("[1,2,3,4,5]", 4, 5); }
    [TestMethod] public void Test15() { TestBase("[1,2,3,4,5]", 5, 4); }
    [TestMethod] public void Test16() { TestBase("[1,2,3,4,5]", 6, 4); }
    [TestMethod] public void Test17() { TestBase("[1,2,3,4,5]", 7, 5); }
    
    [TestMethod] public void Test22() { TestBase("[1,2,3,2,1]", 2, 3); }
    [TestMethod] public void Test23() { TestBase("[1,2,3,2,1]", 3, 2); }
    [TestMethod] public void Test24() { TestBase("[1,2,3,2,1]",4, 2); }
    [TestMethod] public void Test25() { TestBase("[1,2,3,2,1]", 5, 3); }
    [TestMethod] public void Test26() { TestBase("[1,2,3,2,1]", 6, 3); }
    [TestMethod] public void Test100() { TestBase("[31,15,92,84,19,92,55]", 4, 92); }

}