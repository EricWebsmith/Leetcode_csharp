namespace Leetcode0171;

public class Solution
{
    public int TitleToNumber(string columnTitle)
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Dictionary<char, int> letter_dict = new Dictionary<char, int>();
        for (int i = 0; i < 26; i++)
        {
            letter_dict[letters[i]] = i + 1;
        }

        int result = 0;
        int times = 1;
        for (int i = 0; i < columnTitle.Length; i++)
        {
            char letter = columnTitle[columnTitle.Length - 1 - i];
            int v = letter_dict[letter];
            result += v * times;
            times = times * 26;
        }
        return result;
    }
}

[TestClass]
public class Leetcode0171
{
    void TestBase(string columnTitle, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.TitleToNumber(columnTitle);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1() { TestBase("A", 1); }

    [TestMethod]
    public void Test2() { TestBase("AB", 28); }

    [TestMethod]
    public void Test3() { TestBase("ZY", 701); }

    [TestMethod]
    public void Test4() { TestBase("FXSHRXW", 2147483647); }

    [TestMethod]
    public void Test5() { TestBase("AZ", 52); }

}

