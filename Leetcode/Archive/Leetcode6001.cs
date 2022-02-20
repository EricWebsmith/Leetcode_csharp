namespace Leetcode6001;


public class Solution
{
    public long SmallestNumber(long num)
    {
        if(num == 0) { return 0; }

        int sign = 1;
        if (num < 0)
        {
            sign = -1;
            num = - num;
        }

        char[] s = num.ToString().ToArray();

        if(sign == -1)
        {
            Array.Sort(s);
            return -long.Parse( String.Join("", s.Reverse()));
        }

        else
        {
            Array.Sort(s);
            if (s[0] == '0')
            {
                int index = 0;
                while (s[index] == '0')
                {
                    index++;
                }
                s[0] = s[index];
                s[index] = '0';
            }
            return long.Parse(String.Join("", s));
        }
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(long num, long expected)
    {
        long actual =new Solution(). SmallestNumber(num);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(310, 103); }
    [TestMethod] public void Test2() { TestBase(-7605, -7650); }
    [TestMethod] public void Test3() { TestBase(0, 0); }
    [TestMethod] public void Test4() { TestBase(1, 1); }
    [TestMethod] public void Test5() { TestBase(-1, -1); }
    [TestMethod] public void Test6() { TestBase(1234567890, 1023456789); }

}