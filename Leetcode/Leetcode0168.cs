namespace Leetcode0168;

public class Solution
{
    public string ConvertToTitle(int columnNumber)
    {
        string letters = "ZABCDEFGHIJKLMNOPQRSTUVWXY";
        int t = columnNumber;
        string result = string.Empty;
        while (t > 0)
        {
            int r = t % 26;
            result = letters[r] + result;
            if (t == 26)
            {
                break;
            }
            t = t / 26;
            if (r == 0)
            {
                t = t - 1;
            }
        }
        return result;
    }
}

[TestClass]
public class Leetcode0168
{
    [TestMethod]
    public void Test1()
    {
        Solution solution = new Solution();
        string result = solution.ConvertToTitle(1);
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    public void Test2()
    {
        Solution solution = new Solution();
        string result = solution.ConvertToTitle(28);
        Assert.AreEqual("AB", result);
    }

    [TestMethod]
    public void Test3()
    {
        Solution solution = new Solution();
        string result = solution.ConvertToTitle(701);
        Assert.AreEqual("ZY", result);
    }

    [TestMethod]
    public void Test4()
    {
        Solution solution = new Solution();
        string result = solution.ConvertToTitle(2147483647);
        Assert.AreEqual("FXSHRXW", result);
    }

    [TestMethod]
    public void Test5()
    {
        Solution solution = new Solution();
        string result = solution.ConvertToTitle(52);
        Assert.AreEqual("AZ", result);
    }
}

