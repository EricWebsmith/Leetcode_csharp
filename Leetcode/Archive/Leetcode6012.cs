namespace Leetcode6012;


public class Solution
{
    private bool IsEvenDigitSum(int num)
    {
        int sum = 0;
        while(num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum % 2 == 0;
    }

    public int CountEven(int num)
    {
        int ten = num / 10 * 10;
        int ans = ten / 2;

        if (!IsEvenDigitSum(ten))
        {
            ans--;
        }

        for(int i = ten + 1; i <= num; i++)
        {
            if (IsEvenDigitSum(i))
            {
                ans++;
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int num, int expected)
    {
        int actual = new Solution().CountEven(num);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test4() { TestBase(4, 2); }
    [TestMethod] public void Test28() { TestBase(28, 14); }
    [TestMethod] public void Test29() { TestBase(29, 14); }
    [TestMethod] public void Test30() { TestBase(30, 14); }
    [TestMethod] public void Test50() { TestBase(50, 24); }
    [TestMethod] public void Test31() { TestBase(31, 15); }
    [TestMethod] public void Test3() { TestBase(3, 1); }
    [TestMethod] public void Test1() { TestBase(1,0); }
    [TestMethod] public void Test13() { TestBase(13, 6); }

}