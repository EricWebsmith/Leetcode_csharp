namespace Leetcode5960;


public class Solution
{
    public string CapitalizeTitle(string title)
    {
        int n = title.Length;
        StringBuilder sb = new StringBuilder(title);
        int count = 0;
        for(int i = n - 1; i >= 0; i--)
        {
            
            sb[i] = Char.ToLower(sb[i]);
            if(sb[i] == ' ')
            {
                if(count >= 3)
                {
                    sb[i+1] = Char.ToUpper(sb[i+1]);
                }
                count = 0;
            }
            else
            {
                count++;
            }
        }

        if (count >= 3)
        {
            sb[0] = Char.ToUpper(sb[0]);
        }

        return sb.ToString();
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string title, string expected)
    {
        string actual = new Solution().CapitalizeTitle(title);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("capiTalIze tHe titLe", "Capitalize The Title"); }
    [TestMethod] public void Test2() { TestBase("First leTTeR of EACH Word", "First Letter of Each Word"); }
    [TestMethod] public void Test3() { TestBase("i lOve leetcode", "i Love Leetcode"); }
    [TestMethod] public void Test4() { TestBase("i have a dREAM", "i Have a Dream"); }

}