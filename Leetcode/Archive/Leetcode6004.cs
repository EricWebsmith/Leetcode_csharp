namespace Leetcode6004;


public class Solution
{
    public int CountOperations(int num1, int num2)
    {
        int ans = 0;
        while(num1!=0 && num2!=0)
        {
            if(num1 > num2)
            {
                num1 = num1 - num2;
            }
            else
            {
                num2 = num2 - num1;
            }
            ans++;
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int num1, int num2, int expected)
    {
        int actual = new Solution().CountOperations(num1, num2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(2, 3, 3); }
    [TestMethod] public void Test2() { TestBase(10, 10, 1); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}